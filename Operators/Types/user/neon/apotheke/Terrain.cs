using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_718055d9_617f_4eca_929f_a081d0c25ed0
{
    public class Terrain : Instance<Terrain>
    {
        [Output(Guid = "ffc4040e-58ab-4494-bd1f-b3036278adfb")]
        public readonly Slot<Texture2D> Output = new Slot<Texture2D>();


    }
}

