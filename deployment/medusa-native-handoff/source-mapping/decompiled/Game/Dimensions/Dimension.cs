using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2Cpp;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Localisation;
using Il2CppBAPBAP.UI;
using Il2CppFMOD.Studio;
using Il2CppFMODUnity;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Game.Dimensions;

[System.Serializable]
public class Dimension : Il2CppSystem.Object
{
	[System.Serializable]
	public class DimensionParticleSystem : Il2CppSystem.Object
	{
		[OriginalName("Assembly-CSharp.dll", "", "BehaviourSettings")]
		[System.Flags]
		public enum BehaviourSettings
		{
			None = 0,
			SetDimensionRadius = 1,
			SetDimensionScale = 2,
			PlayOnEntityEnter = 4,
			PlayOnEntityExit = 8,
			SetPositionToCollisionPoint = 0x10,
			SetForwardToCollisionDirection = 0x20
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_enabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_particleSystem;

		private static readonly System.IntPtr NativeFieldInfoPtr_behaviourSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_collisionRadiusCoverage;

		private static readonly System.IntPtr NativeFieldInfoPtr__startEmmisionRate;

		private static readonly System.IntPtr NativeMethodInfoPtr_ScaleEmissionRate_Public_Void_Single_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe bool enabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabled)) = flag;
			}
		}

		public unsafe ParticleSystem particleSystem
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_particleSystem);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_particleSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
			}
		}

		public unsafe BehaviourSettings behaviourSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourSettings);
				return *(BehaviourSettings*)num;
			}
			set
			{
				*(BehaviourSettings*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourSettings)) = behaviourSettings;
			}
		}

		public unsafe float collisionRadiusCoverage
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionRadiusCoverage);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionRadiusCoverage)) = num;
			}
		}

		public unsafe float _startEmmisionRate
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startEmmisionRate);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__startEmmisionRate)) = num;
			}
		}

		static DimensionParticleSystem()
		{
			Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "DimensionParticleSystem");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr);
			NativeFieldInfoPtr_enabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, "enabled");
			NativeFieldInfoPtr_particleSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, "particleSystem");
			NativeFieldInfoPtr_behaviourSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, "behaviourSettings");
			NativeFieldInfoPtr_collisionRadiusCoverage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, "collisionRadiusCoverage");
			NativeFieldInfoPtr__startEmmisionRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, "_startEmmisionRate");
			NativeMethodInfoPtr_ScaleEmissionRate_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, 100672802);
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr, 100672803);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 120185, RefRangeEnd = 120186, XrefRangeStart = 120176, XrefRangeEnd = 120185, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void ScaleEmissionRate(float scale)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&scale);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ScaleEmissionRate_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120186, XrefRangeEnd = 120187, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe DimensionParticleSystem()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DimensionParticleSystem>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public DimensionParticleSystem(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[OriginalName("Assembly-CSharp.dll", "", "DimensionType")]
	public enum DimensionType
	{
		None,
		SinCity,
		Atlantis,
		Untitled
	}

	public class DimensionCollisionDataHolder : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Entity;

		private static readonly System.IntPtr NativeFieldInfoPtr_Data;

		private static readonly System.IntPtr NativeMethodInfoPtr_UpdateData_Public_Boolean_Single_Single_Single_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe EntityManager Entity
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Entity);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Entity)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager));
			}
		}

		public unsafe DimensionCollisionData Data
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Data);
				return *(DimensionCollisionData*)num;
			}
			set
			{
				*(DimensionCollisionData*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Data)) = dimensionCollisionData;
			}
		}

		static DimensionCollisionDataHolder()
		{
			Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "DimensionCollisionDataHolder");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr);
			NativeFieldInfoPtr_Entity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr, "Entity");
			NativeFieldInfoPtr_Data = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr, "Data");
			NativeMethodInfoPtr_UpdateData_Public_Boolean_Single_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr, 100672804);
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr, 100672805);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 120203, RefRangeEnd = 120205, XrefRangeStart = 120187, XrefRangeEnd = 120203, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool UpdateData(float deltaTime, float followSpeed, float duration)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&deltaTime);
			*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &followSpeed;
			*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &duration;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateData_Public_Boolean_Single_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe DimensionCollisionDataHolder()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DimensionCollisionDataHolder>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public DimensionCollisionDataHolder(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct DimensionCollisionData
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Position;

		private static readonly System.IntPtr NativeFieldInfoPtr_Direction;

		private static readonly System.IntPtr NativeFieldInfoPtr_Time;

		private static readonly System.IntPtr NativeFieldInfoPtr_Progress;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad0;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad1;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad2;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad3;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad4;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad5;

		[FieldOffset(0)]
		public Vector4 Position;

		[FieldOffset(16)]
		public Vector4 Direction;

		[FieldOffset(32)]
		public float Time;

		[FieldOffset(36)]
		public float Progress;

		[FieldOffset(40)]
		public float pad0;

		[FieldOffset(44)]
		public float pad1;

		[FieldOffset(48)]
		public float pad2;

		[FieldOffset(52)]
		public float pad3;

		[FieldOffset(56)]
		public float pad4;

		[FieldOffset(60)]
		public float pad5;

		static DimensionCollisionData()
		{
			Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "DimensionCollisionData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr);
			NativeFieldInfoPtr_Position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "Position");
			NativeFieldInfoPtr_Direction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "Direction");
			NativeFieldInfoPtr_Time = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "Time");
			NativeFieldInfoPtr_Progress = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "Progress");
			NativeFieldInfoPtr_pad0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "pad0");
			NativeFieldInfoPtr_pad1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "pad1");
			NativeFieldInfoPtr_pad2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "pad2");
			NativeFieldInfoPtr_pad3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "pad3");
			NativeFieldInfoPtr_pad4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "pad4");
			NativeFieldInfoPtr_pad5 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, "pad5");
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<DimensionCollisionData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_PositionTransform;

	private static readonly System.IntPtr NativeFieldInfoPtr_Behaviour;

	private static readonly System.IntPtr NativeFieldInfoPtr_DimensionsRendererFeature;

	private static readonly System.IntPtr NativeFieldInfoPtr_VfxTransform;

	private static readonly System.IntPtr NativeFieldInfoPtr_UnscaledVfxTransform;

	private static readonly System.IntPtr NativeFieldInfoPtr_MeshFilter;

	private static readonly System.IntPtr NativeFieldInfoPtr_MeshRenderer;

	private static readonly System.IntPtr NativeFieldInfoPtr_MaskMaterial;

	private static readonly System.IntPtr NativeFieldInfoPtr_ParticleSystems;

	private static readonly System.IntPtr NativeFieldInfoPtr_CollisionDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr_CollisionFollowSpeed;

	private static readonly System.IntPtr NativeFieldInfoPtr_GlitchTextureFeature;

	private static readonly System.IntPtr NativeFieldInfoPtr_FrameCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_proximityMusicPlay;

	private static readonly System.IntPtr NativeFieldInfoPtr_proximityMusicPlayCombat;

	private static readonly System.IntPtr NativeFieldInfoPtr_musicIntroAudio;

	private static readonly System.IntPtr NativeFieldInfoPtr_inCombatMusicTimerDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr_audioSnapshotEvent;

	private static readonly System.IntPtr NativeFieldInfoPtr_localPlayerIsInCombat;

	private static readonly System.IntPtr NativeFieldInfoPtr_localPlayerInCombatTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_ClProcessCharsRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_triggerCollider;

	private static readonly System.IntPtr NativeFieldInfoPtr_displayNameStr;

	private static readonly System.IntPtr NativeFieldInfoPtr_DimensionPropertyBlock;

	private static readonly System.IntPtr NativeFieldInfoPtr_movingTransitionDelay;

	private static readonly System.IntPtr NativeFieldInfoPtr_movingStartDelay;

	private static readonly System.IntPtr NativeFieldInfoPtr__collisionData;

	private static readonly System.IntPtr NativeFieldInfoPtr__lastPosition;

	private static readonly System.IntPtr NativeFieldInfoPtr__positionDelta;

	private static readonly System.IntPtr NativeFieldInfoPtr__positionDeltaSpeed;

	private static readonly System.IntPtr NativeFieldInfoPtr__clProcessCharsTime;

	private static readonly System.IntPtr NativeFieldInfoPtr__clLocalCharInDimension;

	private static readonly System.IntPtr NativeFieldInfoPtr__clLocalSnapshotInstance;

	private static readonly System.IntPtr NativeFieldInfoPtr__uiCanvasEffect;

	private static readonly System.IntPtr NativeFieldInfoPtr__uiZoneTitle;

	private static readonly System.IntPtr NativeFieldInfoPtr__hasEntered;

	private static readonly System.IntPtr NativeFieldInfoPtr__svCharsInDimension;

	private static readonly System.IntPtr NativeFieldInfoPtr__gameManager;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Id_Public_get_DimensionType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Position_Public_get_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_Position_Public_set_Void_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Radius_Public_get_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_Radius_Public_set_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Scale_Public_get_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_Scale_Public_set_Void_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdatePropertyBlock_Public_Void_Camera_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsInDimension_Public_Boolean_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsInDimension_Public_Boolean_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsNearEdge_Public_Boolean_Vector3_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_UICanvasEffect_Private_get_UICanvasEffect_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_UIZoneTitle_Private_get_UIZoneTitle_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClDimensionStart_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClDimensionEnd_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClTick_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateCollisionData_Private_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClProcessLocalCharacter_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClOnLocalCharDimensionEnter_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClOnLocalCharDimensionExit_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClOnEntityEnter_Public_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClOnEntityExit_Public_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleEntityParticleEvent_Private_Void_EntityManager_BehaviourSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleEntityRendererEvent_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddCollisionData_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetParticleSystemToEntity_Private_Static_Void_EntityManager_ParticleSystem_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetParticleSystemForwardToEntity_Private_Void_EntityManager_ParticleSystem_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ValidTriggerDistance_Private_Boolean_EntityManager_DimensionParticleSystem_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsEntityVisible_Private_Boolean_EntityManager_Camera_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_GameManager_Private_get_GameManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvDimensionStart_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvTick_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvProcessCharacterZone_Public_Void_DimensionZone_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvOnEntityEnter_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvOnEntityExit_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DrawGizmos_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Transform PositionTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PositionTransform);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PositionTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe DimensionBehaviourSO Behaviour
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Behaviour);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionBehaviourSO>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionBehaviourSO));
		}
	}

	public unsafe DimensionRendererFeature DimensionsRendererFeature
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionsRendererFeature);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionRendererFeature>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionsRendererFeature)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionRendererFeature));
		}
	}

	public unsafe Transform VfxTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_VfxTransform);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_VfxTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe Transform UnscaledVfxTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UnscaledVfxTransform);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UnscaledVfxTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe MeshFilter MeshFilter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MeshFilter);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshFilter>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MeshFilter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshFilter));
		}
	}

	public unsafe MeshRenderer MeshRenderer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MeshRenderer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshRenderer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MeshRenderer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshRenderer));
		}
	}

	public unsafe Material MaskMaterial
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskMaterial);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe Il2CppReferenceArray<DimensionParticleSystem> ParticleSystems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ParticleSystems);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<DimensionParticleSystem>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ParticleSystems)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe float CollisionDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionDuration)) = num;
		}
	}

	public unsafe float CollisionFollowSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionFollowSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CollisionFollowSpeed)) = num;
		}
	}

	public unsafe RenderObjectsToTextureFeature GlitchTextureFeature
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GlitchTextureFeature);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RenderObjectsToTextureFeature>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GlitchTextureFeature)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)renderObjectsToTextureFeature));
		}
	}

	public unsafe int FrameCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FrameCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_FrameCount)) = num;
		}
	}

	public unsafe AudioProximityMusicPlay proximityMusicPlay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_proximityMusicPlay);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioProximityMusicPlay>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_proximityMusicPlay)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioProximityMusicPlay));
		}
	}

	public unsafe AudioProximityMusicPlay proximityMusicPlayCombat
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_proximityMusicPlayCombat);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioProximityMusicPlay>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_proximityMusicPlayCombat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioProximityMusicPlay));
		}
	}

	public unsafe AudioClipData musicIntroAudio
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_musicIntroAudio);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_musicIntroAudio)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe float inCombatMusicTimerDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inCombatMusicTimerDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inCombatMusicTimerDuration)) = num;
		}
	}

	public unsafe EventReference audioSnapshotEvent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioSnapshotEvent);
			return *(EventReference*)num;
		}
		set
		{
			*(EventReference*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioSnapshotEvent)) = eventReference;
		}
	}

	public unsafe bool localPlayerIsInCombat
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localPlayerIsInCombat);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localPlayerIsInCombat)) = flag;
		}
	}

	public unsafe float localPlayerInCombatTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localPlayerInCombatTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localPlayerInCombatTimer)) = num;
		}
	}

	public unsafe float ClProcessCharsRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ClProcessCharsRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ClProcessCharsRate)) = num;
		}
	}

	public unsafe DimensionDetectCollider triggerCollider
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerCollider);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionDetectCollider>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerCollider)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionDetectCollider));
		}
	}

	public unsafe string displayNameStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_displayNameStr);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_displayNameStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe MaterialPropertyBlock DimensionPropertyBlock
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionPropertyBlock);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MaterialPropertyBlock>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionPropertyBlock)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)materialPropertyBlock));
		}
	}

	public unsafe bool movingTransitionDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_movingTransitionDelay);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_movingTransitionDelay)) = flag;
		}
	}

	public unsafe bool movingStartDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_movingStartDelay);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_movingStartDelay)) = flag;
		}
	}

	public unsafe List<DimensionCollisionDataHolder> _collisionData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__collisionData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<DimensionCollisionDataHolder>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__collisionData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Vector3 _lastPosition
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lastPosition);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lastPosition)) = vector;
		}
	}

	public unsafe Vector3 _positionDelta
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__positionDelta);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__positionDelta)) = vector;
		}
	}

	public unsafe float _positionDeltaSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__positionDeltaSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__positionDeltaSpeed)) = num;
		}
	}

	public unsafe float _clProcessCharsTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clProcessCharsTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clProcessCharsTime)) = num;
		}
	}

	public unsafe EntityManager _clLocalCharInDimension
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clLocalCharInDimension);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clLocalCharInDimension)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager));
		}
	}

	public unsafe EventInstance _clLocalSnapshotInstance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clLocalSnapshotInstance);
			return *(EventInstance*)num;
		}
		set
		{
			*(EventInstance*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clLocalSnapshotInstance)) = eventInstance;
		}
	}

	public unsafe UICanvasEffect _uiCanvasEffect
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiCanvasEffect);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UICanvasEffect>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiCanvasEffect)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uICanvasEffect));
		}
	}

	public unsafe UIZoneTitle _uiZoneTitle
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiZoneTitle);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIZoneTitle>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiZoneTitle)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIZoneTitle));
		}
	}

	public unsafe bool _hasEntered
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__hasEntered);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__hasEntered)) = flag;
		}
	}

	public unsafe List<EntityManager> _svCharsInDimension
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__svCharsInDimension);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<EntityManager>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__svCharsInDimension)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe GameManager _gameManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameManager));
		}
	}

	public unsafe DimensionType Id
	{
		[CallerCount(8)]
		[CachedScanResults(RefRangeStart = 120205, RefRangeEnd = 120213, XrefRangeStart = 120205, XrefRangeEnd = 120205, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Id_Public_get_DimensionType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(DimensionType*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Vector3 Position
	{
		[CallerCount(47)]
		[CachedScanResults(RefRangeStart = 120217, RefRangeEnd = 120264, XrefRangeStart = 120213, XrefRangeEnd = 120217, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Position_Public_get_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 120268, RefRangeEnd = 120272, XrefRangeStart = 120264, XrefRangeEnd = 120268, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_Position_Public_set_Void_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe float Radius
	{
		[CallerCount(49)]
		[CachedScanResults(RefRangeStart = 120277, RefRangeEnd = 120326, XrefRangeStart = 120272, XrefRangeEnd = 120277, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Radius_Public_get_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 120340, RefRangeEnd = 120341, XrefRangeStart = 120326, XrefRangeEnd = 120340, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_Radius_Public_set_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe Vector3 Scale
	{
		[CallerCount(5)]
		[CachedScanResults(RefRangeStart = 120346, RefRangeEnd = 120351, XrefRangeStart = 120341, XrefRangeEnd = 120346, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Scale_Public_get_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 120363, RefRangeEnd = 120367, XrefRangeStart = 120351, XrefRangeEnd = 120363, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_Scale_Public_set_Void_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe UICanvasEffect UICanvasEffect
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 120411, RefRangeEnd = 120413, XrefRangeStart = 120407, XrefRangeEnd = 120411, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_UICanvasEffect_Private_get_UICanvasEffect_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UICanvasEffect>(intPtr) : null;
		}
	}

	public unsafe UIZoneTitle UIZoneTitle
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120413, XrefRangeEnd = 120417, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_UIZoneTitle_Private_get_UIZoneTitle_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIZoneTitle>(intPtr) : null;
		}
	}

	public unsafe GameManager GameManager
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120634, XrefRangeEnd = 120639, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_GameManager_Private_get_GameManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameManager>(intPtr) : null;
		}
	}

	static Dimension()
	{
		Il2CppClassPointerStore<Dimension>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game.Dimensions", "Dimension");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Dimension>.NativeClassPtr);
		NativeFieldInfoPtr_PositionTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "PositionTransform");
		NativeFieldInfoPtr_Behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "Behaviour");
		NativeFieldInfoPtr_DimensionsRendererFeature = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "DimensionsRendererFeature");
		NativeFieldInfoPtr_VfxTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "VfxTransform");
		NativeFieldInfoPtr_UnscaledVfxTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "UnscaledVfxTransform");
		NativeFieldInfoPtr_MeshFilter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "MeshFilter");
		NativeFieldInfoPtr_MeshRenderer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "MeshRenderer");
		NativeFieldInfoPtr_MaskMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "MaskMaterial");
		NativeFieldInfoPtr_ParticleSystems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "ParticleSystems");
		NativeFieldInfoPtr_CollisionDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "CollisionDuration");
		NativeFieldInfoPtr_CollisionFollowSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "CollisionFollowSpeed");
		NativeFieldInfoPtr_GlitchTextureFeature = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "GlitchTextureFeature");
		NativeFieldInfoPtr_FrameCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "FrameCount");
		NativeFieldInfoPtr_proximityMusicPlay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "proximityMusicPlay");
		NativeFieldInfoPtr_proximityMusicPlayCombat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "proximityMusicPlayCombat");
		NativeFieldInfoPtr_musicIntroAudio = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "musicIntroAudio");
		NativeFieldInfoPtr_inCombatMusicTimerDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "inCombatMusicTimerDuration");
		NativeFieldInfoPtr_audioSnapshotEvent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "audioSnapshotEvent");
		NativeFieldInfoPtr_localPlayerIsInCombat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "localPlayerIsInCombat");
		NativeFieldInfoPtr_localPlayerInCombatTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "localPlayerInCombatTimer");
		NativeFieldInfoPtr_ClProcessCharsRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "ClProcessCharsRate");
		NativeFieldInfoPtr_triggerCollider = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "triggerCollider");
		NativeFieldInfoPtr_displayNameStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "displayNameStr");
		NativeFieldInfoPtr_DimensionPropertyBlock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "DimensionPropertyBlock");
		NativeFieldInfoPtr_movingTransitionDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "movingTransitionDelay");
		NativeFieldInfoPtr_movingStartDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "movingStartDelay");
		NativeFieldInfoPtr__collisionData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_collisionData");
		NativeFieldInfoPtr__lastPosition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_lastPosition");
		NativeFieldInfoPtr__positionDelta = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_positionDelta");
		NativeFieldInfoPtr__positionDeltaSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_positionDeltaSpeed");
		NativeFieldInfoPtr__clProcessCharsTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_clProcessCharsTime");
		NativeFieldInfoPtr__clLocalCharInDimension = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_clLocalCharInDimension");
		NativeFieldInfoPtr__clLocalSnapshotInstance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_clLocalSnapshotInstance");
		NativeFieldInfoPtr__uiCanvasEffect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_uiCanvasEffect");
		NativeFieldInfoPtr__uiZoneTitle = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_uiZoneTitle");
		NativeFieldInfoPtr__hasEntered = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_hasEntered");
		NativeFieldInfoPtr__svCharsInDimension = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_svCharsInDimension");
		NativeFieldInfoPtr__gameManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Dimension>.NativeClassPtr, "_gameManager");
		NativeMethodInfoPtr_get_Id_Public_get_DimensionType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672764);
		NativeMethodInfoPtr_get_Position_Public_get_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672765);
		NativeMethodInfoPtr_set_Position_Public_set_Void_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672766);
		NativeMethodInfoPtr_get_Radius_Public_get_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672767);
		NativeMethodInfoPtr_set_Radius_Public_set_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672768);
		NativeMethodInfoPtr_get_Scale_Public_get_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672769);
		NativeMethodInfoPtr_set_Scale_Public_set_Void_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672770);
		NativeMethodInfoPtr_UpdatePropertyBlock_Public_Void_Camera_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672771);
		NativeMethodInfoPtr_IsInDimension_Public_Boolean_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672772);
		NativeMethodInfoPtr_IsInDimension_Public_Boolean_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672773);
		NativeMethodInfoPtr_IsNearEdge_Public_Boolean_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672774);
		NativeMethodInfoPtr_get_UICanvasEffect_Private_get_UICanvasEffect_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672775);
		NativeMethodInfoPtr_get_UIZoneTitle_Private_get_UIZoneTitle_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672776);
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672777);
		NativeMethodInfoPtr_ClDimensionStart_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672778);
		NativeMethodInfoPtr_ClDimensionEnd_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672779);
		NativeMethodInfoPtr_ClTick_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672780);
		NativeMethodInfoPtr_UpdateCollisionData_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672781);
		NativeMethodInfoPtr_ClProcessLocalCharacter_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672782);
		NativeMethodInfoPtr_ClOnLocalCharDimensionEnter_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672783);
		NativeMethodInfoPtr_ClOnLocalCharDimensionExit_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672784);
		NativeMethodInfoPtr_ClOnEntityEnter_Public_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672785);
		NativeMethodInfoPtr_ClOnEntityExit_Public_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672786);
		NativeMethodInfoPtr_HandleEntityParticleEvent_Private_Void_EntityManager_BehaviourSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672787);
		NativeMethodInfoPtr_HandleEntityRendererEvent_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672788);
		NativeMethodInfoPtr_AddCollisionData_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672789);
		NativeMethodInfoPtr_SetParticleSystemToEntity_Private_Static_Void_EntityManager_ParticleSystem_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672790);
		NativeMethodInfoPtr_SetParticleSystemForwardToEntity_Private_Void_EntityManager_ParticleSystem_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672791);
		NativeMethodInfoPtr_ValidTriggerDistance_Private_Boolean_EntityManager_DimensionParticleSystem_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672792);
		NativeMethodInfoPtr_IsEntityVisible_Private_Boolean_EntityManager_Camera_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672793);
		NativeMethodInfoPtr_get_GameManager_Private_get_GameManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672794);
		NativeMethodInfoPtr_SvDimensionStart_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672795);
		NativeMethodInfoPtr_SvTick_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672796);
		NativeMethodInfoPtr_SvProcessCharacterZone_Public_Void_DimensionZone_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672797);
		NativeMethodInfoPtr_SvOnEntityEnter_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672798);
		NativeMethodInfoPtr_SvOnEntityExit_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672799);
		NativeMethodInfoPtr_DrawGizmos_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672800);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Dimension>.NativeClassPtr, 100672801);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120388, RefRangeEnd = 120389, XrefRangeStart = 120367, XrefRangeEnd = 120388, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdatePropertyBlock(Camera cam)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cam);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdatePropertyBlock_Public_Void_Camera_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120389, XrefRangeEnd = 120393, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsInDimension(Transform transform)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsInDimension_Public_Boolean_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120396, RefRangeEnd = 120397, XrefRangeStart = 120393, XrefRangeEnd = 120396, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsInDimension(Vector3 position)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&position);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsInDimension_Public_Boolean_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 120403, RefRangeEnd = 120407, XrefRangeStart = 120397, XrefRangeEnd = 120403, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsNearEdge(Vector3 position, float distFromEdge)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&position);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &distFromEdge;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsNearEdge_Public_Boolean_Vector3_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120417, XrefRangeEnd = 120418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120418, XrefRangeEnd = 120427, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClDimensionStart()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClDimensionStart_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120427, XrefRangeEnd = 120437, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClDimensionEnd()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClDimensionEnd_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120450, RefRangeEnd = 120451, XrefRangeStart = 120437, XrefRangeEnd = 120450, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClTick(float deltaTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&deltaTime);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClTick_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120451, XrefRangeEnd = 120457, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateCollisionData(float deltaTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&deltaTime);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateCollisionData_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120474, RefRangeEnd = 120475, XrefRangeStart = 120457, XrefRangeEnd = 120474, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClProcessLocalCharacter()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClProcessLocalCharacter_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120475, XrefRangeEnd = 120506, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClOnLocalCharDimensionEnter(EntityManager entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClOnLocalCharDimensionEnter_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120530, RefRangeEnd = 120531, XrefRangeStart = 120506, XrefRangeEnd = 120530, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClOnLocalCharDimensionExit(EntityManager entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClOnLocalCharDimensionExit_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120531, XrefRangeEnd = 120533, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClOnEntityEnter(EntityManager entity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClOnEntityEnter_Public_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120533, XrefRangeEnd = 120535, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClOnEntityExit(EntityManager entity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClOnEntityExit_Public_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 120552, RefRangeEnd = 120556, XrefRangeStart = 120535, XrefRangeEnd = 120552, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleEntityParticleEvent(EntityManager entity, DimensionParticleSystem.BehaviourSettings eventSetting)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(DimensionParticleSystem.BehaviourSettings**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &eventSetting;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleEntityParticleEvent_Private_Void_EntityManager_BehaviourSettings_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 120566, RefRangeEnd = 120570, XrefRangeStart = 120556, XrefRangeEnd = 120566, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleEntityRendererEvent(EntityManager entity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleEntityRendererEvent_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120590, RefRangeEnd = 120591, XrefRangeStart = 120570, XrefRangeEnd = 120590, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddCollisionData(EntityManager entity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddCollisionData_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120602, RefRangeEnd = 120603, XrefRangeStart = 120591, XrefRangeEnd = 120602, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetParticleSystemToEntity(EntityManager entity, ParticleSystem ps)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ps);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetParticleSystemToEntity_Private_Static_Void_EntityManager_ParticleSystem_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120616, RefRangeEnd = 120617, XrefRangeStart = 120603, XrefRangeEnd = 120616, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetParticleSystemForwardToEntity(EntityManager entity, ParticleSystem ps)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ps);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetParticleSystemForwardToEntity_Private_Void_EntityManager_ParticleSystem_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120621, RefRangeEnd = 120622, XrefRangeStart = 120617, XrefRangeEnd = 120621, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool ValidTriggerDistance(EntityManager entity, DimensionParticleSystem dps)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dps);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ValidTriggerDistance_Private_Boolean_EntityManager_DimensionParticleSystem_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 120632, RefRangeEnd = 120634, XrefRangeStart = 120622, XrefRangeEnd = 120632, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsEntityVisible(EntityManager entity, Camera cam)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cam);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsEntityVisible_Private_Boolean_EntityManager_Camera_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120639, XrefRangeEnd = 120643, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SvDimensionStart()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SvDimensionStart_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SvTick(float deltaTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&deltaTime);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SvTick_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 120647, RefRangeEnd = 120649, XrefRangeStart = 120643, XrefRangeEnd = 120647, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SvProcessCharacterZone(DimensionZone zone, EntityManager entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)zone);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SvProcessCharacterZone_Public_Void_DimensionZone_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120649, XrefRangeEnd = 120682, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SvOnEntityEnter(EntityManager entity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SvOnEntityEnter_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 120711, RefRangeEnd = 120712, XrefRangeStart = 120682, XrefRangeEnd = 120711, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SvOnEntityExit(EntityManager entity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SvOnEntityExit_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120712, XrefRangeEnd = 120724, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DrawGizmos()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DrawGizmos_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 120724, XrefRangeEnd = 120733, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Dimension()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Dimension>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public Dimension(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
