using System;
using System.Collections.Generic;
using SharpDX.Direct3D11;
using T3.Core.DataTypes;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Interfaces;
using T3.Core.Operator.Slots;
using T3.Core.Rendering.Material;

namespace T3.Operators.Types.Id_0d822679_126b_45b8_bb1f_41034b26a04a
{
    public class DrawMeshSmear : Instance<DrawMeshSmear>
,ICustomDropdownHolder,ICompoundWithUpdate
    {
        [Output(Guid = "990d497e-3304-4572-a125-edf4a251a07a")]
        public readonly Slot<Command> Output = new();
        
        
        public DrawMeshSmear()
        {
            Output.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            if (context.Materials != null)
            {
                _pbrMaterials.Clear();
                _pbrMaterials.AddRange(context.Materials);
            }

            var previousMaterial = context.PbrMaterial;
            
            var materialId = UseMaterialId.GetValue(context);
            if (!string.IsNullOrEmpty(materialId))
            {
                foreach(var m in context.Materials)
                {
                    if (m.Name != materialId)
                        continue;
                    
                    context.PbrMaterial = m;
                    break;

                }
            }
            
            // Inner update
            Output.ConnectedUpdate(context);
            context.PbrMaterial = previousMaterial;
        }

        #region custom material dropdown
        string ICustomDropdownHolder.GetValueForInput(Guid inputId)
        {
            return inputId != UseMaterialId.Input.InputDefinition.Id 
                       ? "Undefined input" 
                       : UseMaterialId.TypedInputValue.Value;
        }

        IEnumerable<string> ICustomDropdownHolder.GetOptionsForInput(Guid inputId)
        {
            yield return "Default";
            
            if(_pbrMaterials == null)
                yield break;

            foreach (var m in _pbrMaterials)
            {
                yield return string.IsNullOrEmpty(m.Name) ? "undefined" : m.Name;
            }
        }

        void ICustomDropdownHolder.HandleResultForInput(Guid inputId, string result)
        {
            if (inputId != UseMaterialId.Input.InputDefinition.Id)
                return;
            
            UseMaterialId.SetTypedInputValue(result);
        }

        private readonly List<PbrMaterial> _pbrMaterials = new(8);
        #endregion
        

        [Input(Guid = "d3a2e88e-0260-4805-b699-57fb0b32b467")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();

        [Input(Guid = "f0ff3517-16f0-4fc3-8f71-b64873b89e98")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "18263827-c27b-46bc-bc97-d868628467db")]
        public readonly InputSlot<float> AlphaCutOff = new InputSlot<float>();

        [Input(Guid = "d3d323f5-815b-4515-a4ad-ceb3a57192e1", MappedType = typeof(SharedEnums.BlendModes))]
        public readonly InputSlot<int> BlendMode = new InputSlot<int>();

        [Input(Guid = "8e7471a8-a0a6-41be-86e3-42f1f029d81f", MappedType = typeof(FillMode))]
        public readonly InputSlot<int> FillMode = new InputSlot<int>();

        [Input(Guid = "67dc7a52-3c00-4aef-8358-c89a368e9faf")]
        public readonly InputSlot<SharpDX.Direct3D11.CullMode> Culling = new InputSlot<SharpDX.Direct3D11.CullMode>();

        [Input(Guid = "0f0e5510-71be-4b2d-8417-de2fbe2024d9")]
        public readonly InputSlot<bool> EnableZTest = new InputSlot<bool>();

        [Input(Guid = "32048f07-2191-424d-80d3-09affc75210b")]
        public readonly InputSlot<bool> EnableZWrite = new InputSlot<bool>();

        [Input(Guid = "b97f3835-05ef-4aad-aa5a-940d589765a1")]
        public readonly InputSlot<SharpDX.Direct3D11.Filter> Filter = new InputSlot<SharpDX.Direct3D11.Filter>();

        [Input(Guid = "a8111b23-2480-4ad3-816e-ce97da2edbec")]
        public readonly InputSlot<SharpDX.Direct3D11.TextureAddressMode> WrapMode = new();
        
        [Input(Guid = "f566ff24-e93b-496b-a2f9-1dfcbe39f4ef")]
        public readonly InputSlot<string> UseMaterialId = new ();


    }
}

