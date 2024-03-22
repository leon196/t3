using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_df926f96_32a3_43c3_95c9_9fba0f766f9e
{
    public class DataCluster : Instance<DataCluster>
    {
        [Output(Guid = "cf826f32-3c9f-49bf-b596-94f2a84b24b1")]
        public readonly Slot<Command> Output = new Slot<Command>();


    }
}

