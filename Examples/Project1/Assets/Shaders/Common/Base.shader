[[vk::image_format("rgba8")]]
RWBuffer<float4> Buf;

Texture2D texture2D42l;

[[vk::image_format("rg16f")]]
RWTexture2D<float2> Tex;

RWTexture2D<float2> Tex2; // Works like before

struct aasdf {
  float4x4 foobar;
};
[[vk::binding(2,2)]] ConstantBuffer<aasdf> u_aasdf;
