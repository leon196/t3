using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_05d8ff6b_78cd_4325_acea_46cd655deda3
{
    public class particular : Instance<particular>
    {

        [Output(Guid = "942bae7f-945c-4a59-8cdd-01ed935b24f3")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "dd99a6b0-12c5-4418-a0ae-ad6bb3fbb8ce")]
        public readonly InputSlot<System.Numerics.Vector3> Position = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "014aa7ec-d0f0-4949-9920-ecf3ae965c2f")]
        public readonly InputSlot<float> Amount = new InputSlot<float>();

        [Input(Guid = "fb182a26-fc8a-406d-9db1-ac368c6d5f80")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();


        private enum Spaces
        {
            PointSpace,
            ObjectSpace,
            WorldSpace,
        }
    }
}

