using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_63ea7f13_7e53_426e_9e66_7f6afb60f1a1
{
    public class Plexus : Instance<Plexus>
    {
        [Output(Guid = "cdfc48d3-dcf9-45cf-97f4-e90adcf49df1")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        [Input(Guid = "13c612e4-9144-4b8a-b621-225166b725b3")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GTargets = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "5a23d396-f0a0-4a06-8ae9-e583bb485134")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GTargets2 = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "2949d742-11aa-4c95-b2f5-1e29cb62305c")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

        [Input(Guid = "65c54825-1222-4954-8766-e4c7815f6fd2")]
        public readonly InputSlot<int> Count = new InputSlot<int>();

        [Input(Guid = "32cacd68-1e01-4acf-8028-5d6d374e1ad9")]
        public readonly InputSlot<int> Seed = new InputSlot<int>();

    }
}

