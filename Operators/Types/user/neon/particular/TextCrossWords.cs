using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6c8f7d6a_c3e6_43e1_b5c2_37e63e15f48d
{
    public class TextCrossWords : Instance<TextCrossWords>
    {
        [Output(Guid = "c610c91c-ab3f-4bd4-a35b-fee416237b4d")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "e661facd-2a68-492c-9b99-3cf793d69c4f")]
        public readonly InputSlot<Vector4> RGBA = new InputSlot<Vector4>();

    }
}

