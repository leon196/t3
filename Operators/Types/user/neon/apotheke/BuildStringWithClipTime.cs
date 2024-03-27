using System;
using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7c9bdd47_6453_46f4_909b_efc0335dac9a
{
    public class BuildStringWithClipTime : Instance<BuildStringWithClipTime>
    {
        [Output(Guid = "612a1529-81f9-4452-a8ac-c4b9eae50bb2")]
        public readonly Slot<string> Fragments = new Slot<string>();


        [Input(Guid = "86b83cc1-fe2e-4a22-9707-8da59d89ae5f")]
        public readonly InputSlot<string> InputString = new InputSlot<string>();

    }
}

