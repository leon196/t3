﻿using System;
using System.Collections.Generic;
using System.Linq;
using ImGuiNET;
using SharpDX.Direct3D11;
using T3.Core.Operator.Slots;
using T3.Gui.Interaction;
using T3.Gui.Interaction.Variations;
using T3.Gui.Interaction.Variations.Model;
using T3.Gui.Selection;
using T3.Gui.Windows.Exploration;
using UiHelpers;
using Vector2 = System.Numerics.Vector2;

namespace T3.Gui.Windows.Variations
{
    public class VariationCanvas : ScalableCanvas, ISelectionContainer
    {
        public VariationCanvas(VariationsWindow variationsWindow)
        {
            ResetView();
            _variationsWindow = variationsWindow;
        }

        public void Draw(SymbolVariationPool activePoolForPresets)
        {
            _thumbnailCanvasRendering.InitializeCanvasTexture(VariationThumbnail.ThumbnailSize);
            
            
            // var outputWindow = OutputWindow.OutputWindowInstances.FirstOrDefault(window => window.Config.Visible) as OutputWindow;
            // if (outputWindow == null)
            // {
            //     ImGui.TextUnformatted("No output window found");
            //     return;
            // }
            //
            // var instance = outputWindow.ShownInstance;
            // if (instance == null || instance.Outputs == null || instance.Outputs.Count == 0)
            // {
            //     CustomComponents.EmptyWindowMessage("To explore variations\nselect a graph operator and\none or more of its parameters.");
            //     return;
            // }
            //
            //
            // // Draw Canvas Texture
            //
            // _firstOutputSlot = instance.Outputs[0];
            // if (!(_firstOutputSlot is Slot<Texture2D> textureSlot))
            // {
            //     CustomComponents.EmptyWindowMessage("Output window must be pinned\nto a texture operator.");
            //     _firstOutputSlot = null;
            //     return;
            // }
            //
            // // Set correct output ui
            // {
            //     var symbolUi = SymbolUiRegistry.Entries[instance.Symbol.Id];
            //     if (!symbolUi.OutputUis.ContainsKey(_firstOutputSlot.Id))
            //         return;
            //
            //     _variationsWindow.OutputUi = symbolUi.OutputUis[_firstOutputSlot.Id];
            // }
            //
            // if (textureSlot.Value == null)
            //     return;
            //
            // FillInNextVariation();
            UpdateCanvas();
            HandleFenceSelection();
            //Invalidate();

            var drawList = ImGui.GetWindowDrawList();

            foreach (var v in activePoolForPresets.Variations)
            {
                VariationThumbnail.Draw(this, v, drawList);
            }

            // Draw Canvas Texture
            var canvasSize = _thumbnailCanvasRendering.GetCanvasTextureSize();
            var rectOnScreen = ImRect.RectWithSize(WindowPos, canvasSize);
            drawList.AddImage((IntPtr)_thumbnailCanvasRendering.CanvasTextureSrv, rectOnScreen.Min, rectOnScreen.Max);

            // foreach (var variation in _variationByGridIndex.Values)
            // {
            //     if (!IsCellVisible(variation.GridCell))
            //         continue;
            //
            //     var screenRect = GetScreenRectForCell(variation.GridCell);
            //     if (variation.ThumbnailNeedsUpdate)
            //     {
            //         drawList.AddRectFilled(screenRect.Min, screenRect.Max, _needsUpdateColor);
            //     }
            // }
            //
            // _hoveringVariation?.RestoreValues();
            // var size = THelpers.GetContentRegionArea();
            // ImGui.InvisibleButton("variationCanvas", size.GetSize());
            //
            // if (ImGui.IsItemHovered())
            // {
            //     _hoveringVariation = CreateVariationAtMouseMouse();
            //
            //     if (_hoveringVariation != null)
            //     {
            //         if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
            //         {
            //             var savedVariation = _hoveringVariation.Clone();
            //
            //             _explorationWindow.SaveVariation(savedVariation);
            //             savedVariation.ApplyPermanently();
            //         }
            //
            //         _hoveringVariation.KeepCurrentAndApplyNewValues();
            //     }
            // }
            // else
            // {
            //     _hoveringVariation = null;
            // }
        }


        public void ClearVariations()
        {
            _updateCompleted = false;
            // _variationByGridIndex.Clear();
        }

