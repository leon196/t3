using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_5f381544_0b6d_4e78_802a_c959c9686836
{
    public class DetectEdgesExample : Instance<DetectEdgesExample>
    {
        [Output(Guid = "333ed097-27f7-4ffa-b1c3-3d6c20cd25ac")]
        public readonly Slot<Texture2D> TextureOutput = new();


    }
}

