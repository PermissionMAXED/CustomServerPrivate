using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class MinimapTextureRenderer : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_quadMesh;

	private static readonly IntPtr NativeFieldInfoPtr_circleMesh;

	private static readonly IntPtr NativeFieldInfoPtr_minimapBlitMat;

	private static readonly IntPtr NativeFieldInfoPtr_minResolution;

	private static readonly IntPtr NativeFieldInfoPtr_texResolutionMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_antialiasingSamples;

	private static readonly IntPtr NativeFieldInfoPtr_minColliderSize;

	private static readonly IntPtr NativeFieldInfoPtr_circleMeshExpand;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Mesh quadMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_quadMesh);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_quadMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe Mesh circleMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_circleMesh);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_circleMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe Material minimapBlitMat
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapBlitMat);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapBlitMat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe int minResolution
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minResolution);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minResolution)) = num;
		}
	}

	public unsafe float texResolutionMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_texResolutionMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_texResolutionMultiplier)) = num;
		}
	}

	public unsafe int antialiasingSamples
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_antialiasingSamples);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_antialiasingSamples)) = num;
		}
	}

	public unsafe float minColliderSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minColliderSize);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minColliderSize)) = num;
		}
	}

	public unsafe float circleMeshExpand
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_circleMeshExpand);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_circleMeshExpand)) = num;
		}
	}

	static MinimapTextureRenderer()
	{
		Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "MinimapTextureRenderer");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr);
		NativeFieldInfoPtr_quadMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "quadMesh");
		NativeFieldInfoPtr_circleMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "circleMesh");
		NativeFieldInfoPtr_minimapBlitMat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "minimapBlitMat");
		NativeFieldInfoPtr_minResolution = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "minResolution");
		NativeFieldInfoPtr_texResolutionMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "texResolutionMultiplier");
		NativeFieldInfoPtr_antialiasingSamples = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "antialiasingSamples");
		NativeFieldInfoPtr_minColliderSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "minColliderSize");
		NativeFieldInfoPtr_circleMeshExpand = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, "circleMeshExpand");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr, 100684980);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 231677, XrefRangeEnd = 231678, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MinimapTextureRenderer()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MinimapTextureRenderer>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MinimapTextureRenderer(IntPtr pointer)
		: base(pointer)
	{
	}
}
