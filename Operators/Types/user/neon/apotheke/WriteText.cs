using System;
using System;
using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7e1a2724_f019_43e0_9150_8209edc4129f
{
    public class WriteText : Instance<WriteText>
    {
        [Output(Guid = "1768384d-46a0-4c29-9dc3-a9c54636840c")]
        public readonly Slot<string> Fragments = new Slot<string>();

        [Input(Guid = "be28f90b-1a33-4baf-b4a1-bec9ba427236")]
        public readonly InputSlot<string> InputString = new InputSlot<string>();

        [Input(Guid = "a06ba7e6-cbfd-45df-9ec7-db413d507269")]
        public readonly InputSlot<float> Factor = new InputSlot<float>();

    }
}

