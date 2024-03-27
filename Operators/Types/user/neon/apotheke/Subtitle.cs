using System;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_b1128ae8_1fa6_476f_a958_eb73047a2b32
{
    public class Subtitle : Instance<Subtitle>
    {
        [Output(Guid = "2c74c341-e5ba-4b13-a2f0-e8ab31d55294")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "7638501e-872d-4e4d-af7c-e4b3ff76748b")]
        public readonly InputSlot<string> InputString = new InputSlot<string>();

        [Input(Guid = "5054a046-2e0d-4285-be6c-3c02901d39cd")]
        public readonly InputSlot<float> Factor = new InputSlot<float>();

    }
}

