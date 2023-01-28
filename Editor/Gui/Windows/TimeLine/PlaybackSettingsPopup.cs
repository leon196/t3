﻿using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using ImGuiNET;
using ManagedBass;
using ManagedBass.Wasapi;
using T3.Core.Animation;
using T3.Core.Audio;
using T3.Core.IO;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Editor.Gui.Audio;
using T3.Editor.Gui.Graph;
using T3.Editor.Gui.Interaction.Timing;
using T3.Editor.Gui.Styling;
using T3.Editor.Gui.UiHelpers;

namespace T3.Editor.Gui.Windows.TimeLine
{
    public static class PlaybackSettingsPopup
    {
        public static readonly string PlaybackSettingsPopupId = "##PlaybackSettings";

        public static void DrawPlaybackSettings(ref Playback playback)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(8, 8));
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(2, 2));
            ImGui.SetNextWindowSize(new Vector2(600, 500));
            if (!ImGui.BeginPopupContextItem(PlaybackSettingsPopupId))
            {
                ImGui.PopStyleVar(2);
                return;
            }

            T3Ui.OpenedPopUpName = PlaybackSettingsPopupId;

            ImGui.PushFont(Fonts.FontLarge);
            ImGui.TextUnformatted("Playback settings");
            ImGui.PopFont();

            var composition = GraphWindow.GetMainComposition();
            if (composition == null)
            {
                CustomComponents.EmptyWindowMessage("no composition active");
                ImGui.EndPopup();
                ImGui.PopStyleVar(2);
                return;
            }

            FormInputs.SetIndent(0);

            FindParentWithPlaybackSettings(composition, out var compositionWithSettings, out var compositionSettings );
            //var compositionSettings = compWithSoundtrack == composition ? composition.Symbol.PlaybackSettings : null;

            // Main toggle with composition name 
            var isEnabledForCurrent = compositionWithSettings == composition && compositionSettings is { Enabled: true };

            if (FormInputs.DrawCheckBox("Specify settings for", ref isEnabledForCurrent))
            {
                if (isEnabledForCurrent)
                {
                    composition.Symbol.PlaybackSettings ??= new PlaybackSettings();
                    composition.Symbol.PlaybackSettings.Enabled = true;
                    compositionSettings = composition.Symbol.PlaybackSettings;
                }
                else
                {
                    // ReSharper disable once PossibleNullReferenceException
                    compositionSettings.Enabled = false;
                }
            }

            ImGui.SameLine();
            ImGui.PushFont(Fonts.FontBold);
            ImGui.TextUnformatted(composition.Symbol.Name);
            ImGui.PopFont();

            // Explanation hint
            //var compositionHasSoundtrack = compWithSoundtrack == composition;

            string hint;
            if (compositionSettings != null && isEnabledForCurrent)
            {
                hint = "You're defining new settings for this Project Operator.";
            }
            else if (compositionWithSettings != null && compositionWithSettings != composition)
            {
                hint = $"Inheriting settings from {compositionWithSettings.Symbol.Name}";
            }
            else
            {
                hint = string.Empty;
            }

            FormInputs.DrawHint(hint);

            if (compositionSettings == null || !compositionSettings.Enabled)
            {
                CustomComponents.EmptyWindowMessage("No settings");
                ImGui.EndPopup();
                ImGui.PopStyleVar(2);
                return;
            }

            FormInputs.ResetIndent();
            ImGui.Separator();
            FormInputs.VerticalSpace();

            if (FormInputs.DrawEnumSelector(ref compositionSettings.SyncMode, "Sync Mode"))
            {
                if (compositionSettings.SyncMode == PlaybackSettings.SyncModes.ProjectSoundTrack)
                {
                    Playback.Current = T3Ui.DefaultPlayback;
                    playback = T3Ui.DefaultPlayback;

                    if (compositionSettings.AudioClips.Count > 0)
                    {
                        playback.Bpm = compositionSettings.AudioClips[0].Bpm;
                    }

                    UserSettings.Config.ShowTimeline = true;
                }
                else
                {
                    UserSettings.Config.ShowTimeline = false;
                    UserSettings.Config.EnableIdleMotion = true;
                }
            }

            FormInputs.VerticalSpace();

            if (compositionSettings.SyncMode == PlaybackSettings.SyncModes.ProjectSoundTrack)
            {
                if (!SoundtrackUtils.TryFindingSoundtrack(composition, out var soundtrack))
                {
                    if (ImGui.Button("Add soundtrack to composition"))
                    {
                        compositionSettings.AudioClips.Add(new AudioClip
                                                            {
                                                                IsSoundtrack = true,
                                                            });
                    }
                }
                else
                {
                    var filepathModified = FormInputs.FilePicker("Soundtrack",
                                                                 ref soundtrack.FilePath,
                                                                 "filepath to soundtrack",
                                                                 null,
                                                                 FileOperations.FilePickerTypes.File
                                                                );
                    FormInputs.ApplyIndent();
                    if (ImGui.Button("Reload"))
                    {
                        AudioEngine.ReloadClip(soundtrack);
                    }

                    ImGui.SameLine();
                    if (ImGui.Button("Remove"))
                    {
                        compositionSettings.AudioClips.Remove(soundtrack);
                    }

                    FormInputs.VerticalSpace();

                    if (FormInputs.DrawFloatField("BPM",
                                                  ref soundtrack.Bpm,
                                                  0,
                                                  1000,
                                                  0.02f,
                                                  true,
                                                  "In T3 animation units are in bars.\nThe BPM rate controls the animation speed of your project.",
                                                  120))
                    {
                        playback.Bpm = soundtrack.Bpm;
                    }

                    var soundtrackStartTime = (float)soundtrack.StartTime;

                    if (FormInputs.DrawFloatField("Offset",
                                                  ref soundtrackStartTime,
                                                  -100,
                                                  100,
                                                  0.02f,
                                                  false,
                                                  "Offsets the beginning of the soundtrack in seconds.",
                                                  0))
                    {
                        soundtrack.StartTime = soundtrackStartTime;
                    }

                    FormInputs.DrawEnum(ref UserSettings.Config.TimeDisplayMode, "Display Timeline in");

                    if (FormInputs.DrawFloatField("Resync Threshold",
                                                  ref ProjectSettings.Config.AudioResyncThreshold,
                                                  0.001f,
                                                  0.1f,
                                                  0.001f,
                                                  true,
                                                  "If audio playbacks drifts too far from the animation playback it will be resynced. If the threshold for this is too low you will encounter audio glitches. If the threshold is too large you will lose precision. A normal range is between 0.02s and 0.05s.",
                                                  0.02f))

                    {
                        UserSettings.Save();
                    }

                    if (filepathModified)
                    {
                        UpdateBpmFromSoundtrackConfig(soundtrack);
                    }
                }
            }
            else if (compositionSettings.SyncMode == PlaybackSettings.SyncModes.ExternalSource)
            {
                CustomComponents.HelpText("Tab the Sync button to set begin of measure and to improve BPM detection.");
                var isInitialized = playback is BeatTimingPlayback;
                if (!isInitialized)
                {
                    playback = new BeatTimingPlayback();
                }

                FormInputs.DrawFloatField("AudioGain", ref ProjectSettings.Config.AudioGainFactor, 0.01f, 100, 0.01f, true,
                                          "Can be used to adjust the input signal (e.g. in live situation where the input level might vary.",
                                          ProjectSettings.Defaults.AudioGainFactor);

                FormInputs.DrawFloatField("AudioDecay", ref ProjectSettings.Config.AudioDecayFactor,
                                          0.001f,
                                          1f,
                                          0.01f,
                                          true,
                                          "The decay factors controls the impact of [AudioReaction] when AttackMode. Good values strongly depend on style, loudness and variation of input signal.",
                                          ProjectSettings.Defaults.AudioDecayFactor);

                if (!WasapiAudioInput.DevicesInitialized)
                {
                    WasapiAudioInput.InitializeInputDeviceList();
                }

                // Input meter
                ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
                FormInputs.DrawInputLabel("Input Level");
                ImGui.PopStyleVar();
                ImGui.InvisibleButton("##gainMeter", new Vector2(-1, ImGui.GetFrameHeight()));
                var min = ImGui.GetItemRectMin();
                var max = ImGui.GetItemRectMax();
                var dl = ImGui.GetWindowDrawList();

                var level = ProjectSettings.Config.AudioGainFactor * WasapiAudioInput.DecayingAudioLevel;

                dl.AddRectFilled(min, new Vector2(min.X + level, max.Y), T3Style.Colors.ButtonHover);

                FormInputs.DrawInputLabel("Input Device");
                ImGui.BeginGroup();

                var found = false;
                foreach (var d in WasapiAudioInput.InputDevices)
                {
                    var isSelected = d.DeviceInfo.Name == ProjectSettings.Config.AudioInputDeviceName;
                    found |= isSelected;
                    if (ImGui.Selectable($"{d.DeviceInfo.Name}", isSelected, ImGuiSelectableFlags.DontClosePopups))
                    {
                        Bass.Configure(Configuration.UpdateThreads, false);

                        ProjectSettings.Config.AudioInputDeviceName = d.DeviceInfo.Name;
                        ProjectSettings.Save();
                        WasapiAudioInput.StartInputCapture(d);
                    }

                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.PushFont(Fonts.FontSmall);
                        var sb = new StringBuilder();
                        var di = d.DeviceInfo;

                        var fields = typeof(WasapiDeviceInfo).GetProperties();
                        foreach (var f in fields)
                        {
                            sb.Append(f.Name);
                            sb.Append(": ");
                            sb.Append(f.GetValue(di));
                            sb.Append("\n");
                        }

                        ImGui.TextUnformatted(sb.ToString());
                        ImGui.PopFont();
                        ImGui.EndTooltip();
                    }
                }

                if (!found)
                {
                    ImGui.PushStyleColor(ImGuiCol.Text, T3Style.Colors.Warning.Rgba);
                    ImGui.TextUnformatted(ProjectSettings.Config.AudioInputDeviceName + " (NOT FOUND)");
                    ImGui.PopStyleColor();
                }

                ImGui.EndGroup();
            }

            // if (ImGui.BeginTabItem("OSC"))
            // {
            //     CustomComponents.HelpText("Use OSC to send events to /beatTimer on every beat.");
            //     //var isInitialized = playback is BeatTimingPlayback;
            //     if (OscBeatTiming.Initialized)
            //     {
            //         ImGui.TextUnformatted($"Last received beat {OscBeatTiming.BeatCounter}");
            //     }
            //     else
            //     {
            //         if (ImGui.Button("Initialize"))
            //         {
            //             OscBeatTiming.Init();
            //             playback = new BeatTimingPlayback();
            //         }
            //     }
            //
            //     ImGui.EndTabItem();
            // }

            ImGui.EndPopup();
            ImGui.PopStyleVar(2);
        }

        private static void UpdateBpmFromSoundtrackConfig(AudioClip audioClip)
        {
            var matchBpmPattern = new Regex(@"(\d+\.?\d*)bpm");
            var result = matchBpmPattern.Match(audioClip.FilePath);
            if (!result.Success)
                return;

            if (float.TryParse(result.Groups[1].Value, out var bpm))
            {
                Log.Debug($"Using bpm-rate {bpm} from filename.");
                audioClip.Bpm = bpm;
            }
        }

        public static bool FindParentWithPlaybackSettings(Instance startInstance, out Instance instanceWithSettings, out PlaybackSettings settings)
        {
            instanceWithSettings = startInstance;
            while (true)
            {
                //var soundtrackSymbol = instance.Symbol;
                //var soundtrack = soundtrackSymbol.PlaybackSettings.AudioClips.SingleOrDefault(ac => ac.IsSoundtrack);

                settings = instanceWithSettings.Symbol.PlaybackSettings;
                if(settings != null && settings.Enabled)
                {
                    return true;
                }

                if (instanceWithSettings.Parent == null)
                {
                    settings = null;
                    instanceWithSettings = null;
                    return false;
                }

                instanceWithSettings = instanceWithSettings.Parent;
            }
        }
    }
}