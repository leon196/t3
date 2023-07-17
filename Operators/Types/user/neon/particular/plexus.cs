using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_ab56e571_c495_493c_a4a4_45e889acab5f
{
    public class plexus : Instance<plexus>
    {
        [Output(Guid = "24e96084-b02e-4b97-83f7-7290a1c49731")]
        public readonly Slot<BufferWithViews> OutBuffer = new Slot<BufferWithViews>();

        [Input(Guid = "0a86678a-0b9c-445a-aa07-43963261d4bd")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "2e20c7a4-f201-47a9-87f0-e888a2b5a967")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

        [Input(Guid = "b339199e-ee83-461e-bb53-7133429674ea")]
        public readonly InputSlot<float> Feather = new InputSlot<float>();

        [Input(Guid = "ed6f0903-4b53-4755-8bd3-a83e5b5bc5d8")]
        public readonly InputSlot<bool> RandomIndex = new InputSlot<bool>();

        [Input(Guid = "4b7abb04-eb3e-467c-8aa3-2175482782ae")]
        public readonly InputSlot<float> Seed = new InputSlot<float>();

    }
}

