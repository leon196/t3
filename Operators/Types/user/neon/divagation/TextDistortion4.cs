using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_a84fe7dc_51d1_48b3_8073_3d96e1e1ac48
{
    public class TextDistortion4 : Instance<TextDistortion4>
    {
        [Output(Guid = "bcba5c75-ee2e-47f6-a6da-d549c17999a4")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        [Input(Guid = "dea23c08-1598-4e23-8a62-571a55b34ff6")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();


    }
}

