using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class PlayerModel : Model
{
	private static readonly IntPtr NativeFieldInfoPtr_accountId;

	private static readonly IntPtr NativeFieldInfoPtr_username;

	private static readonly IntPtr NativeFieldInfoPtr_discriminator;

	private static readonly IntPtr NativeFieldInfoPtr_level;

	private static readonly IntPtr NativeFieldInfoPtr_status;

	private static readonly IntPtr NativeFieldInfoPtr_lobbyCharId;

	private static readonly IntPtr NativeFieldInfoPtr_selectedCharId;

	private static readonly IntPtr NativeFieldInfoPtr_isInQueue;

	private static readonly IntPtr NativeFieldInfoPtr_isLeader;

	private static readonly IntPtr NativeFieldInfoPtr_isReady;

	private static readonly IntPtr NativeFieldInfoPtr_isCustomReady;

	private static readonly IntPtr NativeFieldInfoPtr_isCharLocked;

	private static readonly IntPtr NativeFieldInfoPtr_isSpawnLeader;

	private static readonly IntPtr NativeFieldInfoPtr_selectedSpawn;

	private static readonly IntPtr NativeFieldInfoPtr_loadout;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string accountId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
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

	public unsafe int discriminator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_discriminator);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_discriminator)) = num;
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

	public unsafe int status
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_status);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_status)) = num;
		}
	}

	public unsafe int lobbyCharId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCharId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCharId)) = num;
		}
	}

	public unsafe int selectedCharId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedCharId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedCharId)) = num;
		}
	}

	public unsafe bool isInQueue
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInQueue);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInQueue)) = flag;
		}
	}

	public unsafe bool isLeader
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLeader);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLeader)) = flag;
		}
	}

	public unsafe bool isReady
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isReady);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isReady)) = flag;
		}
	}

	public unsafe bool isCustomReady
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCustomReady);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCustomReady)) = flag;
		}
	}

	public unsafe bool isCharLocked
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCharLocked);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCharLocked)) = flag;
		}
	}

	public unsafe bool isSpawnLeader
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSpawnLeader);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSpawnLeader)) = flag;
		}
	}

	public unsafe Vector2 selectedSpawn
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedSpawn);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedSpawn)) = vector;
		}
	}

	public unsafe LoadoutModel loadout
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadout);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<LoadoutModel>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadout)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loadoutModel));
		}
	}

	static PlayerModel()
	{
		Il2CppClassPointerStore<PlayerModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "PlayerModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr);
		NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "accountId");
		NativeFieldInfoPtr_username = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "username");
		NativeFieldInfoPtr_discriminator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "discriminator");
		NativeFieldInfoPtr_level = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "level");
		NativeFieldInfoPtr_status = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "status");
		NativeFieldInfoPtr_lobbyCharId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "lobbyCharId");
		NativeFieldInfoPtr_selectedCharId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "selectedCharId");
		NativeFieldInfoPtr_isInQueue = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "isInQueue");
		NativeFieldInfoPtr_isLeader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "isLeader");
		NativeFieldInfoPtr_isReady = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "isReady");
		NativeFieldInfoPtr_isCustomReady = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "isCustomReady");
		NativeFieldInfoPtr_isCharLocked = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "isCharLocked");
		NativeFieldInfoPtr_isSpawnLeader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "isSpawnLeader");
		NativeFieldInfoPtr_selectedSpawn = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "selectedSpawn");
		NativeFieldInfoPtr_loadout = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, "loadout");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr, 100670953);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 106586, RefRangeEnd = 106590, XrefRangeStart = 106582, XrefRangeEnd = 106586, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerModel>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PlayerModel(IntPtr pointer)
		: base(pointer)
	{
	}
}
