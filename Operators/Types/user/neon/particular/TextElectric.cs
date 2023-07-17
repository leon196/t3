using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_69f9b5bb_fe0c_4a34_bd96_5fb4db928807
{
    public class TextElectric : Instance<TextElectric>
    {
        [Output(Guid = "4a823e9a-2e09-45e6-b94f-3c99038254e0")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "c341abf4-4697-493f-84ea-08a2753b1327")]
        public readonly InputSlot<Vector4> RGBA = new InputSlot<Vector4>();

    }
}

