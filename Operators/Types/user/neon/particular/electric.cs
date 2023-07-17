using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_411dd78f_68b4_4f08_823d_474fa7d96484
{
    public class electric : Instance<electric>
    {
        [Output(Guid = "b928d06c-9202-49f4-8bfa-ce2e86a0931c")]
        public readonly Slot<BufferWithViews> OutBuffer = new Slot<BufferWithViews>();

        [Input(Guid = "33cdb0f2-a799-41b2-b652-3291a69bc19c")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "ae8537cc-a227-4456-8ab1-2670aa5eee1c")]
        public readonly InputSlot<float> Amplitude = new InputSlot<float>();

        [Input(Guid = "ed8d701a-cc82-4ddc-a57f-4ef557620931")]
        public readonly InputSlot<float> Frequency = new InputSlot<float>();

        [Input(Guid = "19cf7134-37f3-456a-b3ad-5e19fabbde71")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "59fc1c19-58c2-42f5-9d5f-9212c882c57b")]
        public readonly InputSlot<float> Variation = new InputSlot<float>();

        [Input(Guid = "8bf4d478-87c1-4914-a2f6-94d48d6535ac")]
        public readonly InputSlot<System.Numerics.Vector3> Distribution = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "8fb00451-5fba-4bc9-a147-088b17a6bf7a")]
        public readonly InputSlot<System.Numerics.Vector3> Offset = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "03663216-32dc-4e97-b4cf-a0f2114b1e86")]
        public readonly InputSlot<int> Subdivision = new InputSlot<int>();

    }
}

