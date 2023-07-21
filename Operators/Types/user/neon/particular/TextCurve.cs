using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_656fb482_cdf7_42b8_b056_151b0720e674
{
    public class TextCurve : Instance<TextCurve>
    {
        [Output(Guid = "57bb1373-0929-43b6-9242-6c2ba06a081b")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "093cdde5-1380-4c88-836d-acd600fde075")]
        public readonly InputSlot<Vector4> RGBA = new InputSlot<Vector4>();

        [Input(Guid = "ad28a624-8696-4695-b7b8-0d320bcc6eeb")]
        public readonly InputSlot<string> Message = new InputSlot<string>();

        [Input(Guid = "f2a9d239-e31e-4607-95fc-dca8dcda2931")]
        public readonly InputSlot<float> Animation = new InputSlot<float>();

    }
}

