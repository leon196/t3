using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_281b69e8_01ee_4a62_a9ed_8508c5355c6c
{
    public class SimPointMeshCollisions : Instance<SimPointMeshCollisions>
    {

        [Output(Guid = "e6e49b7a-1510-47e8-a51a-7b684b4d1c1c")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "8f2d6bb8-5242-4f21-b356-7785b6b0ff4e")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> PointsA_ = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "61c55a9d-a2b9-4d60-84f4-ffd639d0d724")]
        public readonly InputSlot<float> Bouncyness = new InputSlot<float>();

        [Input(Guid = "7bc189be-25c6-44f2-b787-9e06d3dfa0b8")]
        public readonly InputSlot<float> ClampAccelleration = new InputSlot<float>();

        [Input(Guid = "d164bae5-b843-4378-ace6-d28ea04a3020")]
        public readonly InputSlot<float> Damping = new InputSlot<float>();

        [Input(Guid = "7a42dc58-f1fc-4473-abc3-5772817cb4b6")]
        public readonly InputSlot<bool> IsEnabled = new InputSlot<bool>();

        [Input(Guid = "a4f2c0e6-1011-4793-933b-b9f0a332bbba")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();
    }
}

