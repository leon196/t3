﻿using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using T3.Gui.Animation.CurveEditing;
using T3.Gui.Styling;
using Icon = T3.Gui.Styling.Icon;

namespace T3.Gui.Graph
{
    internal class TimeControls
    {
        internal static void DrawTimeControls(ClipTime clipTime, CurveEditCanvas curveEditor)
        {
            ImGui.SetCursorPos(
                               new Vector2(
                                           ImGui.GetWindowContentRegionMin().X,
                                           ImGui.GetWindowContentRegionMax().Y - 30));

            var timespan = TimeSpan.FromSeconds(clipTime.Time);

            // Current Time
            var delta = 0.0;
            if (CustomComponents.JogDial(timespan.ToString(@"hh\:mm\:ss\:ff"), ref delta, new Vector2(80, 0)))
            {
                clipTime.PlaybackSpeed = 0;
                clipTime.Time += delta;
            }

            ImGui.SameLine();

            // Jump to start
            if (CustomComponents.IconButton(Icon.JumpToRangeStart, "##jumpToBeginning", _timeControlsSize))
            {
                clipTime.Time = clipTime.TimeRangeStart;
            }

            ImGui.SameLine();

            // Prev Keyframe
            if (CustomComponents.IconButton(Icon.JumpToPreviousKeyframe, "##prevKeyframe", _timeControlsSize)
                || KeyboardBinding.Triggered(UserActions.PlaybackJumpToPreviousKeyframe))
            {
                UserActionRegistry.DeferredActions.Add(UserActions.PlaybackJumpToPreviousKeyframe);
            }
            ImGui.SameLine();

            // Play backwards
            var isPlayingBackwards = clipTime.PlaybackSpeed < 0;
            if (CustomComponents.ToggleButton(Icon.PlayBackwards,
                                              label: isPlayingBackwards ? $"[{(int)clipTime.PlaybackSpeed}x]" : "<",
                                              ref isPlayingBackwards,
                                              _timeControlsSize,
                                              trigger: KeyboardBinding.Triggered(UserActions.PlaybackBackwards)))
            {
                if (clipTime.PlaybackSpeed != 0)
                {
                    clipTime.PlaybackSpeed = 0;
                }
                else if (clipTime.PlaybackSpeed == 0)
                {
                    clipTime.PlaybackSpeed = -1;
                }
            }

            ImGui.SameLine();


            // Play forward
            var isPlaying = clipTime.PlaybackSpeed > 0;
            if (CustomComponents.ToggleButton(Icon.PlayForwards,
                                              label: isPlaying ? $"[{(int)clipTime.PlaybackSpeed}x]" : ">",
                                              ref isPlaying,
                                              _timeControlsSize,
                                              trigger: KeyboardBinding.Triggered(UserActions.PlaybackToggle)))
            {
                if (Math.Abs(clipTime.PlaybackSpeed) > 0.001f)
                {
                    clipTime.PlaybackSpeed = 0;
                }
                else if (Math.Abs(clipTime.PlaybackSpeed) < 0.001f)
                {
                    clipTime.PlaybackSpeed = 1;
                }
            }

            const float editFrameRate = 30;
            const float frameDuration = 1 / editFrameRate;
            
            // Step to previous frame
            if (KeyboardBinding.Triggered(UserActions.PlaybackPreviousFrame))
            {
                var rounded =  Math.Round(clipTime.Time * editFrameRate)/editFrameRate;    
                clipTime.Time = rounded - frameDuration;
            }

            // Step to next frame
            if (KeyboardBinding.Triggered(UserActions.PlaybackNextFrame))
            {
                var rounded =  Math.Round(clipTime.Time * editFrameRate)/editFrameRate;    
                clipTime.Time = rounded + frameDuration;
            }

            // Play backwards with increasing speed
            if (KeyboardBinding.Triggered(UserActions.PlaybackBackwards))
            {
                if (clipTime.PlaybackSpeed >= 0)
                {
                    clipTime.PlaybackSpeed = -1;
                }
                else if (clipTime.PlaybackSpeed > -8)
                {
                    clipTime.PlaybackSpeed *= 2;
                }
            }

            // Play forward with increasing speed
            if (KeyboardBinding.Triggered(UserActions.PlaybackForward))
            {
                if (clipTime.PlaybackSpeed <= 0)
                {
                    clipTime.PlaybackSpeed = 1;
                }
                else if (clipTime.PlaybackSpeed < 8)
                {
                    clipTime.PlaybackSpeed *= 2;
                }
            }

            // Stop as separate keyboard 
            if (KeyboardBinding.Triggered(UserActions.PlaybackStop))
            {
                clipTime.PlaybackSpeed = 0;
            }
            ImGui.SameLine();

            // Next Keyframe
            if (CustomComponents.IconButton(Icon.JumpToNextKeyframe, "##nextKeyframe", _timeControlsSize)
                || KeyboardBinding.Triggered(UserActions.PlaybackJumpToNextKeyframe))
            {
                UserActionRegistry.DeferredActions.Add(UserActions.PlaybackJumpToNextKeyframe);
            }
            ImGui.SameLine();

            // End
            if (CustomComponents.IconButton(Icon.JumpToRangeEnd, "##nlastKeyframe", _timeControlsSize))
            {
                clipTime.Time = clipTime.TimeRangeEnd;
            }
            ImGui.SameLine();

            // Loop
            CustomComponents.ToggleButton(Icon.Loop, "##loop", ref clipTime.IsLooping, _timeControlsSize);
            ImGui.SameLine();

            if (curveEditor != null)
            {
                if (ImGui.Button("Key"))
                {
                    curveEditor.ToggleKeyframes();
                }

                ImGui.SameLine();
            }
        }

        private static readonly Vector2 _timeControlsSize = new Vector2(40, 23);
    }
}