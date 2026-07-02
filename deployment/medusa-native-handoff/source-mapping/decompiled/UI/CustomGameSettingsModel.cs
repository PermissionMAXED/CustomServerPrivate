using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;

namespace Il2CppBAPBAP.UI;

public class CustomGameSettingsModel : Model
{
	private static readonly IntPtr NativeFieldInfoPtr_GameMode;

	private static readonly IntPtr NativeFieldInfoPtr_MapId;

	private static readonly IntPtr NativeFieldInfoPtr_TeamSize;

	private static readonly IntPtr NativeFieldInfoPtr_MaxTeams;

	private static readonly IntPtr NativeFieldInfoPtr_BotCount;

	private static readonly IntPtr NativeFieldInfoPtr_BotDifficulty;

	private static readonly IntPtr NativeFieldInfoPtr_MapMappings;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int GameMode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameMode);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GameMode)) = num;
		}
	}

	public unsafe int MapId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MapId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MapId)) = num;
		}
	}

	public unsafe int TeamSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TeamSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TeamSize)) = num;
		}
	}

	public unsafe int MaxTeams
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaxTeams);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaxTeams)) = num;
		}
	}

	public unsafe int BotCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BotCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BotCount)) = num;
		}
	}

	public unsafe int BotDifficulty
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BotDifficulty);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BotDifficulty)) = num;
		}
	}

	public unsafe Dictionary<int, Il2CppStructArray<int>> MapMappings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MapMappings);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<int, Il2CppStructArray<int>>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MapMappings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	static CustomGameSettingsModel()
	{
		Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "CustomGameSettingsModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr);
		NativeFieldInfoPtr_GameMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "GameMode");
		NativeFieldInfoPtr_MapId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "MapId");
		NativeFieldInfoPtr_TeamSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "TeamSize");
		NativeFieldInfoPtr_MaxTeams = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "MaxTeams");
		NativeFieldInfoPtr_BotCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "BotCount");
		NativeFieldInfoPtr_BotDifficulty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "BotDifficulty");
		NativeFieldInfoPtr_MapMappings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, "MapMappings");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr, 100670925);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 106442, RefRangeEnd = 106444, XrefRangeStart = 106441, XrefRangeEnd = 106442, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CustomGameSettingsModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomGameSettingsModel>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CustomGameSettingsModel(IntPtr pointer)
		: base(pointer)
	{
	}
}
