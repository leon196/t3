using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_cb3610e4_981f_4220_88ee_7e47c485fecc
{
    public class Timestamp : Instance<Timestamp>
    {
        [Output(Guid = "9b9ef043-e22f-49a9-a885-827260b9ec63")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "48a7ca3b-50a3-4df4-a740-a34f79960001")]
        public readonly InputSlot<float> Size = new InputSlot<float>();


    }
}

