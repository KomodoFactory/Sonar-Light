﻿
Shader "Hidden/EdgeDetectColors" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "" {}
	//_Color ("Color", color) = (1,1,1,1)
	}

		CGINCLUDE

#include "UnityCG.cginc"

		struct v2f {
		float4 pos : SV_POSITION;
		float2 uv[5] : TEXCOORD0;
		float distance : BLENDWEIGHT;
		half4 temp : COLOR;
	};

	sampler2D _MainTex;
	uniform half4 _Color;
	uniform float4 _MainTex_TexelSize;

	sampler2D _CameraDepthNormalsTexture;
	sampler2D_float _CameraDepthTexture;

	uniform half4 _Sensitivity;
	uniform half4 _BgColor;
	uniform half _BgFade;
	uniform half _SampleDistance;
	uniform float _Exponent;

	uniform float _Threshold;


	uniform float3 _Position;
	uniform float _Distance;

	inline half CheckSame(half2 centerNormal, float centerDepth, half4 theSample)
	{
		// difference in normals
		// do not bother decoding normals - there's no need here
		half2 diff = abs(centerNormal - theSample.xy) * _Sensitivity.y;
		half isSameNormal = (diff.x + diff.y) * _Sensitivity.y < 0.1;
		// difference in depth
		float sampleDepth = DecodeFloatRG(theSample.zw);
		float zdiff = abs(centerDepth - sampleDepth);
		// scale the required threshold by the distance
		half isSameDepth = zdiff * _Sensitivity.x < 0.09 * centerDepth;

		// return:
		// 1 - if normals and depth are similar enough
		// 0 - otherwise

		return isSameNormal * isSameDepth;
	}


v2f vertRobert(appdata_img v)
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

		float2 uv = v.texcoord.xy;
		o.uv[0] = uv;



#if UNITY_UV_STARTS_AT_TOP
		if (_MainTex_TexelSize.y < 0)
			uv.y = 1 - uv.y;
#endif

		o.uv[1] = uv + _MainTex_TexelSize.xy * half2(1, 1) * _SampleDistance;
		o.uv[2] = uv + _MainTex_TexelSize.xy * half2(-1, -1) * _SampleDistance;
		o.uv[3] = uv + _MainTex_TexelSize.xy * half2(-1, 1) * _SampleDistance;
		o.uv[4] = uv + _MainTex_TexelSize.xy * half2(1, -1) * _SampleDistance;

		float3 tempPos = mul(_Object2World, v.vertex).xyz;

		float3 delta = tempPos - _Position;

		o.distance = length(delta);

		o.temp = mul(_Object2World,v.vertex);


		return o;
	}


		half4 fragRobert(v2f i) : SV_Target{
			half4 sample1 = tex2D(_CameraDepthNormalsTexture, i.uv[1].xy);
			half4 sample2 = tex2D(_CameraDepthNormalsTexture, i.uv[2].xy);
			half4 sample3 = tex2D(_CameraDepthNormalsTexture, i.uv[3].xy);
			half4 sample4 = tex2D(_CameraDepthNormalsTexture, i.uv[4].xy);

			half edge = 1.0;

			edge *= CheckSame(sample1.xy, DecodeFloatRG(sample1.zw), sample2);
			edge *= CheckSame(sample3.xy, DecodeFloatRG(sample3.zw), sample4);


			

			//if (i.distance > _Distance) {
			//	return 0;
			//}

			if (edge > 0) {
				
				return  lerp(tex2D(_MainTex, i.uv[0].xy), _BgColor, _BgFade); //return 0 to have edge only mode
			}
			else {
				return i.temp;
				return _Color;
			}

	}




	ENDCG

		Subshader{
			Pass{
				 ZTest Always Cull Off ZWrite Off
				 CGPROGRAM
				 #pragma vertex vertRobert
				 #pragma fragment fragRobert
				 ENDCG
		}
	}

		Fallback off

}