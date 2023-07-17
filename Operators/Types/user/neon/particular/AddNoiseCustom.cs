using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_cd2922f5_8d74_41ac_a099_6cb12dc284db
{
    public class AddNoiseCustom : Instance<AddNoiseCustom>
    {

        [Output(Guid = "2ab9995a-db82-4eff-b021-1e9153672c8f")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new Slot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "f1c9236e-d52d-4a47-93bc-8465aca5b5b8")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "c79d7d46-8b87-4ff1-a471-259efe53c194")]
        public readonly InputSlot<float> Amount = new InputSlot<float>();

        [Input(Guid = "b700479b-9d5b-42a0-a87a-5970b97f3008")]
        public readonly InputSlot<float> Frequency = new InputSlot<float>();

        [Input(Guid = "a81d0cd5-2e5f-45d9-bee7-0db5d6a289a4")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "45b07ac9-3ca1-4ee0-948d-6ec9a976f553")]
        public readonly InputSlot<float> Variation = new InputSlot<float>();

        [Input(Guid = "9986bb35-906c-4022-9cbe-020d063f2c18")]
        public readonly InputSlot<System.Numerics.Vector3> AmountDistribution = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "84df57df-2d55-49cd-86fd-259c23680f66")]
        public readonly InputSlot<float> RotationLookupDistance = new InputSlot<float>();

        [Input(Guid = "9807ad92-f18d-47c0-9f6f-ab6baa4fc902")]
        public readonly InputSlot<float> UseWAsWeight = new InputSlot<float>();

        [Input(Guid = "c4e7d0e6-0530-41e6-a2cd-2a60813b5b3e")]
        public readonly InputSlot<System.Numerics.Vector3> NoiseOffset = new InputSlot<System.Numerics.Vector3>();
    }
}

