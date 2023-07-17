using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_d3273617_2a63_415c_b779_5aef67b3952a
{
    public class SubdivideLinePointsCustom : Instance<SubdivideLinePointsCustom>
    {

        [Output(Guid = "43181d66-d697-4dee-9a3d-7d37623789c1")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "7a948972-871b-49ad-b89e-98cd69e57e12")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "5f0bb279-ba13-46d9-8bd4-b295a162ab2c")]
        public readonly InputSlot<int> Count = new InputSlot<int>();


        private enum SampleModes
        {
            StartEnd,
            StartLength,
        }
    }
}

