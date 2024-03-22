using SharpDX.Direct3D11;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_a16eb761_9b6b_4dc5_955d_7279f68c2c0c
{
    public class GlowSoft : Instance<GlowSoft>
    {
        [Output(Guid = "b92633d5-a659-467c-8d70-fa90d095fc0e")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();

        [Input(Guid = "6cafdcf5-43a3-4ade-bcb5-3a1c5defca15")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Image = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "bfe1a638-083c-44cf-aeea-e69f557c4bab")]
        public readonly InputSlot<System.Numerics.Vector4> Add = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "11b3db59-2cc1-4d7f-aa05-172f755b45d0")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

    }
}

