using T3.Core.DataTypes;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_170c3a04_c34b_481c_a30d_c2630257e392
{
    public class apotheke : Instance<apotheke>
    {
        [Output(Guid = "70ac4a00-67ff-4d98-b347-feeccfb36677")]
        public readonly Slot<Texture2D> ImgOutput = new();


    }
}

