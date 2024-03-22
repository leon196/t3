using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_601846cd_5934_4c40_96b4_a730e7f71eb6
{
    public class PatternTribal : Instance<PatternTribal>
    {
        [Output(Guid = "cb312fc9-d1d4-4825-a89f-2c631f25e051")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "310e4335-80d8-4c7b-b29a-8fcbde5e2790")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "8e62a87c-0c36-42d5-8e79-b5de111a781f")]
        public readonly InputSlot<float> Scale = new InputSlot<float>();

        [Input(Guid = "65a4d2a7-97a4-41cd-86e4-b321c5986f50")]
        public readonly InputSlot<float> WarpZ = new InputSlot<float>();

        [Input(Guid = "9bf9a9df-315c-4146-ab80-b1335ad328bb")]
        public readonly InputSlot<System.Numerics.Vector2> Offset = new InputSlot<System.Numerics.Vector2>();


    }
}

