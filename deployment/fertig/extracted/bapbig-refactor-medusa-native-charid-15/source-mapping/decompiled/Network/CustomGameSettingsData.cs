using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class CustomGameSettingsData : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_gamemode;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapId;

	private static readonly System.IntPtr NativeFieldInfoPtr_teamSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxTeams;

	private static readonly System.IntPtr NativeFieldInfoPtr_botCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_botDifficulty;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int gamemode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gamemode);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gamemode)) = num;
		}
	}

	public unsafe int mapId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapId)) = num;
		}
	}

	public unsafe int teamSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamSize)) = num;
		}
	}

	public unsafe int maxTeams
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxTeams);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxTeams)) = num;
		}
	}

	public unsafe int botCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_botCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_botCount)) = num;
		}
	}

	public unsafe int botDifficulty
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_botDifficulty);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_botDifficulty)) = num;
		}
	}

	static CustomGameSettingsData()
	{
		Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "CustomGameSettingsData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr);
		NativeFieldInfoPtr_gamemode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, "gamemode");
		NativeFieldInfoPtr_mapId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, "mapId");
		NativeFieldInfoPtr_teamSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, "teamSize");
		NativeFieldInfoPtr_maxTeams = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, "maxTeams");
		NativeFieldInfoPtr_botCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, "botCount");
		NativeFieldInfoPtr_botDifficulty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, "botDifficulty");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr, 100666522);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CustomGameSettingsData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomGameSettingsData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CustomGameSettingsData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
