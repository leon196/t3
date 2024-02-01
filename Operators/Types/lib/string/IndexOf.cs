using System;
using System.Collections;
using System.Text.RegularExpressions;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_fc0a5e68_9915_4323_b2a4_2491fa5d59a9
{
    public class IndexOf : Instance<IndexOf>
    {
        [Input(Guid = "841784c4-0ca7-41cd-8d79-bbe4989e0842")]
        public readonly InputSlot<string> OriginalString = new();

        [Input(Guid = "81a7aa30-eab9-4637-bb11-7c0940460afb")]
        public readonly InputSlot<string> SearchPattern = new();

        public IndexOf()
        {
            Index.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            string searchPattern = SearchPattern.GetValue(context);
            if (string.IsNullOrEmpty(searchPattern))
            {
                Index.Value = -1;
                return;
            }
            string originalString = OriginalString.GetValue(context);
            Index.Value = originalString.IndexOf(searchPattern);
        }

        [Output(Guid = "4bb4bb23-4c3f-4d7d-9dab-c37ac63dd1c9")]
        public readonly Slot<int> Index = new Slot<int>();
    }
}