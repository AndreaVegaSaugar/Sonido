Shader "Custom/Daltonism"
{
    Properties
    {
         _MainTex ("Texture", 2D) = "white" {}
        _ColorBlindnessType ("Color Blindness Type", Range(0, 2)) = 1
        _Intensity ("Intensity", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
 
        CGPROGRAM
        #pragma surface surf Lambert
 
        sampler2D _MainTex;
        float _Intensity;
        float _ColorBlindnessType;
 
        struct Input
        {
            float2 uv_MainTex;
        };
 
        void surf(Input IN, inout SurfaceOutput o)
        {
            // Sample the texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
 
            // Convert color to grayscale
            float gray = dot(c.rgb, float3(0.299, 0.587, 0.114));
            c.rgb = lerp(c.rgb, float3(gray, gray, gray), _Intensity);
 
            // Simulate color blindness
            if (_ColorBlindnessType == 1) // Deuteranopia
            {
                // Simulate deuteranopia (red-green color blindness)
                c.rgb.r = 0; // Eliminate red component
                c.rgb.g = 0.5 * (c.rgb.g + c.rgb.b); // Combine green and blue
                c.rgb.b = 0.5 * (c.rgb.g + c.rgb.b); // Combine green and blue
            }
            else if (_ColorBlindnessType == 2) // Protanopia
            {
                // Simulate protanopia (red-green color blindness)
                c.rgb.r = 0; // Eliminate red component
                c.rgb.g = c.rgb.b; // Set green to blue
            }
 
            // Output final color
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
 
    FallBack "Diffuse"
}
