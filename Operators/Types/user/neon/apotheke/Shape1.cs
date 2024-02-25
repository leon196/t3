using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_259bf0ea_448c_4343_895f_c04529b96f8e
{
    public class Shape1 : Instance<Shape1>
    {
        [Output(Guid = "b5ce0b16-40a6-4cb1-b383-4141a9ac31d2")]
        public readonly Slot<Texture2D> ColorBuffer = new Slot<Texture2D>();


    }
}

