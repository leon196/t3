using System;
using System.Diagnostics;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_146fae64_18da_4183_9794_a322f47c669e
{
    public class HasValueChanged : Instance<HasValueChanged>
    {
        [Output(Guid = "35ab8188-77a1-4cd9-b2ad-c503034e49f9", DirtyFlagTrigger = DirtyFlagTrigger.Always)]
        public readonly Slot<bool> HasChanged = new Slot<bool>();

        [Output(Guid = "ab818835-77a1-4cd9-b2ad-c503034e49f9")]
        public readonly Slot<float> Delta = new Slot<float>();

        [Output(Guid = "5E37DA80-5D1F-4E17-A0A1-1E386B3A2561")]
        public readonly Slot<float> DeltaOnHit = new Slot<float>();

        
        public HasValueChanged()
        {
            HasChanged.UpdateAction = Update;
            Delta.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var newValue = Value.GetValue(context);
            var threshold = Threshold.GetValue(context);
            var minTimeBetweenHits = MinTimeBetweenHits.GetValue(context);

            var hasChanged = false;
            
            float delta = Math.Abs(newValue - _lastValue);

            switch ((Modes)Mode.GetValue(context).Clamp(0, Enum.GetNames(typeof(Modes)).Length -1))
            {
                case Modes.Changed:
                    var increase = delta > threshold;
                    hasChanged = increase;
                    break;
                
                case Modes.Increased:
                    hasChanged = newValue > _lastValue + threshold;
                    break;
                
                case Modes.Decreased:
                    hasChanged = newValue < _lastValue - threshold;
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var wasTriggered = MathUtils.WasTriggered(hasChanged, ref _wasHit);
            
            if (hasChanged && (PreventContinuedChanges.GetValue(context) || wasTriggered))
            {
                var timeSinceLastHit = context.LocalFxTime - _lastHitTime;
                if (timeSinceLastHit >= minTimeBetweenHits)
                {
                    _lastHitTime = context.LocalFxTime;
                    _lastHitDelta = delta;
                }
                else
                {
                    hasChanged = false;
                }
            }
            
            HasChanged.Value = hasChanged;

            Delta.Value = newValue - _lastValue;
            _lastValue = newValue;
            DeltaOnHit.Value = (float)_lastHitDelta;
        }

        private float _lastValue;
        private double _lastHitTime;
        private float _lastHitDelta;
        private bool _wasHit;

        [Input(Guid = "7f5fb125-8aca-4344-8b30-e7d4e7873c1c")]
        public readonly InputSlot<float> Value = new();

        [Input(Guid = "1e03f11b-f6cc-497e-9528-ed9490e878b5")]
        public readonly InputSlot<float> Threshold = new();

        [Input(Guid = "031ef11b-f6cc-497e-9528-ed9490e878b5", MappedType = typeof(Modes))]
        public readonly InputSlot<int> Mode = new();

        [Input(Guid = "B994249D-C101-41D9-8142-A4F675FCD70C")]
        public readonly InputSlot<float> MinTimeBetweenHits = new();

        [Input(Guid = "8EBF4715-0B4B-4CDD-A079-9F91C2DF0476")]
        public readonly InputSlot<bool> PreventContinuedChanges = new();


        private enum Modes
        {
            Changed,
            Increased,
            Decreased,
        }
    }
}