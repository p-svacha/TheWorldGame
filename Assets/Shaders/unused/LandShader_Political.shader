﻿Shader "Custom/LandShader_Political"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _BorderMask("Border Mask (Greyscale)", 2D) = "black" {}
        _BorderCol("Border Color", Color) = (0,0,0,1)

        _RiverMask("River Mask (Greyscale)", 2D) = "black" {}
        _RiverCol("River Color", Color) = (0,0,0,1)

        _Blink("Blink", Float) = 0
        _BlinkDuration("Blink Duration", Float) = 2
        _BlinkColor("Blink Color", Color) = (1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BorderMask;
        sampler2D _RiverMask;
        float _Blink;
        float _BlinkDuration;
        float3 _BlinkColor;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BorderMask;
            float2 uv_RiverMask;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _BorderCol;
        fixed4 _RiverCol;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            // Blend with river mask
            fixed4 riverMask = tex2D(_RiverMask, IN.uv_RiverMask);
            c = (riverMask * _RiverCol) + ((1 - riverMask) * c);

            // Blend with border mask
            fixed4 borderMask = tex2D(_BorderMask, IN.uv_BorderMask);
            c = (borderMask * _BorderCol) + ((1 - borderMask) * c);

            if (_Blink == 1.0f) 
            {
                float r = (0.5f + abs(sin(_Time.w * (1 / _BlinkDuration))));
                c *= r;
            }

            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
