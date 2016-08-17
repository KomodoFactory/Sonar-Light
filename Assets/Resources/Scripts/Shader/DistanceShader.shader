Shader "Custom/DistanceShader" {
	Properties {

		_MainTex("Texture", 2D) = "white" {}
	_BumpMap("Bumpmap", 2D) = "bump" {}

	/*
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		*/
	}
	SubShader {
		Tags{ "RenderType" = "Opaque" }
		//Tags { "Queue" = "Transparent" }
		//Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {

			clip(frac((IN.worldPos.y + IN.worldPos.z*0.1) * 5) - 0.5);
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

			/*fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;


			float3 delta = float3(_WorldSpaceCameraPos.x - IN.worldPos.x, _WorldSpaceCameraPos.y - IN.worldPos.y, _WorldSpaceCameraPos.z - IN.worldPos.z);
			float distance = length(delta);

			if (distance >= 10) {
				o.Albedo = fixed4(0,0,0,0);
				o.Alpha = 1;
			}
			else {
				o.Emission = fixed3(distance, distance, distance);
			}
			
			*/

		}
		ENDCG
	}
	FallBack "Diffuse"
}
