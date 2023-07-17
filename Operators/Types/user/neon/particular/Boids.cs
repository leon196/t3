using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_150b7521_5da4_48a1_b8ae_1aa673f8c447
{
    public class Boids : Instance<Boids>
    {

        [Output(Guid = "780d2346-5e17-446d-8f70-726c883a3529")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "34e7ff92-f94c-49cf-84e1-87320e1e577f")]
        public readonly InputSlot<System.Numerics.Vector3> Position = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "6b00f6a7-ec3f-47f4-9251-1e8be20d540b")]
        public readonly InputSlot<float> Amount = new InputSlot<float>();

        [Input(Guid = "6ed035cc-72e0-400a-b2e4-eba78403d50c")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();


        private enum Spaces
        {
            PointSpace,
            ObjectSpace,
            WorldSpace,
        }
    }
}

