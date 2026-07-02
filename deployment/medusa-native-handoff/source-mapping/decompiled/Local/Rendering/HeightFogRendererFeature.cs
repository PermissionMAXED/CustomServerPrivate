using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Il2CppBAPBAP.Local.Rendering;

public class HeightFogRendererFeature : ScriptableRendererFeature
{
	public class HeightFogRenderPass : ScriptableRenderPass
	{
		[OriginalName("Assembly-CSharp.dll", "", "FogAxisMode")]
		public enum FogAxisMode
		{
			XAxis,
			YAxis,
			ZAxis
		}

		[OriginalName("Assembly-CSharp.dll", "", "FogCameraMode")]
		public enum FogCameraMode
		{
			Perspective,
			Orthographic,
			Both
		}

		[OriginalName("Assembly-CSharp.dll", "", "FogLayersMode")]
		public enum FogLayersMode
		{
			MultiplyDistanceAndHeight = 10,
			AdditiveDistanceAndHeight = 20
		}

		[System.Serializable]
		public class HeightFogSettings : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_FogAxisMode;

			private static readonly System.IntPtr NativeFieldInfoPtr_FogLayersMode;

			private static readonly System.IntPtr NativeFieldInfoPtr_FogCameraMode;

			private static readonly System.IntPtr NativeFieldInfoPtr_RenderInPrefabContext;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe FogAxisMode FogAxisMode
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FogAxisMode);
					return *(FogAxisMode*)num;
				}
				set
				{
					*(FogAxisMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FogAxisMode)) = fogAxisMode;
				}
			}

			public unsafe FogLayersMode FogLayersMode
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FogLayersMode);
					return *(FogLayersMode*)num;
				}
				set
				{
					*(FogLayersMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FogLayersMode)) = fogLayersMode;
				}
			}

			public unsafe FogCameraMode FogCameraMode
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FogCameraMode);
					return *(FogCameraMode*)num;
				}
				set
				{
					*(FogCameraMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FogCameraMode)) = fogCameraMode;
				}
			}

			public unsafe bool RenderInPrefabContext
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RenderInPrefabContext);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RenderInPrefabContext)) = flag;
				}
			}

			static HeightFogSettings()
			{
				Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "HeightFogSettings");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr);
				NativeFieldInfoPtr_FogAxisMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr, "FogAxisMode");
				NativeFieldInfoPtr_FogLayersMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr, "FogLayersMode");
				NativeFieldInfoPtr_FogCameraMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr, "FogCameraMode");
				NativeFieldInfoPtr_RenderInPrefabContext = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr, "RenderInPrefabContext");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr, 100685169);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233145, XrefRangeEnd = 233146, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe HeightFogSettings()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<HeightFogSettings>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public HeightFogSettings(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr__settings;

		private static readonly System.IntPtr NativeFieldInfoPtr__sphereMesh;

		private static readonly System.IntPtr NativeFieldInfoPtr__fogMaterial;

		private static readonly System.IntPtr NativeFieldInfoPtr__mainDirectional;

		private static readonly System.IntPtr NativeFieldInfoPtr__volumeComponent;

		private static readonly System.IntPtr NativeFieldInfoPtr__DirectionalDir;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogColorStart;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogColorEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogColorDuo;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogDistanceStart;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogDistanceEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogDistanceFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogHeightStart;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogHeightEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogHeightFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr__FarDistanceHeight;

		private static readonly System.IntPtr NativeFieldInfoPtr__FarDistanceOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr__SkyboxFogIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr__SkyboxFogHeight;

		private static readonly System.IntPtr NativeFieldInfoPtr__SkyboxFogFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr__SkyboxFogOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr__SkyboxFogBottom;

		private static readonly System.IntPtr NativeFieldInfoPtr__SkyboxFogFill;

		private static readonly System.IntPtr NativeFieldInfoPtr__DirectionalIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr__DirectionalFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr__DirectionalColor;

		private static readonly System.IntPtr NativeFieldInfoPtr__NoiseIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr__NoiseMin;

		private static readonly System.IntPtr NativeFieldInfoPtr__NoiseMax;

		private static readonly System.IntPtr NativeFieldInfoPtr__NoiseScale;

		private static readonly System.IntPtr NativeFieldInfoPtr__NoiseSpeed;

		private static readonly System.IntPtr NativeFieldInfoPtr__NoiseDistanceEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr__JitterIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogAxisOption;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogLayersMode;

		private static readonly System.IntPtr NativeFieldInfoPtr__FogCameraMode;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_DirectionalDir;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogColorStart;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogColorEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogColorDuo;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogDistanceStart;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogDistanceEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogDistanceFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogHeightStart;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogHeightEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogHeightFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FarDistanceHeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FarDistanceOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_SkyboxFogIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_SkyboxFogHeight;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_SkyboxFogFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_SkyboxFogOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_SkyboxFogBottom;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_SkyboxFogFill;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_DirectionalIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_DirectionalFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_DirectionalColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_NoiseIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_NoiseMin;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_NoiseMax;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_NoiseScale;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_NoiseSpeed;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_NoiseDistanceEnd;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_JitterIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogAxisOption;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogLayersMode;

		private static readonly System.IntPtr NativeFieldInfoPtr_AHF_FogCameraMode;

		private static readonly System.IntPtr NativeFieldInfoPtr__fogCameraModePerspective;

		private static readonly System.IntPtr NativeFieldInfoPtr__fogCameraModeOrthographic;

		private static readonly System.IntPtr NativeFieldInfoPtr__fogCameraModeBoth;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_HeightFogSettings_Mesh_Light_Material_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Execute_Public_Virtual_Void_ScriptableRenderContext_byref_RenderingData_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_SetShaderVariables_Private_Void_CommandBuffer_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_SetFogFloat_Private_Void_CommandBuffer_Int32_Int32_Single_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_SetFogVector_Private_Void_CommandBuffer_Int32_Int32_Vector4_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_SetFogColor_Private_Void_CommandBuffer_Int32_Int32_Color_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetFogSphereSize_Private_Single_Camera_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetFogSpherePosition_Private_Vector3_Camera_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Dispose_Public_Void_0;

		public unsafe HeightFogSettings _settings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__settings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HeightFogSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__settings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)heightFogSettings));
			}
		}

		public unsafe Mesh _sphereMesh
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__sphereMesh);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__sphereMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
			}
		}

		public unsafe Material _fogMaterial
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fogMaterial);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fogMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		public unsafe Light _mainDirectional
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mainDirectional);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mainDirectional)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)light));
			}
		}

		public unsafe HeightFogVolumeComponent _volumeComponent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__volumeComponent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HeightFogVolumeComponent>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__volumeComponent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)heightFogVolumeComponent));
			}
		}

		public unsafe static int _DirectionalDir
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__DirectionalDir, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__DirectionalDir, (void*)(&num));
			}
		}

		public unsafe static int _FogIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogIntensity, (void*)(&num));
			}
		}

		public unsafe static int _FogColorStart
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogColorStart, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogColorStart, (void*)(&num));
			}
		}

		public unsafe static int _FogColorEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogColorEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogColorEnd, (void*)(&num));
			}
		}

		public unsafe static int _FogColorDuo
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogColorDuo, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogColorDuo, (void*)(&num));
			}
		}

		public unsafe static int _FogDistanceStart
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogDistanceStart, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogDistanceStart, (void*)(&num));
			}
		}

		public unsafe static int _FogDistanceEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogDistanceEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogDistanceEnd, (void*)(&num));
			}
		}

		public unsafe static int _FogDistanceFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogDistanceFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogDistanceFalloff, (void*)(&num));
			}
		}

		public unsafe static int _FogHeightStart
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogHeightStart, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogHeightStart, (void*)(&num));
			}
		}

		public unsafe static int _FogHeightEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogHeightEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogHeightEnd, (void*)(&num));
			}
		}

		public unsafe static int _FogHeightFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogHeightFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogHeightFalloff, (void*)(&num));
			}
		}

		public unsafe static int _FarDistanceHeight
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FarDistanceHeight, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FarDistanceHeight, (void*)(&num));
			}
		}

		public unsafe static int _FarDistanceOffset
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FarDistanceOffset, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FarDistanceOffset, (void*)(&num));
			}
		}

		public unsafe static int _SkyboxFogIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__SkyboxFogIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__SkyboxFogIntensity, (void*)(&num));
			}
		}

		public unsafe static int _SkyboxFogHeight
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__SkyboxFogHeight, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__SkyboxFogHeight, (void*)(&num));
			}
		}

		public unsafe static int _SkyboxFogFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__SkyboxFogFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__SkyboxFogFalloff, (void*)(&num));
			}
		}

		public unsafe static int _SkyboxFogOffset
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__SkyboxFogOffset, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__SkyboxFogOffset, (void*)(&num));
			}
		}

		public unsafe static int _SkyboxFogBottom
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__SkyboxFogBottom, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__SkyboxFogBottom, (void*)(&num));
			}
		}

		public unsafe static int _SkyboxFogFill
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__SkyboxFogFill, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__SkyboxFogFill, (void*)(&num));
			}
		}

		public unsafe static int _DirectionalIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__DirectionalIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__DirectionalIntensity, (void*)(&num));
			}
		}

		public unsafe static int _DirectionalFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__DirectionalFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__DirectionalFalloff, (void*)(&num));
			}
		}

		public unsafe static int _DirectionalColor
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__DirectionalColor, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__DirectionalColor, (void*)(&num));
			}
		}

		public unsafe static int _NoiseIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__NoiseIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__NoiseIntensity, (void*)(&num));
			}
		}

		public unsafe static int _NoiseMin
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__NoiseMin, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__NoiseMin, (void*)(&num));
			}
		}

		public unsafe static int _NoiseMax
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__NoiseMax, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__NoiseMax, (void*)(&num));
			}
		}

		public unsafe static int _NoiseScale
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__NoiseScale, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__NoiseScale, (void*)(&num));
			}
		}

		public unsafe static int _NoiseSpeed
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__NoiseSpeed, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__NoiseSpeed, (void*)(&num));
			}
		}

		public unsafe static int _NoiseDistanceEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__NoiseDistanceEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__NoiseDistanceEnd, (void*)(&num));
			}
		}

		public unsafe static int _JitterIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__JitterIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__JitterIntensity, (void*)(&num));
			}
		}

		public unsafe static int _FogAxisOption
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogAxisOption, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogAxisOption, (void*)(&num));
			}
		}

		public unsafe static int _FogLayersMode
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogLayersMode, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogLayersMode, (void*)(&num));
			}
		}

		public unsafe static int _FogCameraMode
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__FogCameraMode, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__FogCameraMode, (void*)(&num));
			}
		}

		public unsafe static int AHF_DirectionalDir
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_DirectionalDir, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_DirectionalDir, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogIntensity, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogColorStart
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogColorStart, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogColorStart, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogColorEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogColorEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogColorEnd, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogColorDuo
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogColorDuo, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogColorDuo, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogDistanceStart
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogDistanceStart, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogDistanceStart, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogDistanceEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogDistanceEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogDistanceEnd, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogDistanceFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogDistanceFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogDistanceFalloff, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogHeightStart
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogHeightStart, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogHeightStart, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogHeightEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogHeightEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogHeightEnd, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogHeightFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogHeightFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogHeightFalloff, (void*)(&num));
			}
		}

		public unsafe static int AHF_FarDistanceHeight
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FarDistanceHeight, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FarDistanceHeight, (void*)(&num));
			}
		}

		public unsafe static int AHF_FarDistanceOffset
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FarDistanceOffset, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FarDistanceOffset, (void*)(&num));
			}
		}

		public unsafe static int AHF_SkyboxFogIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_SkyboxFogIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_SkyboxFogIntensity, (void*)(&num));
			}
		}

		public unsafe static int AHF_SkyboxFogHeight
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_SkyboxFogHeight, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_SkyboxFogHeight, (void*)(&num));
			}
		}

		public unsafe static int AHF_SkyboxFogFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_SkyboxFogFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_SkyboxFogFalloff, (void*)(&num));
			}
		}

		public unsafe static int AHF_SkyboxFogOffset
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_SkyboxFogOffset, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_SkyboxFogOffset, (void*)(&num));
			}
		}

		public unsafe static int AHF_SkyboxFogBottom
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_SkyboxFogBottom, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_SkyboxFogBottom, (void*)(&num));
			}
		}

		public unsafe static int AHF_SkyboxFogFill
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_SkyboxFogFill, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_SkyboxFogFill, (void*)(&num));
			}
		}

		public unsafe static int AHF_DirectionalIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_DirectionalIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_DirectionalIntensity, (void*)(&num));
			}
		}

		public unsafe static int AHF_DirectionalFalloff
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_DirectionalFalloff, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_DirectionalFalloff, (void*)(&num));
			}
		}

		public unsafe static int AHF_DirectionalColor
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_DirectionalColor, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_DirectionalColor, (void*)(&num));
			}
		}

		public unsafe static int AHF_NoiseIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_NoiseIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_NoiseIntensity, (void*)(&num));
			}
		}

		public unsafe static int AHF_NoiseMin
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_NoiseMin, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_NoiseMin, (void*)(&num));
			}
		}

		public unsafe static int AHF_NoiseMax
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_NoiseMax, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_NoiseMax, (void*)(&num));
			}
		}

		public unsafe static int AHF_NoiseScale
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_NoiseScale, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_NoiseScale, (void*)(&num));
			}
		}

		public unsafe static int AHF_NoiseSpeed
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_NoiseSpeed, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_NoiseSpeed, (void*)(&num));
			}
		}

		public unsafe static int AHF_NoiseDistanceEnd
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_NoiseDistanceEnd, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_NoiseDistanceEnd, (void*)(&num));
			}
		}

		public unsafe static int AHF_JitterIntensity
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_JitterIntensity, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_JitterIntensity, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogAxisOption
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogAxisOption, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogAxisOption, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogLayersMode
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogLayersMode, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogLayersMode, (void*)(&num));
			}
		}

		public unsafe static int AHF_FogCameraMode
		{
			get
			{
				Unsafe.SkipInit(out int result);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AHF_FogCameraMode, (void*)(&result));
				return result;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AHF_FogCameraMode, (void*)(&num));
			}
		}

		public unsafe static string _fogCameraModePerspective
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__fogCameraModePerspective, (void*)(&intPtr));
				return IL2CPP.Il2CppStringToManaged(intPtr);
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__fogCameraModePerspective, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe static string _fogCameraModeOrthographic
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__fogCameraModeOrthographic, (void*)(&intPtr));
				return IL2CPP.Il2CppStringToManaged(intPtr);
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__fogCameraModeOrthographic, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe static string _fogCameraModeBoth
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__fogCameraModeBoth, (void*)(&intPtr));
				return IL2CPP.Il2CppStringToManaged(intPtr);
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__fogCameraModeBoth, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static HeightFogRenderPass()
		{
			Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "HeightFogRenderPass");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr);
			NativeFieldInfoPtr__settings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_settings");
			NativeFieldInfoPtr__sphereMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_sphereMesh");
			NativeFieldInfoPtr__fogMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_fogMaterial");
			NativeFieldInfoPtr__mainDirectional = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_mainDirectional");
			NativeFieldInfoPtr__volumeComponent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_volumeComponent");
			NativeFieldInfoPtr__DirectionalDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_DirectionalDir");
			NativeFieldInfoPtr__FogIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogIntensity");
			NativeFieldInfoPtr__FogColorStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogColorStart");
			NativeFieldInfoPtr__FogColorEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogColorEnd");
			NativeFieldInfoPtr__FogColorDuo = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogColorDuo");
			NativeFieldInfoPtr__FogDistanceStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogDistanceStart");
			NativeFieldInfoPtr__FogDistanceEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogDistanceEnd");
			NativeFieldInfoPtr__FogDistanceFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogDistanceFalloff");
			NativeFieldInfoPtr__FogHeightStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogHeightStart");
			NativeFieldInfoPtr__FogHeightEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogHeightEnd");
			NativeFieldInfoPtr__FogHeightFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogHeightFalloff");
			NativeFieldInfoPtr__FarDistanceHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FarDistanceHeight");
			NativeFieldInfoPtr__FarDistanceOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FarDistanceOffset");
			NativeFieldInfoPtr__SkyboxFogIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_SkyboxFogIntensity");
			NativeFieldInfoPtr__SkyboxFogHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_SkyboxFogHeight");
			NativeFieldInfoPtr__SkyboxFogFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_SkyboxFogFalloff");
			NativeFieldInfoPtr__SkyboxFogOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_SkyboxFogOffset");
			NativeFieldInfoPtr__SkyboxFogBottom = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_SkyboxFogBottom");
			NativeFieldInfoPtr__SkyboxFogFill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_SkyboxFogFill");
			NativeFieldInfoPtr__DirectionalIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_DirectionalIntensity");
			NativeFieldInfoPtr__DirectionalFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_DirectionalFalloff");
			NativeFieldInfoPtr__DirectionalColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_DirectionalColor");
			NativeFieldInfoPtr__NoiseIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_NoiseIntensity");
			NativeFieldInfoPtr__NoiseMin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_NoiseMin");
			NativeFieldInfoPtr__NoiseMax = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_NoiseMax");
			NativeFieldInfoPtr__NoiseScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_NoiseScale");
			NativeFieldInfoPtr__NoiseSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_NoiseSpeed");
			NativeFieldInfoPtr__NoiseDistanceEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_NoiseDistanceEnd");
			NativeFieldInfoPtr__JitterIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_JitterIntensity");
			NativeFieldInfoPtr__FogAxisOption = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogAxisOption");
			NativeFieldInfoPtr__FogLayersMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogLayersMode");
			NativeFieldInfoPtr__FogCameraMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_FogCameraMode");
			NativeFieldInfoPtr_AHF_DirectionalDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_DirectionalDir");
			NativeFieldInfoPtr_AHF_FogIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogIntensity");
			NativeFieldInfoPtr_AHF_FogColorStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogColorStart");
			NativeFieldInfoPtr_AHF_FogColorEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogColorEnd");
			NativeFieldInfoPtr_AHF_FogColorDuo = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogColorDuo");
			NativeFieldInfoPtr_AHF_FogDistanceStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogDistanceStart");
			NativeFieldInfoPtr_AHF_FogDistanceEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogDistanceEnd");
			NativeFieldInfoPtr_AHF_FogDistanceFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogDistanceFalloff");
			NativeFieldInfoPtr_AHF_FogHeightStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogHeightStart");
			NativeFieldInfoPtr_AHF_FogHeightEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogHeightEnd");
			NativeFieldInfoPtr_AHF_FogHeightFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogHeightFalloff");
			NativeFieldInfoPtr_AHF_FarDistanceHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FarDistanceHeight");
			NativeFieldInfoPtr_AHF_FarDistanceOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FarDistanceOffset");
			NativeFieldInfoPtr_AHF_SkyboxFogIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_SkyboxFogIntensity");
			NativeFieldInfoPtr_AHF_SkyboxFogHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_SkyboxFogHeight");
			NativeFieldInfoPtr_AHF_SkyboxFogFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_SkyboxFogFalloff");
			NativeFieldInfoPtr_AHF_SkyboxFogOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_SkyboxFogOffset");
			NativeFieldInfoPtr_AHF_SkyboxFogBottom = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_SkyboxFogBottom");
			NativeFieldInfoPtr_AHF_SkyboxFogFill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_SkyboxFogFill");
			NativeFieldInfoPtr_AHF_DirectionalIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_DirectionalIntensity");
			NativeFieldInfoPtr_AHF_DirectionalFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_DirectionalFalloff");
			NativeFieldInfoPtr_AHF_DirectionalColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_DirectionalColor");
			NativeFieldInfoPtr_AHF_NoiseIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_NoiseIntensity");
			NativeFieldInfoPtr_AHF_NoiseMin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_NoiseMin");
			NativeFieldInfoPtr_AHF_NoiseMax = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_NoiseMax");
			NativeFieldInfoPtr_AHF_NoiseScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_NoiseScale");
			NativeFieldInfoPtr_AHF_NoiseSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_NoiseSpeed");
			NativeFieldInfoPtr_AHF_NoiseDistanceEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_NoiseDistanceEnd");
			NativeFieldInfoPtr_AHF_JitterIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_JitterIntensity");
			NativeFieldInfoPtr_AHF_FogAxisOption = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogAxisOption");
			NativeFieldInfoPtr_AHF_FogLayersMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogLayersMode");
			NativeFieldInfoPtr_AHF_FogCameraMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "AHF_FogCameraMode");
			NativeFieldInfoPtr__fogCameraModePerspective = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_fogCameraModePerspective");
			NativeFieldInfoPtr__fogCameraModeOrthographic = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_fogCameraModeOrthographic");
			NativeFieldInfoPtr__fogCameraModeBoth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, "_fogCameraModeBoth");
			NativeMethodInfoPtr__ctor_Public_Void_HeightFogSettings_Mesh_Light_Material_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685159);
			NativeMethodInfoPtr_Execute_Public_Virtual_Void_ScriptableRenderContext_byref_RenderingData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685160);
			NativeMethodInfoPtr_SetShaderVariables_Private_Void_CommandBuffer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685161);
			NativeMethodInfoPtr_SetFogFloat_Private_Void_CommandBuffer_Int32_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685162);
			NativeMethodInfoPtr_SetFogVector_Private_Void_CommandBuffer_Int32_Int32_Vector4_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685163);
			NativeMethodInfoPtr_SetFogColor_Private_Void_CommandBuffer_Int32_Int32_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685164);
			NativeMethodInfoPtr_GetFogSphereSize_Private_Single_Camera_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685165);
			NativeMethodInfoPtr_GetFogSpherePosition_Private_Vector3_Camera_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685166);
			NativeMethodInfoPtr_Dispose_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr, 100685167);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233146, XrefRangeEnd = 233153, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe HeightFogRenderPass(HeightFogSettings settings, Mesh sphereMesh, Light mainDirectional, Material fogMaterial)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<HeightFogRenderPass>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sphereMesh);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mainDirectional);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fogMaterial);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_HeightFogSettings_Mesh_Light_Material_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233153, XrefRangeEnd = 233189, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&context);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)renderingData);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Execute_Public_Virtual_Void_ScriptableRenderContext_byref_RenderingData_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 233344, RefRangeEnd = 233345, XrefRangeStart = 233189, XrefRangeEnd = 233344, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void SetShaderVariables(CommandBuffer cmd)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetShaderVariables_Private_Void_CommandBuffer_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233345, XrefRangeEnd = 233347, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void SetFogFloat(CommandBuffer cmd, int id, int ahfId, float value)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &id;
			*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &ahfId;
			*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &value;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFogFloat_Private_Void_CommandBuffer_Int32_Int32_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233347, XrefRangeEnd = 233349, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void SetFogVector(CommandBuffer cmd, int id, int ahfId, Vector4 value)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &id;
			*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &ahfId;
			*(Vector4**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &value;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFogVector_Private_Void_CommandBuffer_Int32_Int32_Vector4_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233349, XrefRangeEnd = 233351, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void SetFogColor(CommandBuffer cmd, int id, int ahfId, Color value)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &id;
			*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &ahfId;
			*(Color**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &value;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFogColor_Private_Void_CommandBuffer_Int32_Int32_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233351, XrefRangeEnd = 233352, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe float GetFogSphereSize(Camera camera)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)camera);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFogSphereSize_Private_Single_Camera_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233352, XrefRangeEnd = 233354, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Vector3 GetFogSpherePosition(Camera camera)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)camera);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFogSpherePosition_Private_Vector3_Camera_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		public unsafe void Dispose()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Dispose_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public HeightFogRenderPass(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_Event;

	private static readonly System.IntPtr NativeFieldInfoPtr__sphereMesh;

	private static readonly System.IntPtr NativeFieldInfoPtr__fogShader;

	private static readonly System.IntPtr NativeFieldInfoPtr__mainDirectional;

	private static readonly System.IntPtr NativeFieldInfoPtr__heightFogPass;

	private static readonly System.IntPtr NativeFieldInfoPtr__fogMaterial;

	private static readonly System.IntPtr NativeFieldInfoPtr__settings;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSphereMesh_Private_Mesh_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDirectional_Private_Light_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Create_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddRenderPasses_Public_Virtual_Void_ScriptableRenderer_byref_RenderingData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Dispose_Protected_Virtual_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe RenderPassEvent Event
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Event);
			return *(RenderPassEvent*)num;
		}
		set
		{
			*(RenderPassEvent*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Event)) = renderPassEvent;
		}
	}

	public unsafe Mesh _sphereMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__sphereMesh);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__sphereMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe Shader _fogShader
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fogShader);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Shader>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fogShader)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)shader));
		}
	}

	public unsafe Light _mainDirectional
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mainDirectional);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mainDirectional)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)light));
		}
	}

	public unsafe HeightFogRenderPass _heightFogPass
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__heightFogPass);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HeightFogRenderPass>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__heightFogPass)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)heightFogRenderPass));
		}
	}

	public unsafe Material _fogMaterial
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fogMaterial);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fogMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe HeightFogRenderPass.HeightFogSettings _settings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__settings);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HeightFogRenderPass.HeightFogSettings>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__settings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)heightFogSettings));
		}
	}

	static HeightFogRendererFeature()
	{
		Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local.Rendering", "HeightFogRendererFeature");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr);
		NativeFieldInfoPtr_Event = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "Event");
		NativeFieldInfoPtr__sphereMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "_sphereMesh");
		NativeFieldInfoPtr__fogShader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "_fogShader");
		NativeFieldInfoPtr__mainDirectional = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "_mainDirectional");
		NativeFieldInfoPtr__heightFogPass = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "_heightFogPass");
		NativeFieldInfoPtr__fogMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "_fogMaterial");
		NativeFieldInfoPtr__settings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, "_settings");
		NativeMethodInfoPtr_GetSphereMesh_Private_Mesh_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, 100685153);
		NativeMethodInfoPtr_GetDirectional_Private_Light_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, 100685154);
		NativeMethodInfoPtr_Create_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, 100685155);
		NativeMethodInfoPtr_AddRenderPasses_Public_Virtual_Void_ScriptableRenderer_byref_RenderingData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, 100685156);
		NativeMethodInfoPtr_Dispose_Protected_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, 100685157);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr, 100685158);
	}

	[CallerCount(48)]
	[CachedScanResults(RefRangeStart = 33131, RefRangeEnd = 33179, XrefRangeStart = 33131, XrefRangeEnd = 33179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Mesh GetSphereMesh()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSphereMesh_Private_Mesh_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233354, XrefRangeEnd = 233363, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Light GetDirectional()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDirectional_Private_Light_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233363, XrefRangeEnd = 233389, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Create()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Create_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233389, XrefRangeEnd = 233390, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)renderer);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)renderingData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_AddRenderPasses_Public_Virtual_Void_ScriptableRenderer_byref_RenderingData_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233390, XrefRangeEnd = 233396, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Dispose(bool disposing)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&disposing);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Dispose_Protected_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233396, XrefRangeEnd = 233397, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe HeightFogRendererFeature()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<HeightFogRendererFeature>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public HeightFogRendererFeature(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
