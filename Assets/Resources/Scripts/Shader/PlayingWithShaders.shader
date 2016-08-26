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
		float3 worldPos:TEXCOORD1;
	};


	uniform float2 _Distances[10];
	uniform float3 _SoundSources[10];

	//Our Vertex Shader
	v2f vert(appdata_base v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.worldPos = mul(_Object2World, v.vertex);
		return o;
	}

	sampler2D _MainTex;


	half4 frag(v2f i) : COLOR{

		float delta = 0.1;

		half4 color = 0;

		return half4( _Distances[0].x, _Distances[0].y, 0 , 1);

		for (int j = 0; j < 10; j++) {
			float3 sourceToFragment = i.worldPos - _SoundSources[j];

			float dist = length(sourceToFragment);



		}
	return 0;

	}
		ENDCG
	}
	}
		FallBack "Diffuse"
}