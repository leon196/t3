using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_9fa11d52_7bac_4552_bd0c_548c13f7cbd4
{
    public class ResampleLinePoints2 : Instance<ResampleLinePoints2>
    {

        [Output(Guid = "812cc2f8-a049-4922-b7db-5b85eec4f105")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> Output = new();

        [Input(Guid = "403babe1-781e-4104-8edb-4e537aa2c586")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> Points = new();

        [Input(Guid = "889c41ca-e7da-4b7d-9b89-593134168a97")]
        public readonly InputSlot<int> Count = new();

        [Input(Guid = "6431c1c4-8598-4426-affe-5921702732c4")]
        public readonly InputSlot<float> SmoothDistance = new();

        [Input(Guid = "0e68da48-4dd4-4c75-a24d-7d274b289e3c", MappedType = typeof(SampleModes))]
        public readonly InputSlot<int> SampleMode = new();

        [Input(Guid = "acc18ab3-2454-4a2a-8a77-31f06c75c72c")]
        public readonly InputSlot<System.Numerics.Vector2> SampleRange = new();


        private enum SampleModes
        {
            StartEnd,
            StartLength,
        }
    }
}

