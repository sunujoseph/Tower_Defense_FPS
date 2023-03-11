Shader "Custom/Decal"
{
    Properties
    {

        _MainTex("MainTex", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _DecalTex("Decal", 2D) = "white" {}
        [Toggle] _ShowDecal("ShowDecal?", Float) = 0

    }
        SubShader
        {
            Tags { "Queue" = "Geometry" }

            CGPROGRAM

            #pragma surface surf Lambert

            sampler2D _MainTex;
            fixed4 _Color;
            sampler2D _DecalTex;
            float _ShowDecal;

            struct Input
            {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                // Albedo comes from a texture tinted by color
                fixed4 a = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                //fixed4 b = tex2D (_DecalTex, IN.uv_MainTex);
                fixed4 b = tex2D(_DecalTex, IN.uv_MainTex) * _ShowDecal;
                //o.Albedo = a.rgb * b.rgb; //black bg, texture on decal
                //o.Albedo = a.rgb + b.rgb; //texture bg, decal white
                o.Albedo = b.r > 0.9 ? b.rgb : a.rgb; //above, but decals more clear

            }
            ENDCG
        }
            FallBack "Diffuse"
    }

