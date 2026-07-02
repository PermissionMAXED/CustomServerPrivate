using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;

namespace Il2CppBAPBAP.Player;

public class PlayerScores : NetworkBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_playerManager;

	private static readonly IntPtr NativeFieldInfoPtr_kills;

	private static readonly IntPtr NativeFieldInfoPtr_deaths;

	private static readonly IntPtr NativeFieldInfoPtr_assists;

	private static readonly IntPtr NativeFieldInfoPtr_damageDealt;

	private static readonly IntPtr NativeFieldInfoPtr_damageReceived;

	private static readonly IntPtr NativeFieldInfoPtr_fishingXp;

	private static readonly IntPtr NativeFieldInfoPtr_pointsPerKill;

	private static readonly IntPtr NativeFieldInfoPtr_pointsPerAssist;

	private static readonly IntPtr NativeFieldInfoPtr_pointsPerDmgDealt;

	private static readonly IntPtr NativeFieldInfoPtr_pointsPerDmgTaken;

	private static readonly IntPtr NativeMethodInfoPtr_Initialize_Public_Void_PlayerManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTotalKillsString_Public_Static_String_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_ClearStats_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetMvpSquadMemberPlayerId_Public_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPlayerScore_Private_Int32_PlayerScores_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe PlayerManager playerManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PlayerManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerManager));
		}
	}

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

	public unsafe int deaths
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deaths);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deaths)) = num;
		}
	}

	public unsafe int assists
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assists);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assists)) = num;
		}
	}

	public unsafe int damageDealt
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageDealt);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageDealt)) = num;
		}
	}

	public unsafe int damageReceived
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageReceived);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageReceived)) = num;
		}
	}

	public unsafe int fishingXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fishingXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fishingXp)) = num;
		}
	}

	public unsafe int pointsPerKill
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerKill);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerKill)) = num;
		}
	}

	public unsafe int pointsPerAssist
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerAssist);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerAssist)) = num;
		}
	}

	public unsafe int pointsPerDmgDealt
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerDmgDealt);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerDmgDealt)) = num;
		}
	}

	public unsafe int pointsPerDmgTaken
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerDmgTaken);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointsPerDmgTaken)) = num;
		}
	}

	static PlayerScores()
	{
		Il2CppClassPointerStore<PlayerScores>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Player", "PlayerScores");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr);
		NativeFieldInfoPtr_playerManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "playerManager");
		NativeFieldInfoPtr_kills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "kills");
		NativeFieldInfoPtr_deaths = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "deaths");
		NativeFieldInfoPtr_assists = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "assists");
		NativeFieldInfoPtr_damageDealt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "damageDealt");
		NativeFieldInfoPtr_damageReceived = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "damageReceived");
		NativeFieldInfoPtr_fishingXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "fishingXp");
		NativeFieldInfoPtr_pointsPerKill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "pointsPerKill");
		NativeFieldInfoPtr_pointsPerAssist = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "pointsPerAssist");
		NativeFieldInfoPtr_pointsPerDmgDealt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "pointsPerDmgDealt");
		NativeFieldInfoPtr_pointsPerDmgTaken = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, "pointsPerDmgTaken");
		NativeMethodInfoPtr_Initialize_Public_Void_PlayerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666075);
		NativeMethodInfoPtr_GetTotalKillsString_Public_Static_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666076);
		NativeMethodInfoPtr_ClearStats_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666077);
		NativeMethodInfoPtr_GetMvpSquadMemberPlayerId_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666078);
		NativeMethodInfoPtr_GetPlayerScore_Private_Int32_PlayerScores_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666079);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666080);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr, 100666081);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 62085, RefRangeEnd = 62088, XrefRangeStart = 62085, XrefRangeEnd = 62085, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialize(PlayerManager _playerManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_playerManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialize_Public_Void_PlayerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 62094, RefRangeEnd = 62095, XrefRangeStart = 62088, XrefRangeEnd = 62094, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string GetTotalKillsString(int totalKills)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&totalKills);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTotalKillsString_Public_Static_String_Int32_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 62095, RefRangeEnd = 62097, XrefRangeStart = 62095, XrefRangeEnd = 62095, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClearStats()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClearStats_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 62097, XrefRangeEnd = 62107, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetMvpSquadMemberPlayerId()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMvpSquadMemberPlayerId_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetPlayerScore(PlayerScores playerScores)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerScores);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerScore_Private_Int32_PlayerScores_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(25)]
	[CachedScanResults(RefRangeStart = 56662, RefRangeEnd = 56687, XrefRangeStart = 56662, XrefRangeEnd = 56687, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerScores()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerScores>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public PlayerScores(IntPtr pointer)
		: base(pointer)
	{
	}
}
