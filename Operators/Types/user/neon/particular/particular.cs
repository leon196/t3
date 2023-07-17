using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_05d8ff6b_78cd_4325_acea_46cd655deda3
{
    public class particular : Instance<particular>
    {

        [Output(Guid = "5b735c28-7d28-4e64-aeee-f79ac6eeb488")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> Frame = new Slot<SharpDX.Direct3D11.Texture2D>();


        private enum Spaces
        {
            PointSpace,
            ObjectSpace,
            WorldSpace,
        }
    }
}

