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
    if(i >= numStructs) {    
        return;
    }

    float f = (float)i / numStructs;
    Point p = ResultPoints[i];
    Point q = SourcePoints[i];
    // q.Position.xy = q.Position.xy * 2. + .5;

    float dt = D;
    float2 grid = 9.;
    float t = floor(A);

    float row = floor(p.Position.y * grid.y) + 5;

    row = row - floor(hash11(t)*grid.y);

    float select = 1-saturate(abs(row));

    p.Position.x += 1 * dt * select;
    p.Position.x = frac(p.Position.x);

    bool reset = C > 0.5;
    if (reset)
    {
        p = q;
    }

    ResultPoints[i] = p;
}