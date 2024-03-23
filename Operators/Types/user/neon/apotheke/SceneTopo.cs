using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_508d9717_d20f_4493_b90f_28b8390c3bbe
{
    public class SceneTopo : Instance<SceneTopo>
    {
        [Output(Guid = "a7ed5add-97be-4f59-afa0-549d02312585")]
        public readonly Slot<Command> Output = new Slot<Command>();


    }
}

