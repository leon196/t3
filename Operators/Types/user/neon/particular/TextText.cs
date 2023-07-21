using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_fec3ceec_2e30_447a_8664_83afc9e7dd28
{
    public class TextText : Instance<TextText>
    {
        [Output(Guid = "30c2761a-1140-4a5f-8f36-91c9c77d198c")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "62eca130-303a-42f9-b975-05723796faf9")]
        public readonly InputSlot<System.Numerics.Vector4> RGBA = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "3c8a0cd0-ef02-472a-9f2c-798bcd0656c6")]
        public readonly InputSlot<string> Message = new InputSlot<string>();

        [Input(Guid = "ca7dfe2e-baa9-440b-af86-4bbd11a72f74")]
        public readonly InputSlot<float> Animation = new InputSlot<float>();

    }
}

