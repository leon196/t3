#include "lib/shared/hash-functions.hlsl"
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
void main(uint3 DTId : SV_DispatchThreadID)
{
    uint i = DTId.x;
    uint numStructs, stride;
    SourcePoints.GetDimensions(numStructs, stride);
    if(i+1 >= numStructs) {    
        return;
    }

    float f = (float)i / numStructs;
    // if (i % )
    Point p = SourcePoints[D > 0 ? floor(hash11(i+C)*numStructs) : i + 1];
    Point q = SourcePoints[i];
    // Point q = SourcePoints[i + 1];
    // if (i % 2 == 1) q = SourcePoints[i - 1];

    float dist = length(q.position - p.position);
    p.w *= smoothstep(A,0,dist-B);
    // p.rotation.w = smoothstep(A,0,dist-B);
    // if (i % 2 == 1) p.rotation.w = SourcePoints[i+1].w;
    // p.w = i % 2;
    // p.w = max(0, p.w);
    // if (p.w == 0) p.w = sqrt(-1);

    ResultPoints[i] = p;
}
