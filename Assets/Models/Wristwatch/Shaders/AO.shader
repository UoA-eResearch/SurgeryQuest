Shader "Standard Vertex AO" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_EmissionColor("Emission Color", Color) = (0,0,0,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_MainNrm ("Normal Map", 2D) = "bump" {}
		_NrmStrength ("Normal Strength", Range(-2,2)) = 1
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MainNrm;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MainNrm;
			float4 color : Color;
		};
		half _NrmStrength;
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _EmissionColor;
		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb * IN.color.rgb ;

			fixed3 nrm = UnpackNormal(tex2D (_MainNrm, IN.uv_MainNrm));
			nrm = lerp(fixed3(0,0,1),nrm, _NrmStrength);
			//nrm.z = nrm.z / _NrmStrength;

			o.Normal = nrm;
			o.Emission = _EmissionColor * IN.color.rgb * tex2D (_MainTex, IN.uv_MainTex);

			//if(_Glossiness == 0){
				//o.Specular = 0;
			//}

			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
