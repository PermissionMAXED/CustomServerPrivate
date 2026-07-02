using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Items;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Text;
using UnityEngine;

namespace Il2CppBAPBAP.Entities.TargetDetection;

public class TargetDetection : NetworkBehaviour
{
	[OriginalName("Assembly-CSharp.dll", "", "TargetSearchType")]
	public enum TargetSearchType
	{
		All,
		Character,
		Npc
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_itemManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_entityManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_targetDetectionColPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_searchCollider;

	private static readonly System.IntPtr NativeFieldInfoPtr_searchRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr_radiusTargetIncrease;

	private static readonly System.IntPtr NativeFieldInfoPtr_alwaysSearchForBestTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_autoSelectBestTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_autoSelectTargetRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_removeTargetOnExit;

	private static readonly System.IntPtr NativeFieldInfoPtr_onlyTargetEnemies;

	private static readonly System.IntPtr NativeFieldInfoPtr_onlyTargetPlayers;

	private static readonly System.IntPtr NativeFieldInfoPtr_prioritizePlayers;

	private static readonly System.IntPtr NativeFieldInfoPtr_canSeeHiddenTargets;

	private static readonly System.IntPtr NativeFieldInfoPtr_ignoreLootcrates;

	private static readonly System.IntPtr NativeFieldInfoPtr_ignoreDowned;

	private static readonly System.IntPtr NativeFieldInfoPtr_detectItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemCheckForBrZone;

	private static readonly System.IntPtr NativeFieldInfoPtr_doLineOfSight;

	private static readonly System.IntPtr NativeFieldInfoPtr_doLineOfSightOnCurrentTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_raycastUpdateRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_disableWhenNoFoundChars;

	private static readonly System.IntPtr NativeFieldInfoPtr_autoSelectTargetTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_lineOfSightTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_hasLineOfSightWithTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_ownerTeamId;

	private static readonly System.IntPtr NativeFieldInfoPtr_isSearchingForTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentTargetPlayerId;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_foundChars;

	private static readonly System.IntPtr NativeFieldInfoPtr_foundItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_brZone;

	private static readonly System.IntPtr NativeFieldInfoPtr_obstaclesMask;

	private static readonly System.IntPtr NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_searchRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_isSearchingForTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_currentTargetPlayerId;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CurrentTarget_Public_get_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_FoundTargets_Public_get_List_1_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Initialize_Protected_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnStartServer_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnStartClient_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_New_Void_Single_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TickFindTargets_Private_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SortFoundTargets_Public_Void_TargetSearchType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFoundChars_Public_List_1_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ChooseBestTarget_Private_EntityManager_TargetSearchType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetFindTarget_Private_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnCollisionTriggerEnter_Public_Void_Collider_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnCollisionTriggerExit_Public_Void_Collider_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetClosestFoundPotion_Public_ItemObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetClosestFoundItem_Public_ItemObject_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBestFoundItem_Public_ItemObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TickOnTargetFound_Public_Virtual_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClearCurrentTarget_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnIsSearchingChanged_Public_Virtual_New_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnTargetIdChanged_Public_Virtual_New_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetSearchColliderRadius_Private_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryGetBattleRoyaleZone_Private_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsPosOutOfBrRing_Private_Boolean_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HasLineOfSight_Public_Boolean_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnIsSearchingChanged_Private_Void_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnIsTargetIdChanged_Private_Void_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnSearchRadiusChanged_Public_Void_Single_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_New_Void_NetworkReader_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_New_Void_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_New_Boolean_NetworkReader_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_New_Void_StringBuilder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworksearchRadius_Public_get_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_NetworksearchRadius_Public_set_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkisSearchingForTarget_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_NetworkisSearchingForTarget_Public_set_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkcurrentTargetPlayerId_Public_get_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_NetworkcurrentTargetPlayerId_Public_set_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SerializeSyncVars_Public_Virtual_Void_NetworkWriter_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DeserializeSyncVars_Public_Virtual_Void_NetworkReader_Boolean_0;

