using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppBAPBAP.Local;
using Il2CppFMOD;
using Il2CppFMOD.Studio;
using Il2CppFMODUnity;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;
using UnityEngine.Rendering;

namespace Il2CppBAPBAP.UI;

public class UI3DBackgroundWaitingRoom : UI3DBackground
{
	private static readonly IntPtr NativeFieldInfoPtr__parallaxTargetController;

	private static readonly IntPtr NativeFieldInfoPtr__selectableController;

	private static readonly IntPtr NativeFieldInfoPtr__backgroundRenderFeature;

	private static readonly IntPtr NativeFieldInfoPtr__camera;

	private static readonly IntPtr NativeFieldInfoPtr__postProcessingVolume;

	private static readonly IntPtr NativeFieldInfoPtr__directionalLight;

	private static readonly IntPtr NativeFieldInfoPtr__fmodEmitter;

	private static readonly IntPtr NativeFieldInfoPtr__onPlayPage;

	private static readonly IntPtr NativeFieldInfoPtr__uiManager;

	private static readonly IntPtr NativeFieldInfoPtr_MusicVolume;

	private static readonly IntPtr NativeFieldInfoPtr__generalBusGuid;

	private static readonly IntPtr NativeFieldInfoPtr__musicBusGuid;

	private static readonly IntPtr NativeFieldInfoPtr__generalBus;

	private static readonly IntPtr NativeFieldInfoPtr__musicBus;

	private static readonly IntPtr NativeFieldInfoPtr__bussesInitialized;

	private static readonly IntPtr NativeMethodInfoPtr_Build_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InitializeBusses_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Protected_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetVolumeShaderProperty_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetContentActive_Public_Virtual_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleCameras_Private_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetBackgrounded_Public_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDestroy_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe ParallaxTargetController _parallaxTargetController
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__parallaxTargetController);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ParallaxTargetController>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__parallaxTargetController)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parallaxTargetController));
		}
	}

	public unsafe SelectableController _selectableController
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__selectableController);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SelectableController>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__selectableController)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectableController));
		}
	}

	public unsafe RenderObjectsToTextureFeature _backgroundRenderFeature
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__backgroundRenderFeature);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RenderObjectsToTextureFeature>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__backgroundRenderFeature)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)renderObjectsToTextureFeature));
		}
	}

	public unsafe Camera _camera
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__camera);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Camera>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__camera)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)camera));
		}
	}

	public unsafe Volume _postProcessingVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__postProcessingVolume);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Volume>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__postProcessingVolume)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)volume));
		}
	}

	public unsafe Light _directionalLight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__directionalLight);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__directionalLight)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)light));
		}
	}

	public unsafe StudioEventEmitter _fmodEmitter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fmodEmitter);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<StudioEventEmitter>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fmodEmitter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)studioEventEmitter));
		}
	}

	public unsafe bool _onPlayPage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__onPlayPage);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__onPlayPage)) = flag;
		}
	}

	public unsafe UIManager _uiManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UIManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIManager));
		}
	}

	public unsafe static int MusicVolume
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_MusicVolume, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_MusicVolume, (void*)(&num));
		}
	}

	public unsafe GUID _generalBusGuid
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__generalBusGuid);
			return *(GUID*)num;
		}
		set
		{
			*(GUID*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__generalBusGuid)) = gUID;
		}
	}

	public unsafe GUID _musicBusGuid
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__musicBusGuid);
			return *(GUID*)num;
		}
		set
		{
			*(GUID*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__musicBusGuid)) = gUID;
		}
	}

	public unsafe Bus _generalBus
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__generalBus);
			return *(Bus*)num;
		}
		set
		{
			*(Bus*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__generalBus)) = bus;
		}
	}

	public unsafe Bus _musicBus
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__musicBus);
			return *(Bus*)num;
		}
		set
		{
			*(Bus*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__musicBus)) = bus;
		}
	}

	public unsafe bool _bussesInitialized
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__bussesInitialized);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__bussesInitialized)) = flag;
		}
	}

	static UI3DBackgroundWaitingRoom()
	{
		Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UI3DBackgroundWaitingRoom");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr);
		NativeFieldInfoPtr__parallaxTargetController = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_parallaxTargetController");
		NativeFieldInfoPtr__selectableController = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_selectableController");
		NativeFieldInfoPtr__backgroundRenderFeature = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_backgroundRenderFeature");
		NativeFieldInfoPtr__camera = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_camera");
		NativeFieldInfoPtr__postProcessingVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_postProcessingVolume");
		NativeFieldInfoPtr__directionalLight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_directionalLight");
		NativeFieldInfoPtr__fmodEmitter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_fmodEmitter");
		NativeFieldInfoPtr__onPlayPage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_onPlayPage");
		NativeFieldInfoPtr__uiManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_uiManager");
		NativeFieldInfoPtr_MusicVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "MusicVolume");
		NativeFieldInfoPtr__generalBusGuid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_generalBusGuid");
		NativeFieldInfoPtr__musicBusGuid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_musicBusGuid");
		NativeFieldInfoPtr__generalBus = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_generalBus");
		NativeFieldInfoPtr__musicBus = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_musicBus");
		NativeFieldInfoPtr__bussesInitialized = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, "_bussesInitialized");
		NativeMethodInfoPtr_Build_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671209);
		NativeMethodInfoPtr_InitializeBusses_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671210);
		NativeMethodInfoPtr_Update_Protected_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671211);
		NativeMethodInfoPtr_SetVolumeShaderProperty_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671212);
		NativeMethodInfoPtr_SetContentActive_Public_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671213);
		NativeMethodInfoPtr_ToggleCameras_Private_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671214);
		NativeMethodInfoPtr_SetBackgrounded_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671215);
		NativeMethodInfoPtr_OnDestroy_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671216);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr, 100671217);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107965, XrefRangeEnd = 107977, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Build()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Build_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107977, XrefRangeEnd = 107989, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeBusses()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeBusses_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107989, XrefRangeEnd = 108007, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Update_Protected_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 108007, XrefRangeEnd = 108012, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetVolumeShaderProperty()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetVolumeShaderProperty_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 108012, XrefRangeEnd = 108015, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SetContentActive(bool active)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&active);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SetContentActive_Public_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 108040, RefRangeEnd = 108041, XrefRangeStart = 108015, XrefRangeEnd = 108040, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleCameras(bool active)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&active);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleCameras_Private_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void SetBackgrounded(bool backgrounded)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&backgrounded);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetBackgrounded_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void OnDestroy()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDestroy_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UI3DBackgroundWaitingRoom()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UI3DBackgroundWaitingRoom>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UI3DBackgroundWaitingRoom(IntPtr pointer)
		: base(pointer)
	{
	}
}
