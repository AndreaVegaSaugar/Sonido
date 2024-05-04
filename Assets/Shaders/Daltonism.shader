Shader "Custom/Daltonism"
{
    Properties
	{
        _MainTex ("Texture", 2D) = "white" {}
        _DaltonismType ("Daltonism Type", Range(0, 4)) = 0
        _Intensity ("Intensity", Range(0, 1)) = 0.5
    }
	SubShader
    {
        Tags { "RenderType" = "Opaque" }
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // Incluye el archivo de UnityCG.cginc para acceder a las funciones y variables estándar de Unity.
            #include "UnityCG.cginc"
 
            sampler2D _MainTex;
            float _Intensity;
            float _DaltonismType;
 
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
 
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            // color-shifting matrices
			static float3x3 color_matrices[4] = {
				// normal vision - identity matrix
				float3x3(
					1.0f,0.0f,0.0f, 
					0.0f,1.0f,0.0f, 
					0.0f,0.0f,1.0f),
				// Protanopia - blindness to long wavelengths
				float3x3(
					0.567f,0.433f,0.0f, 
					0.558f,0.442f,0.0f, 
					0.0f,0.242f,0.758f),
				// Deuteranopia - blindness to medium wavelengths
				float3x3(
					0.625f,0.375f,0.0f, 
					0.7f,0.3f,0.0f,     
					0.0f,0.3f,0.7f),
				// Tritanopie - blindness to short wavelengths
				float3x3(
					0.95f,0.05f,0.0f, 
					0.0f,0.433f,0.567f, 
					0.0f,0.475f,0.525f)
					};

            fixed4 frag(v2f i) : SV_Target
            {
                // Sample the texture
                fixed4 c = tex2D(_MainTex, i.uv);
                float3 x;
                // if (_DaltonismType == 0.0) // Normal
                // {
                //     x = mul(c.rgb, color_matrices[0]);
                // }
                // Simulate color blindness
                if (_DaltonismType == 1.0) // Protanopia
                {
                    x = mul(c.rgb, color_matrices[1]);
                }
                else if (_DaltonismType == 2.0) // Deuteranopia
                {
                    x = mul(c.rgb, color_matrices[2]);
                                    // Simulate deuteranopia (red-green color blindness)
                c.rgb.r = 0; // Eliminate red component
                c.rgb.g = 0.5 * (c.rgb.g + c.rgb.b); // Combine green and blue
                c.rgb.b = 0.5 * (c.rgb.g + c.rgb.b); // Combine green and blue

                }
 
                // Apply intensity
                //c.rgb = lerp(c.rgb, float3(0.5, 0.5, 0.5), _Intensity);
                return half4(x,1.0f);
                //return c;
            }
            ENDCG
        }
    }
 
    FallBack "Diffuse"
}
