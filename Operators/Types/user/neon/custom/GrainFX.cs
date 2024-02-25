using SharpDX.Direct3D11;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6f0ea2d3_3b3c_484b_af17_0753f2dca101
{
    public class GrainFX : Instance<GrainFX>
    {
        [Output(Guid = "c1965e92-6459-4c16-83bd-a8ee811e1e88")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "417a44e1-2478-4d9c-b6ec-8206d3f60aa7")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> InputImage = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "73e19b2a-11a5-4d27-b6bd-e703f9ea2bab")]
        public readonly InputSlot<System.Numerics.Vector4> ColorB = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "db536891-a6c5-42c1-bdfa-5d833cba04a5")]
        public readonly InputSlot<float> Radius = new InputSlot<float>();

        [Input(Guid = "e5d47a6a-78cf-4563-b486-a9187d3ebab8")]
        public readonly InputSlot<float> Intensity = new InputSlot<float>();

    }
}

