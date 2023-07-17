using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.DataTypes;
using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_aa4f9310_4751_4d41_ad59_8e113a56f83e
{
    public class DrawSegment : Instance<DrawSegment>
    {
        [Output(Guid = "897b8861-3457-4640-a6eb-9fd585363a2c")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "39db4b7c-51ed-43ab-9579-e1681a3cf3ba")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "fdae9128-831b-41a0-af71-5057b2ab4b4a")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "a8ec24ef-b07a-42ec-97fd-1ab14a013a06")]
        public readonly InputSlot<float> RandomAmount = new InputSlot<float>();

        [Input(Guid = "4489d9c9-abad-4520-b6be-eb8167adbc25")]
        public readonly InputSlot<bool> Branch = new InputSlot<bool>();

    }
}

