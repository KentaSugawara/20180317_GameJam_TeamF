Shader "MyShader/Enemy/Unlit_Distortion"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Tint("Tint", Color) = (1,1,1,1)
		_Distortion("Distortion", Range(0, 1)) = 0
		_RGBNoise("RGBNoiseMax", Range(0, 1)) = 0
		_Saturation("Saturation", Range(0, 1)) = 0
		_DissovleMask("Mask To Dissolve", 2D) = "white" {}  // 分解用のマスク
		_Dissolve("Dissovle", Range(-0.1,1.1)) = 0     // 分解のしきい値
		_ColorWidth("ColorWidth", Range(0,1)) = 0.001
		_ColorIntensity("Intensity", Float) = 1     // 燃え尽きる部分の明るさの強度（Bloom+HDRを使わない場合は不要）
		_Color("Line Color", Color) = (1,1,1,1)     // 燃え尽きる部分の色
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			float rand(float2 co) {
				return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
			}

			fixed4 _Tint;
			float _Distortion;
			fixed _RGBNoise;
			fixed _Saturation;
			sampler2D _DissovleMask;
			fixed _Dissolve;
			fixed _ColorWidth;
			fixed4 _ColorIntensity;
			fixed4 _Color;
			
			fixed4 frag (v2f i) : SV_Target
			{
				if (_Dissolve > 0) {
					fixed mask = tex2D(_DissovleMask, i.uv).r;
					if (mask < _Dissolve) {
						discard;
					}
					else {
						fixed b = smoothstep(_Dissolve, mask, _Dissolve + _ColorWidth);
						return tex2D(_MainTex, i.uv) + _Tint + _Color * b;
					}
				}

				if (_Distortion <= 0) {
					return (tex2D(_MainTex, i.uv) + _Tint) * _Saturation;
				}

				float2 inUV = i.uv;
				float2 uv = i.uv - 0.5;

				// UV座標を再計算し、画面を歪ませる
				float vignet = length(uv);
				uv /= 1 - vignet * 0.2;
				float2 texUV = i.uv;

				// 色を計算
				fixed4 c = tex2D(_MainTex, texUV);
				fixed3 col = c.xyz;
				fixed alpha = c.a;

				// ノイズ適用
				texUV.x += (rand(floor(texUV.y * 500) + _Time.y) - 0.5) * _Distortion;
				texUV = fmod(texUV, 1);

				if (tex2D(_MainTex, texUV).a < 1.0f) {
					return tex2D(_MainTex, texUV) * _Saturation;
				}

				// 色を取得、RGBを少しずつずらす
				col.r = tex2D(_MainTex, texUV).r;
				col.g = tex2D(_MainTex, texUV - float2(0.002, 0)).g;
				col.b = tex2D(_MainTex, texUV - float2(0.004, 0)).b;

				// RGBノイズ
				if (rand((rand(floor(texUV.y * 500) + _Time.y) - 0.5) + _Time.y) < lerp(0.0, _RGBNoise, _Distortion))
				{
					col.r = rand(uv + float2(123 + _Time.y, 0));
					col.g = rand(uv + float2(123 + _Time.y, 1));
					col.b = rand(uv + float2(123 + _Time.y, 2));
				}

				// ピクセルごとに描画するRGBを決める
				float floorX = fmod(inUV.x * _ScreenParams.x / 3, 1);
				col.r *= lerp(1.0, floorX > 0.3333, _Distortion);
				col.g *= lerp(1.0, floorX < 0.3333 || floorX > 0.6666, _Distortion);
				col.b *= lerp(1.0, floorX < 0.6666, _Distortion);

				// スキャンラインを描画
				float scanLineColor = sin(_Time.y * 10 + uv.y * 500) / 2 + 0.5;
				col *= lerp(1.0, 0.5 + clamp(scanLineColor + 0.5, 0, 1) * 0.5, _Distortion);

				// 端を暗くする
				//col *= lerp(1.0, 1 - vignet * 1.3, _Distortion);

				return float4(col/* * _Saturation*/, alpha);
			}
			ENDCG
		}
	}
}
