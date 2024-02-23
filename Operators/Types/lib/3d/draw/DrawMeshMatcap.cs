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

namespace T3.Operators.Types.Id_834031f7_9e1d_4b7b_beaa_4f4d98c679c7
{
    public class DrawMeshMatcap : Instance<DrawMeshMatcap>
,ICustomDropdownHolder,ICompoundWithUpdate
    {
        [Output(Guid = "658ea4db-25a7-4b43-8434-4ba4f553325d")]
        public readonly Slot<Command> Output = new();
        
        
        public DrawMeshMatcap()
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
        

        [Input(Guid = "ef784879-ce0d-4e2b-ad87-bed655386a6a")]
        public readonly InputSlot<T3.Core.DataTypes.MeshBuffers> Mesh = new InputSlot<T3.Core.DataTypes.MeshBuffers>();

        [Input(Guid = "987f688c-718a-4c0a-a8b7-a36aadef2608")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "cfe5f7d8-0eca-40ee-a1c6-298a1d7b5b51")]
        public readonly InputSlot<float> AlphaCutOff = new InputSlot<float>();

        [Input(Guid = "e9910902-47d0-4c3a-918b-922c50a95336", MappedType = typeof(SharedEnums.BlendModes))]
        public readonly InputSlot<int> BlendMode = new InputSlot<int>();

        [Input(Guid = "7523f691-1947-4512-a178-e0fb0135c4e4", MappedType = typeof(FillMode))]
        public readonly InputSlot<int> FillMode = new InputSlot<int>();

        [Input(Guid = "ef3e59dc-39aa-4055-8d98-309783f2f346")]
        public readonly InputSlot<SharpDX.Direct3D11.CullMode> Culling = new InputSlot<SharpDX.Direct3D11.CullMode>();

        [Input(Guid = "d6345502-be9d-4b92-ad4e-e5edfc7e0eaf")]
        public readonly InputSlot<bool> EnableZTest = new InputSlot<bool>();

        [Input(Guid = "95c9131b-0b3b-434b-95d4-853b314284e7")]
        public readonly InputSlot<bool> EnableZWrite = new InputSlot<bool>();

        [Input(Guid = "b69b41a5-0ffd-42f7-82bd-cbce780a459c")]
        public readonly InputSlot<SharpDX.Direct3D11.Filter> Filter = new InputSlot<SharpDX.Direct3D11.Filter>();

        [Input(Guid = "dd917ed0-597c-4489-a38b-e6f2b04cac93")]
        public readonly InputSlot<SharpDX.Direct3D11.TextureAddressMode> WrapMode = new();
        
        [Input(Guid = "26315814-c764-4492-a48a-b5accce5eef3")]
        public readonly InputSlot<string> UseMaterialId = new ();


    }
}

