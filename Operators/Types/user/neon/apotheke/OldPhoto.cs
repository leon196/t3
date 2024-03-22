using SharpDX.Direct3D11;
using SharpDX.Direct3D11;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_590b40aa_17cc_41c8_b5c5_13f52325797a
{
    public class OldPhoto : Instance<OldPhoto>
    {
        [Output(Guid = "ebaf0c0a-3a75-4313-85a7-eabf8edabfb0")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "5537c9d5-3710-4f51-a67a-6e14a9f9618a")]
        public readonly InputSlot<Texture2D> Texture2d = new InputSlot<Texture2D>();

        [Input(Guid = "e4edb515-9bb5-47c8-b9df-e9cb9ee564fd")]
        public readonly InputSlot<float> Contrast = new InputSlot<float>();

        [Input(Guid = "3a7c8478-c1f9-49ee-855e-ecf786f32106")]
        public readonly InputSlot<float> Exposure = new InputSlot<float>();

    }
}

