﻿using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using T3.Core;
using T3.Core.Logging;
using T3.Gui.Commands;
using T3.Gui.Graph.Interaction;
using T3.Gui.Graph.Rendering;
using T3.Gui.Interaction.Timing;
using T3.Gui.Selection;
using T3.Gui.UiHelpers;
using T3.Gui.Windows;

namespace T3.Gui
{
    public class T3Ui
    {
        static T3Ui()
        {
            var operatorsAssembly = Assembly.GetAssembly(typeof(Operators.Types.Id_5d7d61ae_0a41_4ffa_a51d_93bab665e7fe.Value));
            UiModel = new UiModel(operatorsAssembly);
            _userSettings = new UserSettings();
            _projectSettings = new ProjectSettings();
            BeatTiming = new BeatTiming();
            WindowManager = new WindowManager();
        }

        public void Draw()
        {
            OpenedPopUpName = String.Empty;
            SelectionManager.ProcessNewFrame();
            SrvManager.FreeUnusedTextures();
            WindowManager.Draw();
            BeatTiming.Update();
            
            SwapHoveringBuffers();
            TriggerGlobalActionsFromKeyBindings();
            DrawAppMenu();
        }
        
        private void TriggerGlobalActionsFromKeyBindings()
        {
            if (KeyboardBinding.Triggered(UserActions.Undo))
            {
                UndoRedoStack.Undo();
            }
            else if (KeyboardBinding.Triggered(UserActions.Redo))
            {
                UndoRedoStack.Redo();
            }
            else if (KeyboardBinding.Triggered(UserActions.Save))
            {
                Task.Run(Save);
            }
        }


        private void DrawAppMenu()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(6, 6));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(6, 6));
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("Save"))
                    {
                        Task.Run(Save); // Async save
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("Undo", "CTRL+Z", false, UndoRedoStack.CanUndo))
                    {
                        UndoRedoStack.Undo();
                    }

                    if (ImGui.MenuItem("Redo", "CTRL+Y", false, UndoRedoStack.CanRedo))
                    {
                        UndoRedoStack.Redo();
                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Cut", "CTRL+X")) { }
                    if (ImGui.MenuItem("Copy", "CTRL+C")) { }
                    if (ImGui.MenuItem("Paste", "CTRL+V")) { }

                    if (ImGui.MenuItem("Fix File references", ""))
                    {
                        FileReferenceOperations.FixOperatorFilepathsCommand_Executed();
                    }

                    if (ImGui.BeginMenu("Bookmarks"))
                    {
                        GraphBookmarkNavigation.DrawBookmarksMenu();
                        ImGui.EndMenu();
                    }
                    
                    ImGui.EndMenu();
                }
                WindowManager.DrawWindowsMenu();

                _statusErrorLine.Draw();
                ImGui.EndMainMenuBar();
            }
            ImGui.PopStyleVar(2);
        }

        private readonly object _saveLocker = new object();
        private readonly Stopwatch _saveStopwatch = new Stopwatch();

        private void Save()
        {
            lock (_saveLocker)
            {
                _saveStopwatch.Restart();

                UiModel.Save();

                _saveStopwatch.Stop();
                Log.Debug($"Saving took {_saveStopwatch.ElapsedMilliseconds}ms.");
            }
        }

        public static void AddHoveredId(Guid id)
        {
            _hoveredIdsForNextFrame.Add(id);
        }

        private static void SwapHoveringBuffers()
        {
            HoveredIdsLastFrame = _hoveredIdsForNextFrame;
            _hoveredIdsForNextFrame = new HashSet<Guid>();
        }

        private static HashSet<Guid> _hoveredIdsForNextFrame = new HashSet<Guid>();
        public static HashSet<Guid> HoveredIdsLastFrame { get; private set; } = new HashSet<Guid>();
        
        private readonly StatusErrorLine _statusErrorLine = new StatusErrorLine();
        public static readonly UiModel UiModel;
        private static UserSettings _userSettings;
        private static ProjectSettings _projectSettings;
        public static readonly BeatTiming BeatTiming;
        public static readonly WindowManager WindowManager;
        public static string OpenedPopUpName;    // This is reset on Frame start and can be useful for allow context menu to stay open even if a
                                                 // later context menu would also be opened. There is probably some ImGui magic to do this probably. 

        public static IntPtr NotDroppingPointer = new IntPtr(0);
        public static bool DraggingIsInProgress = false;
        public static bool ShowSecondaryRenderWindow => WindowManager.ShowSecondaryRenderWindow;
        public const string FloatNumberFormat = "{0:F2}";
    }
}
