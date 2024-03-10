using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_0725ffa9_1664_4d16_8710_bd62897882ef
{
    public class TextDistortion3 : Instance<TextDistortion3>
    {
        [Output(Guid = "0d96e715-3fd0-4f78-bf03-ff689e62171a")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        [Input(Guid = "c72311d5-064d-4ae5-9ed2-81d0f3bcce9f")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();


    }
}

