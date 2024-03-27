using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_26fcfdcc_8fbe_45a8_b9f5_e1dbf85180f2
{
    public class Test : Instance<Test>
    {
        [Output(Guid = "4711aa8e-216e-42c1-ba3e-c4657963a534")]
        public readonly Slot<Command> Output = new Slot<Command>();


    }
}

