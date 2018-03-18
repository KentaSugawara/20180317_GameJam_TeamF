Shader "MyShader/Gravity"
{
	Properties{
		_DistortionTex("DistortionTex", 2D) = "white" {}
		//_TransitionTex("TransitionTex", 2D) = "bump" {}
		_WorldCenterPos("WorldCenterPos", Vector) = (0, 0, 0, 0)
		_Distortion("Distortion", Range(0.0, 10.0)) = 1
		_ScrollSpeed("ScrollSpeed", Float) = 10.0
	}

		SubShader{
		Tags{
		"Queue" = "Transparent"
		"RenderType" = "Transparent"
	}

		GrabPass{}

		CGPROGRAM
#pragma target 3.0
#pragma surface surf Standard fullforwardshadows

	sampler2D _GrabTexture;
	sampler2D _DistortionTex;
	fixed _Distortion;
	fixed4 _WorldCenterPos;
	fixed _ScrollSpeed;

	struct Input {
		float2 uv_DistortionTex;
		float4 screenPos;
		float3 worldPos;
	};

	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed2 grabUV = IN.screenPos.xy / IN.screenPos.w;
		//fixed d = distance(fixed2(0.5, 0.5), IN.uv_MainTex);//IN.uv_MainTex - fixed2(0.5, 0.5);
		//fixed d = (IN.uv_MainTex.x - 0.5) * (IN.uv_MainTex.x - 0.5) + (IN.uv_MainTex.y - 0.5) * (IN.uv_MainTex.y - 0.5);
		//fixed d = distance(_WorldCenterPos.xyz, IN.worldPos);
		//fixed x = _WorldCenterPos.x - IN.worldPos.x;
		//fixed y = _WorldCenterPos.y - IN.worldPos.y;
		//fixed z = _WorldCenterPos.z - IN.worldPos.z;
		//fixed d = x * x + y * y + z * z;

		fixed2 v = normalize(_WorldCenterPos - IN.worldPos);

		//fixed2 uv = (_ScreenCenterPos.xy - grabUV) / _Radius;

		fixed2 uv = IN.uv_DistortionTex;
		uv.x = fmod(uv.x + v.x * _Time * _ScrollSpeed, 1.0);
		uv.y = fmod(uv.y + v.y * _Time * _ScrollSpeed, 1.0);
		
		fixed dist = tex2D(_DistortionTex, uv).r;

		//fixed t = fmod(_Time * 100 * d, 1.0);
		//grabUV.x = (IN.screenPos.x + dist * _Distortion/*fmod(d * _Radius * fmod(_Time, 1), 1.0)*/) / (IN.screenPos.w);
		//grabUV.y = (IN.screenPos.y + dist * _Distortion/*fmod(d * _Radius * fmod(_Time, 1), 1.0)*/) / (IN.screenPos.w);
		grabUV += v * dist * _Distortion;
		grabUV.y = grabUV.y * -1 + 1;
		fixed3 grab = tex2D(_GrabTexture, grabUV).rgb;

		o.Emission = grab;
		o.Albedo = fixed3(0, 0, 0);
	}
	ENDCG
	}
}
