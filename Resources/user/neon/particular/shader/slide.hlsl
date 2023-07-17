#include "lib/shared/hash-functions.hlsl"
#include "lib/shared/noise-functions.hlsl"
#include "lib/shared/point.hlsl"

cbuffer Params : register(b1)
{
    float3 Center;
    float A;
    float B;
    float C;
    float D;
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

    float time = A;
    float index = floor(A)+i;
    float blend = frac(A);
    float ia = index % pointCount;
    float ib = (index+1) % pointCount;
    float iaa = (index-1+pointCount) % pointCount;
    float ibb = (index+2) % pointCount;
    Point pa = SourcePoints[ia];
    Point pb = SourcePoints[ib];
    Point paa = SourcePoints[iaa];
    Point pbb = SourcePoints[ibb];
    p.position = lerp(pa.position, pb.position, blend);
    p.w *= !isnan(pa.w) * !isnan(pb.w);
    p.w *= isnan(paa.w) ? blend : isnan(pbb.w) ? 1 - blend : 1;
    // p.position.y += sin(A);
    ResultPoints[i] = p;
}