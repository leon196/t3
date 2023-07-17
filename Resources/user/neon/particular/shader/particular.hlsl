#include "lib/shared/hash-functions.hlsl"
#include "lib/shared/noise-functions.hlsl"
#include "lib/shared/point.hlsl"

cbuffer Params : register(b0)
{
    float3 Phase;   // Note that float3 vectors have to be aligned to 16 byte borders 
    float Amount;
}

StructuredBuffer<Point> SourcePoints : t0;        
RWStructuredBuffer<Point> ResultPoints : u0;   

[numthreads(64,1,1)]
void main(uint3 DTid : SV_DispatchThreadID)
{
    uint i = DTid.x;
    uint pointCount, _;
    SourcePoints.GetDimensions(pointCount, _);
    if(i >= pointCount) return;

    Point p = SourcePoints[i];
    
    

    ResultPoints[i] = p;
}