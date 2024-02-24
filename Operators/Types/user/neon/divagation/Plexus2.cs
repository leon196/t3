using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_e213d1f2_17bd_4f8c_8d23_1d4cae7a3dc5
{
    public class Plexus2 : Instance<Plexus2>
    {
        [Output(Guid = "f23927ba-bd8e-4b0c-a9cf-26c1478a0513")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        [Input(Guid = "e3849b7c-c48a-4a2b-a67b-0fe03b95de3c")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GTargets = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "21cd2942-c2db-4fd2-bdaf-1dafc9cde54d")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GTargets2 = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "a9135321-f93f-4dc2-9947-6e13c77e20b2")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();

        [Input(Guid = "0e77e085-ccf4-42b8-88f9-04851b8c2545")]
        public readonly InputSlot<int> Count = new InputSlot<int>();

        [Input(Guid = "569e4a01-f72c-420f-8564-81134215ff25")]
        public readonly InputSlot<int> Seed = new InputSlot<int>();

        [Input(Guid = "1a47b2a7-18b7-40f7-9dcd-928ace32dabc")]
        public readonly InputSlot<float> ScatterSelect = new InputSlot<float>();

    }
}

