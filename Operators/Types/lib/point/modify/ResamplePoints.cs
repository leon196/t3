using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.DataTypes;
using T3.Core.Logging;

using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace T3.Operators.Types.Id_0b300208_38a4_4cdb_800a_0da6c22e58d8
{
    public class ResamplePoints : Instance<ResamplePoints>
    {

        [Input(Guid = "e766c59b-26ed-496a-aa25-834da7f51119")]
        public readonly InputSlot<float> Range = new InputSlot<float>();

        [Input(Guid = "6b04307f-4131-464f-b1dc-2de1e8ec17f9")]
        public readonly InputSlot<StructuredList> InputList = new InputSlot<StructuredList>();

        public ResamplePoints()
        {
            OutputList.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            StructuredList<Point> inputList = (StructuredList<Point>)InputList.GetValue(context);
            float range = Range.GetValue(context);

            // check for data
            if (inputList == null || inputList.NumElements == 0 || range <= 0.001f) return;

            Point[] array = inputList.TypedElements;
            List<Point> points = new();
            Vector3 pos = array[0].Position;
            int count = inputList.NumElements;
            float dist = 100000f;

            for (int i = 1; i < count; i++)
            {
                Point next = array[i%count];
                if (float.IsNaN(next.W))
                {
                    points.Add(GetPoint(pos));
                    points.Add(Point.Separator());
                    pos = array[(i+1)%count].Position;
                    i += 1;
                    continue;
                }
                while (dist > range)
                {
                    points.Add(GetPoint(pos));
                    Vector3 v = next.Position-pos;
                    Vector3 dir = Vector3.Normalize(v);
                    pos += dir * MathF.Min(range, v.Length());
                    dist = Vector3.Distance(pos, next.Position);
                }
                // points.Add(GetPoint(next.Position));
                pos = next.Position;
                dist = 10000f;
            }

            // output list
            StructuredList<Point> outputList = new StructuredList<Point>(points.Count);
            for (int index = 0; index < points.Count; index++) outputList.TypedElements[index] = points[index];
            OutputList.Value = outputList;
        }

        Point GetPoint (Vector3 p)
        {
            return new Point
            {
                Position = p,
                W = 1f,
                Orientation = new Quaternion(0f, 0f, 0f, 1f),
                Color = new Vector4(1f, 1f, 1f, 1f)
            };
        }

        [Output(Guid = "7197e73e-2770-4388-9f0f-c753212565bb")]
        public readonly Slot<StructuredList> OutputList = new Slot<StructuredList>();
    }
}

