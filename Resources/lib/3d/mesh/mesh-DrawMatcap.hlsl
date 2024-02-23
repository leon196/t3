#include "lib/shared/point.hlsl"
#include "lib/shared/quat-functions.hlsl"
#include "lib/shared/point-light.hlsl"
#include "lib/shared/pbr.hlsl"

cbuffer Transforms : register(b0)
{
    float4x4 CameraToClipSpace;
    float4x4 ClipSpaceToCamera;
    float4x4 WorldToCamera;
    float4x4 CameraToWorld;
    float4x4 WorldToClipSpace;
    float4x4 ClipSpaceToWorld;
    float4x4 ObjectToWorld;
    float4x4 WorldToObject;
    float4x4 ObjectToCamera;
    float4x4 ObjectToClipSpace;
};

cbuffer Params : register(b1)
{
    float4 Color;
    float AlphaCutOff;
    float Debug;
};

cbuffer FogParams : register(b2)
{
    float4 FogColor;
    float FogDistance;
    float FogBias;
}

cbuffer PointLights : register(b3)
{
    PointLight Lights[8];
    int ActiveLightCount;
}

cbuffer PbrParams : register(b4)
{
    float4 BaseColor;
    float4 EmissiveColor;
    float Roughness;
    float Specular;
    float Metal;
}

struct psInput
{
    float2 texCoord : TEXCOORD;
    float4 pixelPosition : SV_POSITION;
    float3 worldPosition : POSITION;
    float3x3 tbnToWorld : TBASIS;
    float fog : VPOS;
};

sampler texSampler : register(s0);
sampler linearSampler : register(s1);
sampler clampedSampler : register(s2);


StructuredBuffer<PbrVertex> PbrVertices : register(t0);
StructuredBuffer<int3> FaceIndices : register(t1);

Texture2D<float4> BaseColorMap : register(t2);
Texture2D<float4> EmissiveColorMap : register(t3);
Texture2D<float4> RSMOMap : register(t4);
Texture2D<float4> NormalMap : register(t5);

TextureCube<float4> PrefilteredSpecular : register(t6);
Texture2D<float4> BRDFLookup : register(t7);

psInput vsMain(uint id: SV_VertexID)
{
    psInput output;

    int faceIndex = id / 3; //  (id % verticesPerInstance) / 3;
    int faceVertexIndex = id % 3;

    PbrVertex vertex = PbrVertices[FaceIndices[faceIndex][faceVertexIndex]];

    float4 posInObject = float4(vertex.Position, 1);

    float4 posInClipSpace = mul(posInObject, ObjectToClipSpace);
    output.pixelPosition = posInClipSpace;

    float2 uv = vertex.TexCoord;
    output.texCoord = float2(uv.x, 1 - uv.y);

    // Pass tangent space basis vectors (for normal mapping).
    float3x3 TBN = float3x3(vertex.Tangent, vertex.Bitangent, vertex.Normal);
    TBN = mul(TBN, (float3x3)ObjectToWorld);

    output.tbnToWorld = float3x3(
        normalize(TBN._m00_m01_m02),
        normalize(TBN._m10_m11_m12),
        normalize(TBN._m20_m21_m22));

    output.worldPosition = mul(posInObject, ObjectToWorld).xyz;

    // Fog
    if (FogDistance > 0)
    {
        float4 posInCamera = mul(posInObject, ObjectToCamera);
        float fog = pow(saturate(-posInCamera.z / FogDistance), FogBias);
        output.fog = fog;
    }

    return output;
}

float3 triplanar (Texture2D<float4> map, float3 position, float3 normal, float scale)
{
    // Blending factor of triplanar mapping
    float3 bf = normalize(abs(normal));
    bf /= dot(bf, (float3)1);

    // Triplanar mapping
    float2 tx = position.yz * scale;
    float2 ty = position.zx * scale;
    float2 tz = position.xy * scale;

    // Base color
    half4 cx = map.Sample(texSampler, tx) * bf.x;
    half4 cy = map.Sample(texSampler, ty) * bf.y;
    half4 cz = map.Sample(texSampler, tz) * bf.z;
    
    // return cx + cy + cz;
    return max(cx, max(cy, cz));
}

float4 psMain(psInput pin) : SV_TARGET
{
    float3 normalMap = NormalMap.Sample(texSampler, pin.texCoord);
    // float3 normalMap = triplanar(NormalMap, pin.worldPosition, pin.tbnToWorld[2].xyz, 1);
    normalMap = normalize(2.0 * normalMap.rgb - 1.0);
    float3 normal = normalize(mul(normalMap, pin.tbnToWorld));
    normal = normalize(mul(normal, WorldToCamera));
    float2 uv = normal.xy*.5+.5;
    uv.y = 1.-uv.y;
    return BaseColorMap.Sample(texSampler, uv);
}
