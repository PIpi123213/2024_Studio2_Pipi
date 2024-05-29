Shader "Custom/blender"
{
    Properties
    {
        _Color1 ("Color 1", Color) = (1,0,0,1) // 默认红色
        _Color2 ("Color 2", Color) = (0,0,1,1) // 默认蓝色
        _Blend ("Blend Factor", Range(0, 1)) = 0.5 // 混合因子，默认值为0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color1;
            float4 _Color2;
            float _Blend;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                return lerp(_Color1, _Color2, _Blend);
            }
            ENDCG
        }
    }
}