	public unsafe ItemManager itemManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)itemManager));
		}
	}

	public unsafe EntityManager entityManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager));
		}
	}

	public unsafe GameObject targetDetectionColPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetDetectionColPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetDetectionColPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Collider searchCollider
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_searchCollider);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Collider>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_searchCollider)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)collider));
		}
	}

	public unsafe float searchRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_searchRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_searchRadius)) = num;
		}
	}

	public unsafe float radiusTargetIncrease
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_radiusTargetIncrease);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_radiusTargetIncrease)) = num;
		}
	}

	public unsafe bool alwaysSearchForBestTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alwaysSearchForBestTarget);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alwaysSearchForBestTarget)) = flag;
		}
	}

	public unsafe bool autoSelectBestTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoSelectBestTarget);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoSelectBestTarget)) = flag;
		}
	}

	public unsafe float autoSelectTargetRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoSelectTargetRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoSelectTargetRate)) = num;
		}
	}

	public unsafe bool removeTargetOnExit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_removeTargetOnExit);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_removeTargetOnExit)) = flag;
		}
	}

	public unsafe bool onlyTargetEnemies
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyTargetEnemies);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyTargetEnemies)) = flag;
		}
	}

	public unsafe bool onlyTargetPlayers
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyTargetPlayers);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyTargetPlayers)) = flag;
		}
	}

	public unsafe bool prioritizePlayers
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prioritizePlayers);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prioritizePlayers)) = flag;
		}
	}

	public unsafe bool canSeeHiddenTargets
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canSeeHiddenTargets);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canSeeHiddenTargets)) = flag;
		}
	}

	public unsafe bool ignoreLootcrates
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ignoreLootcrates);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ignoreLootcrates)) = flag;
		}
	}

	public unsafe bool ignoreDowned
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ignoreDowned);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ignoreDowned)) = flag;
		}
	}

	public unsafe bool detectItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_detectItems);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_detectItems)) = flag;
		}
	}

	public unsafe bool itemCheckForBrZone
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemCheckForBrZone);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemCheckForBrZone)) = flag;
		}
	}

	public unsafe bool doLineOfSight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doLineOfSight);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doLineOfSight)) = flag;
		}
	}

	public unsafe bool doLineOfSightOnCurrentTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doLineOfSightOnCurrentTarget);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doLineOfSightOnCurrentTarget)) = flag;
		}
	}

	public unsafe float raycastUpdateRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_raycastUpdateRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_raycastUpdateRate)) = num;
		}
	}

	public unsafe bool disableWhenNoFoundChars
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disableWhenNoFoundChars);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disableWhenNoFoundChars)) = flag;
		}
	}

	public unsafe float autoSelectTargetTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoSelectTargetTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoSelectTargetTimer)) = num;
		}
	}

	public unsafe float lineOfSightTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lineOfSightTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lineOfSightTimer)) = num;
		}
	}

	public unsafe bool hasLineOfSightWithTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hasLineOfSightWithTarget);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hasLineOfSightWithTarget)) = flag;
		}
	}

	public unsafe int ownerTeamId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerTeamId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerTeamId)) = num;
		}
	}

	public unsafe bool isSearchingForTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSearchingForTarget);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSearchingForTarget)) = flag;
		}
	}

	public unsafe int currentTargetPlayerId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTargetPlayerId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTargetPlayerId)) = num;
		}
	}

	public unsafe EntityManager currentTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTarget);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTarget)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager));
		}
	}

	public unsafe List<EntityManager> foundChars
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_foundChars);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<EntityManager>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_foundChars)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<ItemObject> foundItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_foundItems);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<ItemObject>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_foundItems)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe BattleRoyaleZone brZone
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_brZone);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BattleRoyaleZone>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_brZone)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)battleRoyaleZone));
		}
	}

	public unsafe LayerMask obstaclesMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesMask);
			return *(LayerMask*)num;
		}
		set
		{
			*(LayerMask*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesMask)) = layerMask;
		}
	}

	public unsafe Il2CppSystem.Action<float, float> _Mirror_SyncVarHookDelegate_searchRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_searchRadius);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<float, float>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_searchRadius)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe Il2CppSystem.Action<bool, bool> _Mirror_SyncVarHookDelegate_isSearchingForTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_isSearchingForTarget);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<bool, bool>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_isSearchingForTarget)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe Il2CppSystem.Action<int, int> _Mirror_SyncVarHookDelegate_currentTargetPlayerId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_currentTargetPlayerId);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int, int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_currentTargetPlayerId)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe EntityManager CurrentTarget
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CurrentTarget_Public_get_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
		}
	}

	public unsafe List<EntityManager> FoundTargets
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FoundTargets_Public_get_List_1_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<EntityManager>>(intPtr) : null;
		}
	}

	public unsafe float NetworksearchRadius
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworksearchRadius_Public_get_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 211462, RefRangeEnd = 211465, XrefRangeStart = 211460, XrefRangeEnd = 211462, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		[param: In]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_NetworksearchRadius_Public_set_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool NetworkisSearchingForTarget
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkisSearchingForTarget_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 211475, RefRangeEnd = 211477, XrefRangeStart = 211465, XrefRangeEnd = 211475, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		[param: In]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_NetworkisSearchingForTarget_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe int NetworkcurrentTargetPlayerId
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkcurrentTargetPlayerId_Public_get_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(5)]
		[CachedScanResults(RefRangeStart = 211487, RefRangeEnd = 211492, XrefRangeStart = 211477, XrefRangeEnd = 211487, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		[param: In]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_NetworkcurrentTargetPlayerId_Public_set_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	static TargetDetection()
	{
		Il2CppClassPointerStore<TargetDetection>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities.TargetDetection", "TargetDetection");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr);
		NativeFieldInfoPtr_itemManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "itemManager");
		NativeFieldInfoPtr_entityManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "entityManager");
		NativeFieldInfoPtr_targetDetectionColPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "targetDetectionColPrefab");
		NativeFieldInfoPtr_searchCollider = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "searchCollider");
		NativeFieldInfoPtr_searchRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "searchRadius");
		NativeFieldInfoPtr_radiusTargetIncrease = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "radiusTargetIncrease");
		NativeFieldInfoPtr_alwaysSearchForBestTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "alwaysSearchForBestTarget");
		NativeFieldInfoPtr_autoSelectBestTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "autoSelectBestTarget");
		NativeFieldInfoPtr_autoSelectTargetRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "autoSelectTargetRate");
		NativeFieldInfoPtr_removeTargetOnExit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "removeTargetOnExit");
		NativeFieldInfoPtr_onlyTargetEnemies = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "onlyTargetEnemies");
		NativeFieldInfoPtr_onlyTargetPlayers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "onlyTargetPlayers");
		NativeFieldInfoPtr_prioritizePlayers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "prioritizePlayers");
		NativeFieldInfoPtr_canSeeHiddenTargets = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "canSeeHiddenTargets");
		NativeFieldInfoPtr_ignoreLootcrates = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "ignoreLootcrates");
		NativeFieldInfoPtr_ignoreDowned = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "ignoreDowned");
		NativeFieldInfoPtr_detectItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "detectItems");
		NativeFieldInfoPtr_itemCheckForBrZone = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "itemCheckForBrZone");
		NativeFieldInfoPtr_doLineOfSight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "doLineOfSight");
		NativeFieldInfoPtr_doLineOfSightOnCurrentTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "doLineOfSightOnCurrentTarget");
		NativeFieldInfoPtr_raycastUpdateRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "raycastUpdateRate");
		NativeFieldInfoPtr_disableWhenNoFoundChars = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "disableWhenNoFoundChars");
		NativeFieldInfoPtr_autoSelectTargetTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "autoSelectTargetTimer");
		NativeFieldInfoPtr_lineOfSightTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "lineOfSightTimer");
		NativeFieldInfoPtr_hasLineOfSightWithTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "hasLineOfSightWithTarget");
		NativeFieldInfoPtr_ownerTeamId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "ownerTeamId");
		NativeFieldInfoPtr_isSearchingForTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "isSearchingForTarget");
		NativeFieldInfoPtr_currentTargetPlayerId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "currentTargetPlayerId");
		NativeFieldInfoPtr_currentTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "currentTarget");
		NativeFieldInfoPtr_foundChars = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "foundChars");
		NativeFieldInfoPtr_foundItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "foundItems");
		NativeFieldInfoPtr_brZone = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "brZone");
		NativeFieldInfoPtr_obstaclesMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "obstaclesMask");
		NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_searchRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "_Mirror_SyncVarHookDelegate_searchRadius");
		NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_isSearchingForTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "_Mirror_SyncVarHookDelegate_isSearchingForTarget");
		NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_currentTargetPlayerId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, "_Mirror_SyncVarHookDelegate_currentTargetPlayerId");
		NativeMethodInfoPtr_get_CurrentTarget_Public_get_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682390);
		NativeMethodInfoPtr_get_FoundTargets_Public_get_List_1_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682391);
		NativeMethodInfoPtr_PreAwake_Public_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682392);
		NativeMethodInfoPtr_Initialize_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682393);
		NativeMethodInfoPtr_OnStartServer_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682394);
		NativeMethodInfoPtr_OnStartClient_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682395);
		NativeMethodInfoPtr_OnTick_Public_Virtual_New_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682396);
		NativeMethodInfoPtr_TickFindTargets_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682397);
		NativeMethodInfoPtr_SortFoundTargets_Public_Void_TargetSearchType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682398);
		NativeMethodInfoPtr_GetFoundChars_Public_List_1_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682399);
		NativeMethodInfoPtr_ChooseBestTarget_Private_EntityManager_TargetSearchType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682400);
		NativeMethodInfoPtr_SetFindTarget_Private_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682401);
		NativeMethodInfoPtr_OnCollisionTriggerEnter_Public_Void_Collider_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682402);
		NativeMethodInfoPtr_OnCollisionTriggerExit_Public_Void_Collider_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682403);
		NativeMethodInfoPtr_GetClosestFoundPotion_Public_ItemObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682404);
		NativeMethodInfoPtr_GetClosestFoundItem_Public_ItemObject_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682405);
		NativeMethodInfoPtr_GetBestFoundItem_Public_ItemObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682406);
		NativeMethodInfoPtr_TickOnTargetFound_Public_Virtual_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682407);
		NativeMethodInfoPtr_ClearCurrentTarget_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682408);
		NativeMethodInfoPtr_OnIsSearchingChanged_Public_Virtual_New_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682409);
		NativeMethodInfoPtr_OnTargetIdChanged_Public_Virtual_New_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682410);
		NativeMethodInfoPtr_SetSearchColliderRadius_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682411);
		NativeMethodInfoPtr_TryGetBattleRoyaleZone_Private_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682412);
		NativeMethodInfoPtr_IsPosOutOfBrRing_Private_Boolean_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682413);
		NativeMethodInfoPtr_HasLineOfSight_Public_Boolean_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682414);
		NativeMethodInfoPtr_OnIsSearchingChanged_Private_Void_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682415);
		NativeMethodInfoPtr_OnIsTargetIdChanged_Private_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682416);
		NativeMethodInfoPtr_OnSearchRadiusChanged_Public_Void_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682417);
		NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_New_Void_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682418);
		NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_New_Void_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682419);
		NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_New_Boolean_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682420);
		NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_New_Void_StringBuilder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682421);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682422);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682423);
		NativeMethodInfoPtr_get_NetworksearchRadius_Public_get_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682424);
		NativeMethodInfoPtr_set_NetworksearchRadius_Public_set_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682425);
		NativeMethodInfoPtr_get_NetworkisSearchingForTarget_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682426);
		NativeMethodInfoPtr_set_NetworkisSearchingForTarget_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682427);
		NativeMethodInfoPtr_get_NetworkcurrentTargetPlayerId_Public_get_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682428);
		NativeMethodInfoPtr_set_NetworkcurrentTargetPlayerId_Public_set_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682429);
		NativeMethodInfoPtr_SerializeSyncVars_Public_Virtual_Void_NetworkWriter_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682430);
		NativeMethodInfoPtr_DeserializeSyncVars_Public_Virtual_Void_NetworkReader_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr, 100682431);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211175, RefRangeEnd = 211176, XrefRangeStart = 211161, XrefRangeEnd = 211175, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake(EntityManager e)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)e);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211190, RefRangeEnd = 211191, XrefRangeStart = 211176, XrefRangeEnd = 211190, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialize_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211206, RefRangeEnd = 211208, XrefRangeStart = 211191, XrefRangeEnd = 211206, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnStartServer()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnStartServer_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211211, RefRangeEnd = 211213, XrefRangeStart = 211208, XrefRangeEnd = 211211, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnStartClient()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnStartClient_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 211213, XrefRangeEnd = 211222, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnTick(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_New_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211225, RefRangeEnd = 211226, XrefRangeStart = 211222, XrefRangeEnd = 211225, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TickFindTargets(float fixedDt)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&fixedDt);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TickFindTargets_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 211242, RefRangeEnd = 211245, XrefRangeStart = 211226, XrefRangeEnd = 211242, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SortFoundTargets(TargetSearchType preferedSearchTarget = TargetSearchType.All)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&preferedSearchTarget);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SortFoundTargets_Public_Void_TargetSearchType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe List<EntityManager> GetFoundChars()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFoundChars_Public_List_1_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<EntityManager>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211288, RefRangeEnd = 211290, XrefRangeStart = 211245, XrefRangeEnd = 211288, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EntityManager ChooseBestTarget(TargetSearchType searchTarget)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&searchTarget);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ChooseBestTarget_Private_EntityManager_TargetSearchType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211301, RefRangeEnd = 211302, XrefRangeStart = 211290, XrefRangeEnd = 211301, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetFindTarget(bool isSearching)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isSearching);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFindTarget_Private_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211330, RefRangeEnd = 211331, XrefRangeStart = 211302, XrefRangeEnd = 211330, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnCollisionTriggerEnter(Collider other)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)other);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnCollisionTriggerEnter_Public_Void_Collider_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211349, RefRangeEnd = 211350, XrefRangeStart = 211331, XrefRangeEnd = 211349, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnCollisionTriggerExit(Collider other)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)other);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnCollisionTriggerExit_Public_Void_Collider_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211351, RefRangeEnd = 211352, XrefRangeStart = 211350, XrefRangeEnd = 211351, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ItemObject GetClosestFoundPotion()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClosestFoundPotion_Public_ItemObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211371, RefRangeEnd = 211372, XrefRangeStart = 211352, XrefRangeEnd = 211371, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ItemObject GetClosestFoundItem(int onlyItemId = -1)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&onlyItemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClosestFoundItem_Public_ItemObject_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211391, RefRangeEnd = 211392, XrefRangeStart = 211372, XrefRangeEnd = 211391, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ItemObject GetBestFoundItem()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBestFoundItem_Public_ItemObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemObject>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 211392, XrefRangeEnd = 211402, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void TickOnTargetFound()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_TickOnTargetFound_Public_Virtual_New_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211403, RefRangeEnd = 211404, XrefRangeStart = 211402, XrefRangeEnd = 211403, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClearCurrentTarget()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClearCurrentTarget_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnIsSearchingChanged(bool newValue)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&newValue);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnIsSearchingChanged_Public_Virtual_New_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnTargetIdChanged(int id)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&id);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTargetIdChanged_Public_Virtual_New_Void_Int32_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211406, RefRangeEnd = 211407, XrefRangeStart = 211404, XrefRangeEnd = 211406, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetSearchColliderRadius(float radius)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&radius);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSearchColliderRadius_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211415, RefRangeEnd = 211417, XrefRangeStart = 211407, XrefRangeEnd = 211415, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool TryGetBattleRoyaleZone()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryGetBattleRoyaleZone_Private_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211422, RefRangeEnd = 211424, XrefRangeStart = 211417, XrefRangeEnd = 211422, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsPosOutOfBrRing(Vector3 pos)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&pos);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsPosOutOfBrRing_Private_Boolean_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 211430, RefRangeEnd = 211434, XrefRangeStart = 211424, XrefRangeEnd = 211430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool HasLineOfSight(Vector3 targetPos)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&targetPos);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HasLineOfSight_Public_Boolean_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe void OnIsSearchingChanged(bool oldValue, bool newValue)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&oldValue);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newValue;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnIsSearchingChanged_Private_Void_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void OnIsTargetIdChanged(int oldValue, int newValue)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&oldValue);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newValue;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnIsTargetIdChanged_Private_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211436, RefRangeEnd = 211437, XrefRangeStart = 211434, XrefRangeEnd = 211436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnSearchRadiusChanged(float oldValue, float newValue)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&oldValue);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newValue;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnSearchRadiusChanged_Public_Void_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnNetDeserialize(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_New_Void_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnNetSerialize(NetworkWriter netWriter)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netWriter);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_New_Void_NetworkWriter_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual bool OnNetDebugCompare(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_New_Boolean_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnNetDebugLog(StringBuilder sb)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_New_Void_StringBuilder_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211458, RefRangeEnd = 211460, XrefRangeStart = 211437, XrefRangeEnd = 211458, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TargetDetection()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TargetDetection>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211497, RefRangeEnd = 211498, XrefRangeStart = 211492, XrefRangeEnd = 211497, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)writer);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &forceAll;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SerializeSyncVars_Public_Virtual_Void_NetworkWriter_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211509, RefRangeEnd = 211510, XrefRangeStart = 211498, XrefRangeEnd = 211509, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &initialState;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_DeserializeSyncVars_Public_Virtual_Void_NetworkReader_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public TargetDetection(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
