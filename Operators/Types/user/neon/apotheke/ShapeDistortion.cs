using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_54c4c594_7a04_4228_a83b_ce45cf4ba52a
{
    public class ShapeDistortion : Instance<ShapeDistortion>
    {
        [Output(Guid = "786695cf-851c-4ad2-aa91-2f39fd57aaa0")]
        public readonly Slot<MeshBuffers> Result = new Slot<MeshBuffers>();

        [Output(Guid = "5a77d333-5c62-4ac6-9547-d94bc5d42513")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Points = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "606a5b6a-ec26-4993-af97-651708512a71")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();


    }
}

