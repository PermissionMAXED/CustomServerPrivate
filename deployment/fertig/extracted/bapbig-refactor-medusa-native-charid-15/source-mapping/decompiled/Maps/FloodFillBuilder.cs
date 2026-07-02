using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace Il2CppBAPBAP.Maps;

public static class FloodFillBuilder : Il2CppSystem.Object
{
	public sealed class IsValid : Il2CppSystem.MulticastDelegate
	{
		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Object_IntPtr_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Invoke_Public_Virtual_New_Boolean_Point_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_BeginInvoke_Public_Virtual_New_IAsyncResult_Point_AsyncCallback_Object_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_EndInvoke_Public_Virtual_New_Boolean_IAsyncResult_0;

		static IsValid()
		{
			Il2CppClassPointerStore<IsValid>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FloodFillBuilder>.NativeClassPtr, "IsValid");
			NativeMethodInfoPtr__ctor_Public_Void_Object_IntPtr_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IsValid>.NativeClassPtr, 100685404);
			NativeMethodInfoPtr_Invoke_Public_Virtual_New_Boolean_Point_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IsValid>.NativeClassPtr, 100685405);
			NativeMethodInfoPtr_BeginInvoke_Public_Virtual_New_IAsyncResult_Point_AsyncCallback_Object_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IsValid>.NativeClassPtr, 100685406);
			NativeMethodInfoPtr_EndInvoke_Public_Virtual_New_Boolean_IAsyncResult_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IsValid>.NativeClassPtr, 100685407);
		}

		[CallerCount(30)]
		[CachedScanResults(RefRangeStart = 236383, RefRangeEnd = 236413, XrefRangeStart = 236382, XrefRangeEnd = 236383, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe IsValid(Il2CppSystem.Object @object, System.IntPtr method)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<IsValid>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)@object);
			*(System.IntPtr**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &method;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Object_IntPtr_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe virtual bool Invoke(Point p)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&p);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Invoke_Public_Virtual_New_Boolean_Point_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236413, XrefRangeEnd = 236416, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual Il2CppSystem.IAsyncResult BeginInvoke(Point p, Il2CppSystem.AsyncCallback callback, Il2CppSystem.Object @object)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&p);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)callback);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)@object);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BeginInvoke_Public_Virtual_New_IAsyncResult_Point_AsyncCallback_Object_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.IAsyncResult>(intPtr) : null;
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual bool EndInvoke(Il2CppSystem.IAsyncResult result)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)result);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_EndInvoke_Public_Virtual_New_Boolean_IAsyncResult_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public IsValid(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public static implicit operator IsValid(System.Func<Point, bool> P_0)
		{
			return DelegateSupport.ConvertDelegate<IsValid>((System.Delegate)P_0);
		}

		public static IsValid operator +(IsValid P_0, IsValid P_1)
		{
			return ((Il2CppObjectBase)Il2CppSystem.Delegate.Combine(P_0, P_1)).Cast<IsValid>();
		}

		public static IsValid operator -(IsValid P_0, IsValid P_1)
		{
			object obj = Il2CppSystem.Delegate.Remove(P_0, P_1);
			if (obj != null)
			{
				obj = ((Il2CppObjectBase)obj).Cast<IsValid>();
			}
			return (IsValid)obj;
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct Point
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_x;

		private static readonly System.IntPtr NativeFieldInfoPtr_y;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0;

		[FieldOffset(0)]
		public int x;

		[FieldOffset(4)]
		public int y;

		static Point()
		{
			Il2CppClassPointerStore<Point>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FloodFillBuilder>.NativeClassPtr, "Point");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Point>.NativeClassPtr);
			NativeFieldInfoPtr_x = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Point>.NativeClassPtr, "x");
			NativeFieldInfoPtr_y = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Point>.NativeClassPtr, "y");
			NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Point>.NativeClassPtr, 100685408);
		}

		[CallerCount(2853)]
		[CachedScanResults(RefRangeStart = 51511, RefRangeEnd = 54364, XrefRangeStart = 51511, XrefRangeEnd = 54364, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Point(int x, int y)
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&x);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &y;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<Point>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateFloodFillTileGroups_Public_Static_Il2CppReferenceArray_1_Il2CppStructArray_1_SerializedTile_Il2CppObjectBase_IsValid_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilesFloodFill_Public_Static_List_1_Point_Int32_Int32_Int32_Int32_IsValid_0;

	static FloodFillBuilder()
	{
		Il2CppClassPointerStore<FloodFillBuilder>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "FloodFillBuilder");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FloodFillBuilder>.NativeClassPtr);
		NativeMethodInfoPtr_CreateFloodFillTileGroups_Public_Static_Il2CppReferenceArray_1_Il2CppStructArray_1_SerializedTile_Il2CppObjectBase_IsValid_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FloodFillBuilder>.NativeClassPtr, 100685402);
		NativeMethodInfoPtr_GetTilesFloodFill_Public_Static_List_1_Point_Int32_Int32_Int32_Int32_IsValid_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FloodFillBuilder>.NativeClassPtr, 100685403);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236416, XrefRangeEnd = 236464, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<Il2CppStructArray<SerializedLevelHolder.SerializedLevel.TilemapLayer.SerializedTile>> CreateFloodFillTileGroups(Il2CppObjectBase tilemapLayer, IsValid validateAction)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(tilemapLayer);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)validateAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateFloodFillTileGroups_Public_Static_Il2CppReferenceArray_1_Il2CppStructArray_1_SerializedTile_Il2CppObjectBase_IsValid_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<SerializedLevelHolder.SerializedLevel.TilemapLayer.SerializedTile>>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 236486, RefRangeEnd = 236487, XrefRangeStart = 236464, XrefRangeEnd = 236486, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<Point> GetTilesFloodFill(int xStart, int yStart, int searchWidth, int searchHeight, IsValid validateAction)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&xStart);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &yStart;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &searchWidth;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &searchHeight;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)validateAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilesFloodFill_Public_Static_List_1_Point_Int32_Int32_Int32_Int32_IsValid_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Point>>(intPtr) : null;
	}

	public FloodFillBuilder(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
