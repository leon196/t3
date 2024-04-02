using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b5faf772_bad1_4ca3_b0bd_230d7974667f
{
    public class SceneThoughts : Instance<SceneThoughts>
    {
        [Output(Guid = "f01e2bef-e9d5-438a-9b95-12add7ae1a05")]
        public readonly Slot<Command> Output = new Slot<Command>();


    }
}