        public void ResetView()
        {
            var extend = new Vector2(3, 3);
            var center = Vector2.Zero;
            var left = (center - extend) * VariationThumbnail.ThumbnailSize;
            var right = (center + extend) * VariationThumbnail.ThumbnailSize;

            FitAreaOnCanvas(new ImRect(left, right));
        }
        
        
        private void HandleFenceSelection()
        {
            _fenceState = SelectionFence.UpdateAndDraw(_fenceState);
            switch (_fenceState)
            {
                case SelectionFence.States.PressedButNotMoved:
                    if (SelectionFence.SelectMode == SelectionFence.SelectModes.Replace)
                        _selection.Clear();
                    break;

                case SelectionFence.States.Updated:
                    HandleSelectionFenceUpdate(SelectionFence.BoundsInScreen);
                    break;

                case SelectionFence.States.CompletedAsClick:
                    _selection.Clear();
                    break;
            }
        }

        

        private void HandleSelectionFenceUpdate(ImRect boundsInScreen)
        {
            var boundsInCanvas = InverseTransformRect(boundsInScreen);
            var elementsToSelect = (from child in VariationPool.Variations
                                 let rect = new ImRect(child.PosOnCanvas, child.PosOnCanvas + child.Size)
                                 where rect.Overlaps(boundsInCanvas)
                                 select child).ToList();

            _selection.Clear();
            foreach (var element in elementsToSelect)
            {
                _selection.AddSelection(element);
            }
        }
        
        // private ImRect GetScreenRectForCell(GridCell gridCell)
        // {
        //     var thumbnailInCanvas = ImRect.RectWithSize(new Vector2(gridCell.X, gridCell.Y) * _thumbnailSize, _thumbnailSize);
        //     var r = TransformRect(thumbnailInCanvas);
        //     return new ImRect((int)r.Min.X, (int)r.Min.Y, (int)r.Max.X - 1, (int)r.Max.Y - 1);
        // }
        //
        // private GridCell GetScreenRectForGridCell(Vector2 screenPos)
        // {
        //     var centerInCanvas = InverseTransformPosition(screenPos);
        //     return new GridCell(
        //                         (int)(centerInCanvas.X / _thumbnailSize.X),
        //                         (int)(centerInCanvas.Y / _thumbnailSize.Y));
        // }

        // private bool IsCellVisible(GridCell gridCell)
        // {
        //     var contentRegion = new ImRect(ImGui.GetWindowContentRegionMin() + ImGui.GetWindowPos(),
        //                                    ImGui.GetWindowContentRegionMax() + ImGui.GetWindowPos());
        //
        //     contentRegion.Expand(_thumbnailSize * Scale);
        //
        //     var rectOnScreen = GetScreenRectForCell(gridCell);
        //
        //     var visible = contentRegion.Contains(rectOnScreen);
        //     return visible;
        // }

        // private void Invalidate()
        // {
        //     var scaleChanged = Math.Abs(Scale.X - _lastScale) > 0.01f;
        //     var scrollChanged = Math.Abs(Scroll.X - _lastScroll.X) > 0.1f
        //                         || Math.Abs(Scroll.Y - _lastScroll.Y) > 0.1f;
        //     
        //     // TODO: optimize performance by only invalidating thumbnails and moving part of the canvas  
        //     if (scaleChanged || scrollChanged)
        //     {
        //         _lastScale = Scale.X;
        //         _lastScroll = Scroll;
        //
        //         //_currentOffsetIndexForFocus = 0;
        //         _updateCompleted = false;
        //
        //         // foreach (var variation in _variationByGridIndex.Values)
        //         // {
        //         //     variation.ThumbnailNeedsUpdate = true;
        //         // }
        //
        //         // if (ImGui.IsWindowHovered())
        //         // {
        //         //     SetGridFocusToMousePos();
        //         // }
        //         // else
        //         // {
        //         //     SetGridFocusToWindowCenter();
        //         // }
        //
        //         _thumbnailCanvasRendering.ClearTexture();
        //     }
        // }

