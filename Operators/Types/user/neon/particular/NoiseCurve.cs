using T3.Core.DataTypes;
using System.Numerics;
using System;
using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_526c62d1_40ee_4b6b_b729_2e09815f61d0
{
    public class NoiseCurve : Instance<NoiseCurve>
    {

        [Output(Guid = "a51f5e91-9d2a-40b0-a357-258b8b0fb32f")]
        public readonly Slot<BufferWithViews> Output = new Slot<BufferWithViews>();


        [Input(Guid = "3407d5b0-d843-44a5-b54f-99f25ff56d70")]
        public readonly InputSlot<BufferWithViews> Points = new InputSlot<BufferWithViews>();

    }
}

