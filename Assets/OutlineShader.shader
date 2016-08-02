Shader "SonarLight/OutlineShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_MainColor("Color", Color) = (0,0,0,1)
	}
		SubShader
		{
			// No culling or depth
			Cull off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM

	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"

				struct v2f {
				float4 pos : SV_POSITION;
				fixed3 color : COLOR0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = v.vertex;//mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.normal * 0.5 +0.5;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return fixed4(i.color, 1);
			}
				ENDCG
			}
		}
}
