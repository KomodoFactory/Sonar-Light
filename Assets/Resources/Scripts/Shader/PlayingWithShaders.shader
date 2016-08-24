Shader "Custom/PlayingWithShaders"
{
	Properties{
		_MainTex("", 2D) = "white" {} //this texture will have the rendered image before post-processing
	_RingWidth("ring width", Float) = 0.01
		_RingPassTimeLength("ring pass time", Float) = 2.0
	}

		SubShader{
		Tags{ "RenderType" = "Opaque" }
		Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"

	struct v2f {
		float4 pos : SV_POSITION;
		//float4 scrPos[2]:TEXCOORD1;
		float4 worldPos:TEXCOORD1;
	};

	//Our Vertex Shader
	v2f vert(appdata_base v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.worldPos = mul(UNITY_MATRIX_MV, v.vertex);
		return o;
	}

	sampler2D _MainTex;


	half4 frag(v2f i) : COLOR{

		float dist = length(i.worldPos);
	if (dist >= 19.9 && dist <= 20.1) {
		return half4(0, 0, 1, 1);
	}
	if (dist < 20) {
		return half4(dist, dist, dist, 1);
	}
	else {
		return 0;
	}
	}
		ENDCG
	}
	}
		FallBack "Diffuse"
}