using T3.Core.DataTypes;
using SharpDX.Direct3D11;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_204b76fe_b909_44bc_a057_0ba64a38792b
{
    public class postfx : Instance<postfx>
    {
        [Output(Guid = "51267e7a-5b8b-42e9-96db-75a04086a65f")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();


        [Input(Guid = "dd13061b-01d5-4654-89c5-c65db5442ccb")]
        public readonly MultiInputSlot<Texture2D> Input = new MultiInputSlot<Texture2D>();

    }
}

