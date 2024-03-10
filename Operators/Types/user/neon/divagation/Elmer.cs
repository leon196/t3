using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_700c3d4e_5778_4dee_833f_db7725b27b54
{
    public class Elmer : Instance<Elmer>
    {
        [Output(Guid = "4d2f5922-a086-4e5f-9a92-a261bdc4e513")]
        public readonly Slot<Texture2D> ColorBuffer = new Slot<Texture2D>();


    }
}

