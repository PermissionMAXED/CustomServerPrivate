using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.UI;

public class LeaderboardEntryModel : Model
{
	private static readonly IntPtr NativeFieldInfoPtr_kills;

	private static readonly IntPtr NativeFieldInfoPtr_rank;

	private static readonly IntPtr NativeFieldInfoPtr_username;

	private static readonly IntPtr NativeFieldInfoPtr_level;

	private static readonly IntPtr NativeFieldInfoPtr_bannerId;

	private static readonly IntPtr NativeFieldInfoPtr_wins;

	private static readonly IntPtr NativeFieldInfoPtr_position;

	private static readonly IntPtr NativeFieldInfoPtr_isSelf;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int kills
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kills);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kills)) = num;
		}
	}

	public unsafe int rank
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rank);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rank)) = num;
		}
	}

	public unsafe string username
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_username);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_username)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe int level
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_level);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_level)) = num;
		}
	}

	public unsafe int bannerId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bannerId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bannerId)) = num;
		}
	}

	public unsafe int wins
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wins);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wins)) = num;
		}
	}

	public unsafe int position
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_position);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_position)) = num;
		}
	}

	public unsafe bool isSelf
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSelf);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSelf)) = flag;
		}
	}

	static LeaderboardEntryModel()
	{
		Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "LeaderboardEntryModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr);
		NativeFieldInfoPtr_kills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "kills");
		NativeFieldInfoPtr_rank = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "rank");
		NativeFieldInfoPtr_username = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "username");
		NativeFieldInfoPtr_level = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "level");
		NativeFieldInfoPtr_bannerId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "bannerId");
		NativeFieldInfoPtr_wins = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "wins");
		NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "position");
		NativeFieldInfoPtr_isSelf = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, "isSelf");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr, 100670929);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LeaderboardEntryModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LeaderboardEntryModel>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LeaderboardEntryModel(IntPtr pointer)
		: base(pointer)
	{
	}
}
