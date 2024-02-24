using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_030b2cf6_e3ec_4057_9820_40c81ebf5fee
{
    public class TextDistortion : Instance<TextDistortion>
    {
        [Output(Guid = "3a2a3699-c50c-4307-b19f-3d359d85d1c0")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        [Input(Guid = "5750c3da-4e9c-46fe-83d1-9a80c43f02c4")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();


    }
}

