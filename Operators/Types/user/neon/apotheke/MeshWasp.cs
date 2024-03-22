using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_54708593_dae4_423e_a4fd_6e4221983af1
{
    public class MeshWasp : Instance<MeshWasp>
    {
        [Output(Guid = "c116e2ae-14db-4b55-bb0b-795ab36f3675")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "dc1e6911-ad86-4687-bec6-d1a5585176fd")]
        public readonly InputSlot<System.Numerics.Vector3> Translation = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "269b912b-d40b-499e-8487-3b078dffed11")]
        public readonly InputSlot<System.Numerics.Vector3> Rotation = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "1dce9910-6855-4a10-9ce9-4545c57a7158")]
        public readonly InputSlot<float> UniformScale = new InputSlot<float>();

        [Input(Guid = "b719841a-ff8c-4e56-86f7-b0aa1a36da47")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();


    }
}

