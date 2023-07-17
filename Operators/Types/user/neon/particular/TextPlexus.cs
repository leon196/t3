using System.Numerics;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7f0f417e_b559_41e5_8b6f_b35acc12525c
{
    public class TextPlexus : Instance<TextPlexus>
    {
        [Output(Guid = "41463b52-8e70-4ec8-abe6-f6e876a514bf")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "054c9842-e645-40dd-b3d4-a93108bbab4c")]
        public readonly InputSlot<Vector4> RGBA = new InputSlot<Vector4>();

        [Input(Guid = "0e47ec3c-317a-4d76-9694-c58c45d51d61")]
        public readonly InputSlot<string> Message = new InputSlot<string>();

        [Input(Guid = "afb645e9-964d-4f30-8621-9e368ced75af")]
        public readonly InputSlot<float> Animation = new InputSlot<float>();

        [Input(Guid = "a618d500-8364-4628-becd-2bb613c965e9")]
        public readonly InputSlot<float> Density = new InputSlot<float>();

    }
}

