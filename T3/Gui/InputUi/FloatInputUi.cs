﻿using System.Numerics;
using ImGuiNET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using T3.Core;
using T3.Core.Animation;
using T3.Core.Operator;
using T3.Gui.Interaction;


namespace T3.Gui.InputUi
{
    public class FloatInputUi : InputValueUi<float>
    {
        public override bool IsAnimatable => true;

        public override IInputUi Clone()
        {
            return new FloatInputUi()
                   {
                       _max = _max,
                       _min = _min,
                       _scale = _scale,
                       InputDefinition = InputDefinition,
                       Parent = Parent,
                       PosOnCanvas = PosOnCanvas,
                       Relevancy = Relevancy,
                       Size = Size
                   };
        }

        protected override InputEditStateFlags DrawEditControl(string name, ref float value)
        {
            ImGui.PushID(Id.GetHashCode());
            var inputEditState = SingleValueEdit.Draw(ref value, -Vector2.UnitX, _min, _max, _scale);
            ImGui.PopID();
            return inputEditState;
        }

        protected override void DrawReadOnlyControl(string name, ref float value)
        {
            ImGui.InputFloat(name, ref value, step: 0.0f, step_fast: 0.0f, $"%f", flags: ImGuiInputTextFlags.ReadOnly);
        }

        protected override string GetSlotValueAsString(ref float floatValue)
        {
            // This is a stub of value editing. Sadly it's very hard to get
            // under control because of styling issues and because in GraphNodes
            // The op body captures the mouse event first.
            //
            //SingleValueEdit.Draw(ref floatValue,  -Vector2.UnitX);
            
            return string.Format(T3Ui.FloatNumberFormat, floatValue);
        }
        
        protected override void DrawAnimatedValue(string name, InputSlot<float> inputSlot, Animator animator)
        {
            double time = EvaluationContext.GlobalTime;
            var curves = animator.GetCurvesForInput(inputSlot);
            foreach (var curve in curves)
            {
                float value = (float)curve.GetSampledValue(time);
                var editState = DrawEditControl(name, ref value);
                if ((editState & InputEditStateFlags.Modified) == InputEditStateFlags.Modified)
                {
                    var key = curve.GetV(time) ?? new VDefinition() { U = time };
                    key.Value = value;
                    curve.AddOrUpdateV(time, key);
                }
            }
        }

        public override void DrawSettings()
        {
            base.DrawSettings();

            ImGui.DragFloat("Min", ref _min);
            ImGui.DragFloat("Max", ref _max);
            ImGui.DragFloat("Scale", ref _scale);
        }

        public override void Write(JsonTextWriter writer)
        {
            base.Write(writer);

            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (_min != DefaultMin)
                writer.WriteValue("Min", _min);

            if (_max != DefaultMax)
                writer.WriteValue("Max", _max);

            if (_scale != DefaultScale)
                writer.WriteValue("Scale", _scale);
            // ReSharper enable CompareOfFloatsByEqualityOperator
        }

        public override void Read(JToken inputToken)
        {
            base.Read(inputToken);

            _min = inputToken["Min"]?.Value<float>() ?? DefaultMin;
            _max = inputToken["Max"]?.Value<float>() ?? DefaultMax;
            _scale = inputToken["Scale"]?.Value<float>() ?? DefaultScale;
        }

        private float _min = DefaultMin;
        private float _max = DefaultMax;
        private float _scale = DefaultScale;

        private const float DefaultScale = 0.01f;
        private const float DefaultMin = -9999999f;
        private const float DefaultMax = 9999999f;
    }
}