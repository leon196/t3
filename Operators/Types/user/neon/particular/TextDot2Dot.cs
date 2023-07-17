using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_741a0e02_f1f0_40fd_8317_802596b979a0
{
    public class TextDot2Dot : Instance<TextDot2Dot>
    {
        [Output(Guid = "bdb9b1b0-db7f-4c13-9a8c-cabba35c0ac6")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "938871f9-8995-4eca-be29-526f5c9f27f5")]
        public readonly InputSlot<Vector4> RGBA = new InputSlot<Vector4>();

    }
}

