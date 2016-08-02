Shader "SonarLight/OutlineShader"
{
	Properties
	{
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull off ZWrite On ZTest Always

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
			float3 normal : NORMAL;
			};

			struct v3f {
			float4 pos : SV_POSITION;
			fixed4 color : COLOR;
			float2 uv : TEXCOORD0;
		};

		v3f vert(appdata v)
		{
			v3f o;
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
			o.uv = v.uv;
			o.color = fixed4(v.normal * 0.5 +0.5,1);
			return o;
		}

		fixed4 frag(v3f i) : SV_Target
		{
			fixed4 color = i.color;
			return color;
		}
			ENDCG
		}
	}
}
