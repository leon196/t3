using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.DataTypes;
using T3.Core.Logging;
using T3.Core.Resource;
using T3.Core.DataTypes.Vector;
using T3.Core.Rendering;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Drawing.Text;
using SharpDX.Direct3D11;
using Buffer = SharpDX.Direct3D11.Buffer;

// using SixLabors.Fonts;
// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.Drawing.Text;
// using SixLabors.ImageSharp.Drawing;

using VectSharp;

namespace T3.Operators.Types.Id_bdb41a6d_e225_4a8a_8348_820d45153e3f
{
    public class TextPoints : Instance<TextPoints>
    {

        [Input(Guid = "7432f063-9957-47f7-8250-c3e6456ec7c6")]
        public readonly InputSlot<string> InputText = new InputSlot<string>();

        [Input(Guid = "abe3f777-a33b-4e39-9eee-07cc729acf32")]
        public readonly InputSlot<string> InputFont = new InputSlot<string>();

        private Buffer _vertexBuffer;
        private PbrVertex[] _vertexBufferData = new PbrVertex[0];
        private readonly BufferWithViews _vertexBufferWithViews = new();

        private Buffer _indexBuffer;
        private Int3[] _indexBufferData = new Int3[0];
        private readonly BufferWithViews _indexBufferWithViews = new();

        private readonly MeshBuffers _data = new();

        public TextPoints()
        {
            OutputMesh.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            string inputText = InputText.GetValue(context);
            string inputFont = InputFont.GetValue(context);

            if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(inputFont))
            {
                return;
            }

            if (!File.Exists(inputFont))
            {
                Log.Debug($"File {inputFont} doesn't exist", this);
                return;
            }

            // PrivateFontCollection collection = new PrivateFontCollection();
            // collection.AddFontFile(inputFont);


            // FontFamily fontFamily = new FontFamily(@"D:\Projects\T3\t3\Resources\fonts\TeknoTwo.ttf");
            // FontFamily family = collection.Families[0];

            FontFamily family = FontFamily.ResolveFontFamily(FontFamily.StandardFontFamilies.Helvetica);
            // FontFamily family = FontFamily
            Font font = new Font(family, 15);
            GraphicsPath path = new GraphicsPath().AddText(15, 8, "VectSharp", font);
            GraphicsPath[] triangles = path.Triangulate(2, true).ToArray();
            
            int totalVertexCount = triangles.Length * 3;
            int totalTriangleCount = triangles.Length;

            // Create buffers
            if (_vertexBufferData.Length != totalVertexCount)
                _vertexBufferData = new PbrVertex[totalVertexCount];

            if (_indexBufferData.Length != totalTriangleCount)
                _indexBufferData = new Int3[totalTriangleCount];

            for (int i = 0; i < triangles.Length; i++)
            {
                List<Segment> segments = triangles[i].Segments;
                _indexBufferData[i] = new Int3(i*3, i*3+1, i*3+2);
                for (int t = 0; t < 3; t++)
                {
                    var pf = segments[t].Point;
                    Vector3 p = new Vector3((float)pf.X, (float)pf.Y, 0f);
                    _vertexBufferData[i*3+t] = new PbrVertex
                    {
                        Position = p,
                        Normal = Vector3.UnitZ,
                        Tangent = Vector3.UnitX,
                        Bitangent = Vector3.UnitY,
                        Texcoord = Vector2.Zero,
                        Selection = 1
                    };
                }
            }

            // Write Data
            ResourceManager.SetupStructuredBuffer(_vertexBufferData, PbrVertex.Stride * totalVertexCount, PbrVertex.Stride, ref _vertexBuffer);
            ResourceManager.CreateStructuredBufferSrv(_vertexBuffer, ref _vertexBufferWithViews.Srv);
            ResourceManager.CreateStructuredBufferUav(_vertexBuffer, UnorderedAccessViewBufferFlags.None, ref _vertexBufferWithViews.Uav);
            _vertexBufferWithViews.Buffer = _vertexBuffer;

            const int stride = 3 * 4;
            ResourceManager.SetupStructuredBuffer(_indexBufferData, stride * totalTriangleCount, stride, ref _indexBuffer);
            ResourceManager.CreateStructuredBufferSrv(_indexBuffer, ref _indexBufferWithViews.Srv);
            ResourceManager.CreateStructuredBufferUav(_indexBuffer, UnorderedAccessViewBufferFlags.None, ref _indexBufferWithViews.Uav);
            _indexBufferWithViews.Buffer = _indexBuffer;

            _data.VertexBuffer = _vertexBufferWithViews;
            _data.IndicesBuffer = _indexBufferWithViews;
            OutputMesh.Value = _data;
            OutputMesh.DirtyFlag.Clear();

            // FontCollection collection = new();
            // FontFamily family = collection.Add(inputFont);
            // Font font = family.CreateFont(12);
            // TextOptions textOptions = new(font);
            // IPathCollection paths = TextBuilder.GenerateGlyphs(inputText, textOptions);
            // List<Point> points = new List<Point>();
            // ComplexPolygon poly = new ComplexPolygon(paths);
            // foreach (var path in paths)
            // {
            //     // path.
            //     var p = path.Flatten();
            //     foreach (var q in p)
            //     {
            //         for (int i = 0; i < q.Points.Length; ++i)
            //         {

            //             PointF pp = q.Points.Span[i];
            //             Point ppp = new Point();

            //             Vector3 pos = new Vector3(pp.X , 1 - pp.Y, 0f);
            //             ppp.Position = pos;
            //             ppp.W = 1f;
            //             ppp.Orientation = new Quaternion(0f, 0f, 0f, 1f);
            //             ppp.Color = new Vector4(1f, 1f, 1f, 1f);

            //             points.Add(ppp);
            //         }
            //     }
            // }

            // if (points.Count == 0) return;

            // StructuredList<Point> list = new StructuredList<Point>(points.Count);
            // for (int index = 0; index < points.Count; index++)
            // {
            //     list.TypedElements[index] = points[index];
            // }
            // OutputList.Value = list;
        }

        [Output(Guid = "c65da6e8-3eb7-4152-9b79-34fcaaa31807")]
        public readonly Slot<StructuredList> OutputList = new Slot<StructuredList>();

        [Output(Guid = "ec159313-220f-45ef-9694-d0c7bbf24194")]
        public readonly Slot<MeshBuffers> OutputMesh = new Slot<MeshBuffers>();
    }
}

