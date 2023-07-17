using T3.Core.DataTypes; 
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6a978975_3996_4e0b_ae9b_782a49e17c73
{
    public class _ParticleCollisionViz : Instance<_ParticleCollisionViz>
    {
        [Output(Guid = "63b28d36-719e-4cda-8212-026b707f05b0")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "5b0c0dac-41ff-4765-933c-0c48e0bbd6bd")]
        public readonly InputSlot<BufferWithViews> Points = new InputSlot<BufferWithViews>();

        [Input(Guid = "d950ee58-bb4e-40df-bb1c-e3e27c1e894a")]
        public readonly InputSlot<bool> ShowSpritePlane = new InputSlot<bool>();

        [Input(Guid = "3f19cff4-7364-41c7-a21f-bdb1f969c1bc")]
        public readonly InputSlot<bool> ShowXYRadius = new InputSlot<bool>();

    }
}

