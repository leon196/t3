using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_d7b73237_1212_4b4c_b166_86b186f6f076
{
    public class TextDistortion2 : Instance<TextDistortion2>
    {
        [Output(Guid = "47727599-8b2c-460d-b8b8-d38ca97bf20b")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();

        [Input(Guid = "2d0fbe05-6782-43e8-bda3-aec9b271ce27")]
        public readonly InputSlot<string> InputText = new InputSlot<string>();

        [Input(Guid = "d7cd94b9-baa9-41af-8e03-00094c377164")]
        public readonly InputSlot<System.Numerics.Vector3> Position = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "26b6a525-a932-41cc-8365-41fb93733b6b")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "7fd2a8aa-b134-4abb-aec6-ae014c15b7f8")]
        public readonly InputSlot<float> Amount = new InputSlot<float>();

        [Input(Guid = "b26c1dfa-5775-48b7-bf26-ed00e93cf289")]
        public readonly InputSlot<float> Frequency = new InputSlot<float>();

        [Input(Guid = "6ccd8e8a-17a4-44e1-9895-7c75ab0660f2")]
        public readonly InputSlot<float> VolumeScale = new InputSlot<float>();

        [Input(Guid = "3bdbdac5-640a-4b56-a570-6248556768ef")]
        public readonly InputSlot<float> FallOff = new InputSlot<float>();

    }
}

