Shader "Custom/LightMaskShader"
   {
       Properties
       {
           _MainTex ("Texture", 2D) = "black" {}
           _Radius ("Radius", Float) = 5.0
           _LightPos ("Light Position", Vector) = (0,0,0,0)
       }
       SubShader
       {
           Tags { "RenderType"="Opaque" }
           LOD 100
 
           Pass
           {
               CGPROGRAM
               #pragma vertex vert
               #pragma fragment frag
               #include "UnityCG.cginc"
 
               struct appdata_t
               {
                   float4 vertex : POSITION;
                   float2 uv : TEXCOORD0;
               };
 
               struct v2f
               {
                   float2 uv : TEXCOORD0;
                   float4 vertex : SV_POSITION;
               };
 
               sampler2D _MainTex;
               fixed4 _MainTex_ST;
               float _Radius;
               float3 _LightPos;
 
               v2f vert (appdata_t v)
               {
                   v2f o;
                   o.vertex = UnityObjectToClipPos(v.vertex);
                   o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                   return o;
               }
 
               fixed4 frag (v2f i) : SV_Target
               {
                   float distanceToLight = distance(i.uv, _LightPos.xy / _ScreenParams.xy);
                   float alpha = smoothstep(_Radius, _Radius - 0.2, distanceToLight);
                   fixed4 col = tex2D(_MainTex, i.uv);
                   return col * (1 - alpha);
               }
               ENDCG
           }
       }
       FallBack "Diffuse"
   }