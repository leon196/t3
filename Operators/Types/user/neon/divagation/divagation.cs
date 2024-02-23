using T3.Core.DataTypes;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b72b6162_ee5b_4a85_b6c2_6c11235a2b6d
{
    public class divagation : Instance<divagation>
    {
        [Output(Guid = "4673adf4-5f99-4110-93b7-cce92972c5a2")]
        public readonly Slot<Texture2D> ImgOutput = new();


    }
}

