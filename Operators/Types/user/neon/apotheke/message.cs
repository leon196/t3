using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_ed058bea_1fd4_4613_b68e_4d62abe4b77c
{
    public class message : Instance<message>
    {
        [Output(Guid = "1253e1a6-5100-4171-abed-298bd4bacc91")]
        public readonly Slot<Command> Output = new Slot<Command>();


    }
}

