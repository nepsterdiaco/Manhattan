Shader "Shapes/Quad Additive" {
	Properties {
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest ("Z Test", int) = 4
		_ZOffsetFactor ("Z Offset Factor", Float ) = 0
		_ZOffsetUnits ("Z Offset Units", int ) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _StencilComp ("Stencil Comparison", int) = 8
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilOpPass ("Stencil Operation Pass", int) = 0
		_StencilID ("Stencil ID", int) = 0
		_StencilReadMask ("Stencil Read Mask", int) = 255
		_StencilWriteMask ("Stencil Write Mask", int) = 255
	}
	SubShader {
		Tags {
			"RenderPipeline" = "HDRenderPipeline"
			"IgnoreProjector" = "True"
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"DisableBatching" = "True"
		}
		Pass {
			Name "ForwardOnly"
			Tags { "LightMode" = "ForwardOnly" }
			Stencil {
				Comp [_StencilComp]
				Pass [_StencilOpPass]
				Ref [_StencilID]
				ReadMask [_StencilReadMask]
				WriteMask [_StencilWriteMask]
			}
			Cull Off
			ZTest [_ZTest]
			Offset [_ZOffsetFactor], [_ZOffsetUnits]
			ZWrite Off
			Blend One One
			HLSLPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_instancing
				#pragma prefer_hlslcc gles
				#pragma exclude_renderers d3d11_9x
				#pragma target 2.0
				#define ADDITIVE
				#include "../../Core/Quad Core.cginc"
			ENDHLSL
		}
		Pass {
			Name "DepthForwardOnly"
			Tags { "LightMode" = "DepthForwardOnly" }
			Stencil {
				Comp [_StencilComp]
				Pass [_StencilOpPass]
				Ref [_StencilID]
				ReadMask [_StencilReadMask]
				WriteMask [_StencilWriteMask]
			}
			Cull Off
			HLSLPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_instancing
				#pragma prefer_hlslcc gles
				#pragma exclude_renderers d3d11_9x
				#pragma target 2.0
				#define ADDITIVE
				#include "../../Core/Quad Core.cginc"
			ENDHLSL
		}
		Pass {
			Name "Picking"
			Tags { "LightMode" = "Picking" }
			Stencil {
				Comp [_StencilComp]
				Pass [_StencilOpPass]
				Ref [_StencilID]
				ReadMask [_StencilReadMask]
				WriteMask [_StencilWriteMask]
			}
			Cull Off
			HLSLPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_instancing
				#pragma prefer_hlslcc gles
				#pragma exclude_renderers d3d11_9x
				#pragma target 2.0
				#define ADDITIVE
				#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap
				#define SCENE_VIEW_PICKING
				#include "../../Core/Quad Core.cginc"
			ENDHLSL
		}
		Pass {
			Name "Selection"
			Tags { "LightMode" = "SceneSelectionPass" }
			Stencil {
				Comp [_StencilComp]
				Pass [_StencilOpPass]
				Ref [_StencilID]
				ReadMask [_StencilReadMask]
				WriteMask [_StencilWriteMask]
			}
			Cull Off
			HLSLPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_instancing
				#pragma prefer_hlslcc gles
				#pragma exclude_renderers d3d11_9x
				#pragma target 2.0
				#define ADDITIVE
				#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap
				#define SCENE_VIEW_OUTLINE_MASK
				#include "../../Core/Quad Core.cginc"
			ENDHLSL
		}
	}
}