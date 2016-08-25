
Shader "Hidden/EdgeDetectColors" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "" {}
	}

		CGINCLUDE

#include "UnityCG.cginc"

		struct v2f {
		float4 pos : SV_POSITION;
		float2 uv[7] : TEXCOORD0;

	};

	//Texturparameter
	sampler2D _MainTex;
	uniform float4 _MainTex_TexelSize;

	//Camerarparameter
	sampler2D _CameraDepthNormalsTexture;
	sampler2D_float _CameraDepthTexture;
	uniform float3 _CameraForward;
	uniform float _ClipingDistance;

	//Edgedetectionparameers
	uniform half4 _Sensitivity;
	uniform half _SampleDistance;

	//Colorparameter
	uniform half _BgFade;
	uniform half4 _EdgeColor;


	//Test Parameter
	uniform float _TempOnlyDistance;
	uniform float3 _ReferencePoint;
	uniform float4x4 _InverseProjection;

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


	v2f vertRobert(appdata_full v)
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

		float2 uv = v.texcoord.xy;
		o.uv[0] = uv;

#if UNITY_UV_STARTS_AT_TOP
		if (_MainTex_TexelSize.y < 0) {
			uv.y = 1 - uv.y;
		}
#endif

		o.uv[1] = uv + _MainTex_TexelSize.xy * half2(1, 1) * _SampleDistance;
		o.uv[2] = uv + _MainTex_TexelSize.xy * half2(-1, -1) * _SampleDistance;
		o.uv[3] = uv + _MainTex_TexelSize.xy * half2(-1, 1) * _SampleDistance;
		o.uv[4] = uv + _MainTex_TexelSize.xy * half2(1, -1) * _SampleDistance;


		o.uv[5] = float2(v.vertex.x, v.vertex.y);	//Object Coordinates for matching with depthtexture
		o.uv[6] = float2(o.pos.x, o.pos.y); //Cliping Coordinates

		return o;
	}


	half4 fragRobert(v2f i) : SV_Target{
		half4 sample1 = tex2D(_CameraDepthNormalsTexture, i.uv[1].xy);
		half4 sample2 = tex2D(_CameraDepthNormalsTexture, i.uv[2].xy);
		half4 sample3 = tex2D(_CameraDepthNormalsTexture, i.uv[3].xy);
		half4 sample4 = tex2D(_CameraDepthNormalsTexture, i.uv[4].xy);

		half edgeCheckResult = 1.0;
		edgeCheckResult *= CheckSame(sample1.xy, DecodeFloatRG(sample1.zw), sample2);
		edgeCheckResult *= CheckSame(sample3.xy, DecodeFloatRG(sample3.zw), sample4);

		float3 FragColor = tex2D(_MainTex, i.uv[0].xy);

		if (FragColor.x+FragColor.y+FragColor.z <= 0.1) {
			return 0;
		}
		if (FragColor.x <= 0.01 &&FragColor.y <= 0.01 && FragColor.z >= 0.99) {
			return _EdgeColor;
		}

		if (edgeCheckResult > 0) {
			return  lerp(tex2D(_MainTex, i.uv[0].xy), 0, _BgFade);
		}
		else {
			return _EdgeColor;
		}

	}

		ENDCG

		Subshader {
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