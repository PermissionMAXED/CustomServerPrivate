using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppBAPBAP.Game.Dimensions;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class DimensionManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_dimensions;

	private static readonly IntPtr NativeFieldInfoPtr_dimensionRendererFeature;

	private static readonly IntPtr NativeFieldInfoPtr_dimensionTextures;

	private static readonly IntPtr NativeFieldInfoPtr_dimensionLUTs;

	private static readonly IntPtr NativeFieldInfoPtr__dimensionRenderingDataBuffer;

	private static readonly IntPtr NativeFieldInfoPtr__dimensionRenderingData;

	private static readonly IntPtr NativeFieldInfoPtr__dimensionTextureArray;

	private static readonly IntPtr NativeFieldInfoPtr__dimensionLUTArray;

	private static readonly IntPtr NativeFieldInfoPtr_DimensionsRenderingDataID;

	private static readonly IntPtr NativeFieldInfoPtr_DimensionTexturesID;

	private static readonly IntPtr NativeFieldInfoPtr_DimensionLUTsID;

	private static readonly IntPtr NativeFieldInfoPtr_activeDimensions;

	private static readonly IntPtr NativeFieldInfoPtr_Instance;

	private static readonly IntPtr NativeMethodInfoPtr_GetDimensions_Public_List_1_Dimension_0;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDestroy_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_DimensionTextureArray_Private_Texture2DArray_0;

	private static readonly IntPtr NativeMethodInfoPtr_DimensionLUTArray_Private_Texture2DArray_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateRenderingDataBuffers_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_DisposeRenderingDataBuffers_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddDimension_Public_Void_Dimension_0;

	private static readonly IntPtr NativeMethodInfoPtr_RemoveDimension_Public_Void_Dimension_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetDimensionConfig_Public_DimensionBehaviourSO_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnDimension_Public_Void_Int32_Vector3_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<DimensionBehaviourSO> dimensions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensions);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<DimensionBehaviourSO>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensions)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe DimensionRendererFeature dimensionRendererFeature
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionRendererFeature);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DimensionRendererFeature>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionRendererFeature)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionRendererFeature));
		}
	}

	public unsafe Il2CppReferenceArray<Texture2D> dimensionTextures
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionTextures);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Texture2D>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionTextures)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Texture2D> dimensionLUTs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionLUTs);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Texture2D>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionLUTs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe ComputeBuffer _dimensionRenderingDataBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionRenderingDataBuffer);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ComputeBuffer>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionRenderingDataBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)computeBuffer));
		}
	}

	public unsafe Il2CppStructArray<DimensionBehaviourSO.DimensionRenderingData> _dimensionRenderingData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionRenderingData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<DimensionBehaviourSO.DimensionRenderingData>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionRenderingData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Texture2DArray _dimensionTextureArray
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionTextureArray);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2DArray>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionTextureArray)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2DArray));
		}
	}

	public unsafe Texture2DArray _dimensionLUTArray
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionLUTArray);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2DArray>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dimensionLUTArray)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2DArray));
		}
	}

	public unsafe static int DimensionsRenderingDataID
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_DimensionsRenderingDataID, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_DimensionsRenderingDataID, (void*)(&num));
		}
	}

	public unsafe static int DimensionTexturesID
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_DimensionTexturesID, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_DimensionTexturesID, (void*)(&num));
		}
	}

	public unsafe static int DimensionLUTsID
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_DimensionLUTsID, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_DimensionLUTsID, (void*)(&num));
		}
	}

	public unsafe List<Dimension> activeDimensions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_activeDimensions);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Dimension>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_activeDimensions)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe static DimensionManager Instance
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Instance, (void*)(&intPtr));
			IntPtr intPtr2 = intPtr;
			return (intPtr2 != (IntPtr)0) ? Il2CppObjectPool.Get<DimensionManager>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Instance, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionManager));
		}
	}

	static DimensionManager()
	{
		Il2CppClassPointerStore<DimensionManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "DimensionManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr);
		NativeFieldInfoPtr_dimensions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "dimensions");
		NativeFieldInfoPtr_dimensionRendererFeature = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "dimensionRendererFeature");
		NativeFieldInfoPtr_dimensionTextures = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "dimensionTextures");
		NativeFieldInfoPtr_dimensionLUTs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "dimensionLUTs");
		NativeFieldInfoPtr__dimensionRenderingDataBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "_dimensionRenderingDataBuffer");
		NativeFieldInfoPtr__dimensionRenderingData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "_dimensionRenderingData");
		NativeFieldInfoPtr__dimensionTextureArray = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "_dimensionTextureArray");
		NativeFieldInfoPtr__dimensionLUTArray = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "_dimensionLUTArray");
		NativeFieldInfoPtr_DimensionsRenderingDataID = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "DimensionsRenderingDataID");
		NativeFieldInfoPtr_DimensionTexturesID = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "DimensionTexturesID");
		NativeFieldInfoPtr_DimensionLUTsID = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "DimensionLUTsID");
		NativeFieldInfoPtr_activeDimensions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "activeDimensions");
		NativeFieldInfoPtr_Instance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, "Instance");
		NativeMethodInfoPtr_GetDimensions_Public_List_1_Dimension_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684230);
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684231);
		NativeMethodInfoPtr_OnDestroy_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684232);
		NativeMethodInfoPtr_DimensionTextureArray_Private_Texture2DArray_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684233);
		NativeMethodInfoPtr_DimensionLUTArray_Private_Texture2DArray_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684234);
		NativeMethodInfoPtr_UpdateRenderingDataBuffers_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684235);
		NativeMethodInfoPtr_DisposeRenderingDataBuffers_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684236);
		NativeMethodInfoPtr_AddDimension_Public_Void_Dimension_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684237);
		NativeMethodInfoPtr_RemoveDimension_Public_Void_Dimension_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684238);
		NativeMethodInfoPtr_GetDimensionConfig_Public_DimensionBehaviourSO_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684239);
		NativeMethodInfoPtr_SpawnDimension_Public_Void_Int32_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684240);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr, 100684241);
	}

	[CallerCount(12)]
	[CachedScanResults(RefRangeStart = 89864, RefRangeEnd = 89876, XrefRangeStart = 89864, XrefRangeEnd = 89876, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe List<Dimension> GetDimensions()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDimensions_Public_List_1_Dimension_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Dimension>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225930, XrefRangeEnd = 225937, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225937, XrefRangeEnd = 225948, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDestroy()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDestroy_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 225960, RefRangeEnd = 225961, XrefRangeStart = 225948, XrefRangeEnd = 225960, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Texture2DArray DimensionTextureArray()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DimensionTextureArray_Private_Texture2DArray_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2DArray>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 225973, RefRangeEnd = 225974, XrefRangeStart = 225961, XrefRangeEnd = 225973, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Texture2DArray DimensionLUTArray()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DimensionLUTArray_Private_Texture2DArray_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2DArray>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 225997, RefRangeEnd = 225999, XrefRangeStart = 225974, XrefRangeEnd = 225997, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateRenderingDataBuffers()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateRenderingDataBuffers_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225999, XrefRangeEnd = 226004, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DisposeRenderingDataBuffers()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DisposeRenderingDataBuffers_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226008, RefRangeEnd = 226010, XrefRangeStart = 226004, XrefRangeEnd = 226008, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddDimension(Dimension dimension)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimension);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddDimension_Public_Void_Dimension_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226014, RefRangeEnd = 226016, XrefRangeStart = 226010, XrefRangeEnd = 226014, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RemoveDimension(Dimension dimension)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimension);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveDimension_Public_Void_Dimension_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 226016, RefRangeEnd = 226024, XrefRangeStart = 226016, XrefRangeEnd = 226016, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe DimensionBehaviourSO GetDimensionConfig(int dimensionId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&dimensionId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDimensionConfig_Public_DimensionBehaviourSO_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DimensionBehaviourSO>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226052, RefRangeEnd = 226054, XrefRangeStart = 226024, XrefRangeEnd = 226052, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnDimension(int dimensionId, Vector3 spawnPos, float radius)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&dimensionId);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &spawnPos;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &radius;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnDimension_Public_Void_Int32_Vector3_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226054, XrefRangeEnd = 226059, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe DimensionManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DimensionManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public DimensionManager(IntPtr pointer)
		: base(pointer)
	{
	}
}
