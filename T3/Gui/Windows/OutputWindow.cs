﻿using ImGuiNET;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using T3.Core.Operator;
using T3.Gui.OutputUi;

namespace T3.Gui.Windows
{
    public class OutputWindow : Window
    {
        public OutputWindow() 
        {
            _title = "Output##" + _instanceCounter;
            _visible = true;

            _allowMultipeInstances = true;
            _visible = true;

            WindowInstances.Add(this);
            _instanceCounter++;
        }


        protected override void DrawAllInstances()
        {
            // Wrap inside list to enable removable of members during iteration
            foreach (var w in new List<OutputWindow>(WindowInstances))
            {
                w.DrawOneInstance();
            }
        }


        protected override void Close()
        {
            WindowInstances.Remove(this);
        }


        protected override void AddAnotherInstance()
        {
            new OutputWindow();
        }


        protected override void DrawContent()
        {
            _pinning.UpdateSelection();

            _imageCanvas.Draw();
            ImGui.SetCursorPos(ImGui.GetWindowContentRegionMin() + new Vector2(0, 40));
            DrawSelection(_pinning.SelectedInstance, _pinning.SelectedUi);
            DrawToolbar();
        }


        private void DrawToolbar()
        {
            ImGui.SetCursorPos(ImGui.GetWindowContentRegionMin());
            _pinning.DrawPinning();

            if (ImGui.Button("1:1"))
            {
                _imageCanvas.SetScaleToMatchPixels();
                _imageCanvas.SetViewMode(ImageOutputCanvas.Modes.Pixel);
            }
            ImGui.SameLine();

            if (ImGui.Button("M"))
            {
                _imageCanvas.SetViewMode(ImageOutputCanvas.Modes.Fitted);
            }
            ImGui.SameLine();
        }

        private static void DrawSelection(Instance selectedInstance, SymbolUi selectedUi)
        {
            if (selectedInstance == null)
                return;

            if (selectedInstance.Outputs.Count <= 0)
                return;
            
            var firstOutput = selectedInstance.Outputs[0];
            if (!selectedUi.OutputUis.ContainsKey(firstOutput.Id))
                return;
            
            IOutputUi outputUi = selectedUi.OutputUis[firstOutput.Id];
            outputUi.DrawValue(firstOutput);
        }
        

        private readonly ImageOutputCanvas _imageCanvas = new ImageOutputCanvas();
        private readonly SelectionPinning _pinning = new SelectionPinning();

        private static readonly List<OutputWindow> WindowInstances = new List<OutputWindow>();
        static int _instanceCounter ;
    }
}
