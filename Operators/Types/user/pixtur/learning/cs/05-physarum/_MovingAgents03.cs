using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_8a3791db_8221_484b_8a0e_4e22399cdd9c
{
    public class _MovingAgents03 : Instance<_MovingAgents03>
    {
        [Output(Guid = "b266dc79-476b-4faa-8b6f-4382b608d963")]
        public readonly Slot<Texture2D> ImgOutput = new Slot<Texture2D>();

        [Input(Guid = "20f5239b-bf6c-4461-b4b2-f50dc007b991")]
        public readonly InputSlot<float> RestoreLayout = new InputSlot<float>();

        [Input(Guid = "8f30b692-671d-4af3-8985-ab84ee095bba")]
        public readonly InputSlot<bool> RestoreLayoutEnabled = new InputSlot<bool>();

        [Input(Guid = "0bd3ead6-cba8-4fb3-8e0c-8da63792441c")]
        public readonly InputSlot<bool> ShowAgents = new InputSlot<bool>();

        [Input(Guid = "41f2d06d-b7f6-48d0-a3bf-be782d724d97")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "5daa9f83-08b0-4e4f-8be5-c86385a74675")]
        public readonly InputSlot<int> AgentCount = new InputSlot<int>();

        [Input(Guid = "1bfab25b-b759-4bba-ad85-39a29d5fbd99")]
        public readonly InputSlot<int> ComputeSteps = new InputSlot<int>();

        [Input(Guid = "260e410e-dc4a-4790-92b2-6cad592239e3")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> BreedsBuffer = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "82513aa2-96db-4667-8f75-27d175c3cbd8")]
        public readonly InputSlot<System.Numerics.Vector4> DecayRatio = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "fe682c44-28d8-4013-bb63-8dfbe1eacf0b")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> EffectTexture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "d360cb06-7bff-499b-aeec-5314f53e8ddf")]
        public readonly InputSlot<SharpDX.Size2> BlockCount = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "9b8ccfb8-2dbf-4e6f-8b69-db4667e6b448")]
        public readonly InputSlot<float> AngleLockSteps = new InputSlot<float>();

        [Input(Guid = "380b5eb2-3bee-46b1-986d-201cbe687236")]
        public readonly InputSlot<float> AngleLockFactor = new InputSlot<float>();


    }
}
