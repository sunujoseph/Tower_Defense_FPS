Shader "Custom/Diffuse"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
    }
        SubShader{
          Tags { "RenderType" = "Opaque" }
          CGPROGRAM
          #pragma surface surf Lambert

             fixed4 _Color;
          struct Input {
              float2 uv_MainTex;
          };

          sampler2D _MainTex;

          void surf(Input IN, inout SurfaceOutput o) {
              o.Albedo = _Color.rgb;
          }
          ENDCG
    }
        Fallback "Diffuse"

}