        // private void SetGridFocusToWindowCenter()
        // {
        //     var contentRegion = new ImRect(ImGui.GetWindowContentRegionMin() + ImGui.GetWindowPos(),
        //                                    ImGui.GetWindowContentRegionMax() + ImGui.GetWindowPos());
        //     var centerInCanvas = InverseTransformPosition(contentRegion.GetCenter());
        //     _gridFocusIndex.X = (int)(centerInCanvas.X / _thumbnailSize.X);
        //     _gridFocusIndex.Y = (int)(centerInCanvas.Y / _thumbnailSize.Y);
        // }

        // private void SetGridFocusToMousePos()
        // {
        //     var centerInCanvas = InverseTransformPosition(ImGui.GetMousePos());
        //     _gridFocusIndex.X = (int)(centerInCanvas.X / _thumbnailSize.X);
        //     _gridFocusIndex.Y = (int)(centerInCanvas.Y / _thumbnailSize.Y);
        // }

        private void FillInNextVariation()
        {
            // if (_updateCompleted)
            // {
            //     return;
            // }
            //
            // if (_explorationWindow.VariationParameters.Count == 0)
            // {
            //     return;
            // }
            //
            // while (_currentOffsetIndexForFocus < _sortedOffset.Length)
            // {
            //     var offset = _sortedOffset[_currentOffsetIndexForFocus++];
            //     var cell = _gridFocusIndex + offset;
            //     if (!cell.IsWithinGrid())
            //         continue;
            //
            //     if (!IsCellVisible(cell))
            //         continue;
            //
            //     var hasVariation = _variationByGridIndex.TryGetValue(cell.GridIndex, out var variation);
            //     if (hasVariation)
            //     {
            //         if (!variation.ThumbnailNeedsUpdate)
            //             continue;
            //
            //         RenderThumbnail(variation);
            //         return;
            //     }
            //     else
            //     {
            //         variation = CreateVariationForCell(cell);
            //         RenderThumbnail(variation);
            //         _variationByGridIndex[cell.GridIndex] = variation;
            //         return;
            //     }
            // }
            //
            // _updateCompleted = true;
        }

        private void RenderThumbnail(ExplorationVariation variation, int thumbnailIndex)
        {
            variation.ThumbnailNeedsUpdate = false;

            //var screenRect = GetScreenRectForCell(variation.GridCell);
            //var posInCanvasTexture = screenRect.Min - WindowPos;

            // Set variation values
            variation.KeepCurrentAndApplyNewValues();

            // Render variation
            _thumbnailCanvasRendering.EvaluationContext.Reset();
            _thumbnailCanvasRendering.EvaluationContext.TimeForKeyframes = 13.4f;

            // NOTE: This is horrible hack to prevent _imageCanvas from being rendered by ImGui
            // DrawValue will use the current ImageOutputCanvas for rendering
            _imageCanvas.SetAsCurrent();
            ImGui.PushClipRect(new Vector2(0, 0), new Vector2(1, 1), true);
            _variationsWindow.OutputUi.DrawValue(_firstOutputSlot, _thumbnailCanvasRendering.EvaluationContext);
            ImGui.PopClipRect();
            _imageCanvas.Deactivate();

            var columns = (int)(_thumbnailCanvasRendering.GetCanvasTextureSize().X / VariationThumbnail.ThumbnailSize.X);
            var rowIndex = thumbnailIndex / columns;
            var columnIndex = thumbnailIndex % columns;
            var posInCanvasTexture = new Vector2(columnIndex, rowIndex) * VariationThumbnail.ThumbnailSize;

            if (_firstOutputSlot is Slot<Texture2D> textureSlot)
            {
                var rect = ImRect.RectWithSize(posInCanvasTexture, VariationThumbnail.ThumbnailSize);
                _thumbnailCanvasRendering.CopyToCanvasTexture(textureSlot, rect);
            }

            variation.RestoreValues();
        }
        
        private static SymbolVariationPool VariationPool => VariationHandling.ActivePoolForPresets;

        private Vector2 _lastScroll = Vector2.One;

        private bool _updateCompleted;
        private readonly ImageOutputCanvas _imageCanvas = new();

        private readonly VariationsWindow _variationsWindow;
        private ISlot _firstOutputSlot;

        private readonly ThumbnailCanvasRendering _thumbnailCanvasRendering = new();
        private SelectionFence.States _fenceState;
        internal CanvasElementSelection _selection = new();
        
        public IEnumerable<ISelectableCanvasObject> GetSelectables()
        {
            return VariationPool.Variations;
        }
    }
}