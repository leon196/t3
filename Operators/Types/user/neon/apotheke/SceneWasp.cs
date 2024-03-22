using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_cc966aa5_cf8a_4522_94a0_f0d0c4849fb5
{
    public class SceneWasp : Instance<SceneWasp>
    {
        [Output(Guid = "8d00fee5-7232-441c-a27b-ba76a76d347a")]
        public readonly Slot<Command> Output = new Slot<Command>();


    }
}

