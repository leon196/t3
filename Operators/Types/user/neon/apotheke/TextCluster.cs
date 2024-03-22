using System;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_ba054103_b58e_4db8_ab92_9560458c036b
{
    public class TextCluster : Instance<TextCluster>
    {
        [Output(Guid = "a43edb7e-1312-40a3-bc01-345441402840")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "5081ee61-a75c-4d27-9c34-cfb7c56a8f43")]
        public readonly InputSlot<string> Text = new InputSlot<string>();

        [Input(Guid = "0d86d532-0d72-4852-a546-10634a1eb402")]
        public readonly InputSlot<float> Rate = new InputSlot<float>();

        [Input(Guid = "dfb34c7a-7510-4758-a082-3311f627f1c7")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

    }
}

