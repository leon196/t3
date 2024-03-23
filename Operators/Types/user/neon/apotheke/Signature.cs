using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_bcf70318_ade2_4dad_8fed_82c7ffb618b3
{
    public class Signature : Instance<Signature>
    {

        [Output(Guid = "c28e29ba-27a2-40ef-b2eb-ebabfe63518f")]
        public readonly Slot<T3.Core.DataTypes.Command> Output = new Slot<T3.Core.DataTypes.Command>();

        [Input(Guid = "4659279f-231f-46bb-a4ad-2d73a378900c")]
        public readonly InputSlot<float> Size = new InputSlot<float>();


    }
}

