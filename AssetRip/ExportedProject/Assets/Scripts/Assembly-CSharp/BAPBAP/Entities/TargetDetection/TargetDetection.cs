using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities.TargetDetection
{
	public class TargetDetection : NetworkBehaviour, INetworkPredicted
	{
		public enum TargetSearchType
		{
			All = 0,
			Character = 1,
			Npc = 2
		}

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public EntityManager entityManager;

		[Header("References")]
		[SerializeField]
		public GameObject targetDetectionColPrefab;

		[SerializeField]
		[Header("General")]
		[Tooltip("The collider attached to this target detection. If leaving this null, a new collider will be created from the collider prefab")]
		public Collider searchCollider;

		[SyncVar(hook = "OnSearchRadiusChanged")]
		[Tooltip("The radius of the collider to search targets")]
		[SerializeField]
		public float searchRadius;

		[SerializeField]
		[Tooltip("How much the search radius expands for when finding a target. Makes it a bit more natural to enter/exit the search radius when it doesnt appear like a line the target crosses")]
		public float radiusTargetIncrease;

		[Tooltip("Even if it has a current target, it should still search for a better valid target")]
		[SerializeField]
		[Header("Target Settings")]
		public bool alwaysSearchForBestTarget;

		[SerializeField]
		[Tooltip("Should this target detection automatically select the best target? If toggling this off, its expected to manually select the best target externally.")]
		public bool autoSelectBestTarget;

		[Min(0.1f)]
		[SerializeField]
		[Tooltip("If automatically selecting targets, at which rate (every X ticks) should it sort the found targets")]
		[ConditionalHide("autoSelectBestTarget", true)]
		public float autoSelectTargetRate;

		[SerializeField]
		[Tooltip("Should the current target be removed if it exits the search collider? If toggling this off, its expected to manually handle the target externally.")]
		public bool removeTargetOnExit;

		[Header("Target Config")]
		[Tooltip("Should the target detection only process enemy characters?")]
		[SerializeField]
		public bool onlyTargetEnemies;

		[Tooltip("Should the target detection only process player and bot characters?")]
		[SerializeField]
		public bool onlyTargetPlayers;

		[Tooltip("Should the target detection prioritize players and bots from npcs?")]
		[SerializeField]
		public bool prioritizePlayers;

		[Tooltip("Should the target detection see hidden characters?")]
		[SerializeField]
		public bool canSeeHiddenTargets;

		[Tooltip("Should the target detection ignore any type of loot crates?")]
		[SerializeField]
		public bool ignoreLootcrates;

		[Tooltip("Should the target detection ignore downed player and bot characters?")]
		[SerializeField]
		public bool ignoreDowned;

		[SerializeField]
		[Tooltip("Should the target detection also detect item objects?")]
		public bool detectItems;

		[Tooltip("Should the target detection skip items that are out of the battle royale ring?")]
		[ConditionalHide("detectItems", true)]
		[SerializeField]
		public bool itemCheckForBrZone;

		[SerializeField]
		[Tooltip("Should do line of sight raycast checks when finding targets?")]
		[Header("Line Of Sight")]
		public bool doLineOfSight;

		[SerializeField]
		[Tooltip("Should do line of sight raycast checks on update with the found target?")]
		public bool doLineOfSightOnCurrentTarget;

		[SerializeField]
		[Tooltip("At which rate current target line of sight will update?")]
		[ConditionalHide("doLineOfSightOnCurrentTarget", true)]
		public float raycastUpdateRate;

		[NonSerialized]
		public bool disableWhenNoFoundChars;

		[NonSerialized]
		public float autoSelectTargetTimer;

		[NonSerialized]
		public float lineOfSightTimer;

		[NonSerialized]
		public bool hasLineOfSightWithTarget;

		[NonSerialized]
		public int ownerTeamId;

		[SyncVar(hook = "OnIsSearchingChanged")]
		[NonSerialized]
		public bool isSearchingForTarget;

		[SyncVar(hook = "OnIsTargetIdChanged")]
		[NonSerialized]
		public int currentTargetPlayerId;

		[NonSerialized]
		public EntityManager currentTarget;

		[NonSerialized]
		public List<EntityManager> foundChars;

		[NonSerialized]
		public List<ItemObject> foundItems;

		[NonSerialized]
		public BattleRoyaleZone brZone;

		[NonSerialized]
		public LayerMask obstaclesMask;

		public Action<float, float> _Mirror_SyncVarHookDelegate_searchRadius;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isSearchingForTarget;

		public Action<int, int> _Mirror_SyncVarHookDelegate_currentTargetPlayerId;

		public EntityManager CurrentTarget => null;

		public List<EntityManager> FoundTargets => null;

		public float NetworksearchRadius
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkisSearchingForTarget
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkcurrentTargetPlayerId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public void PreAwake(EntityManager e)
		{
		}

		public void Initialize()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		[ServerCallback]
		public virtual void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void TickFindTargets(float fixedDt)
		{
		}

		[Server]
		public void SortFoundTargets(TargetSearchType preferedSearchTarget = TargetSearchType.All)
		{
		}

		public List<EntityManager> GetFoundChars()
		{
			return null;
		}

		[Server]
		public EntityManager ChooseBestTarget(TargetSearchType searchTarget)
		{
			return null;
		}

		[Server]
		public void SetFindTarget(bool isSearching)
		{
		}

		public void OnCollisionTriggerEnter(Collider other)
		{
		}

		public void OnCollisionTriggerExit(Collider other)
		{
		}

		public ItemObject GetClosestFoundPotion()
		{
			return null;
		}

		public ItemObject GetClosestFoundItem(int onlyItemId = -1)
		{
			return null;
		}

		public ItemObject GetBestFoundItem()
		{
			return null;
		}

		public virtual void TickOnTargetFound()
		{
		}

		public void ClearCurrentTarget()
		{
		}

		public virtual void OnIsSearchingChanged(bool newValue)
		{
		}

		public virtual void OnTargetIdChanged(int id)
		{
		}

		public void SetSearchColliderRadius(float radius)
		{
		}

		public bool TryGetBattleRoyaleZone()
		{
			return false;
		}

		public bool IsPosOutOfBrRing(Vector3 pos)
		{
			return false;
		}

		public bool HasLineOfSight(Vector3 targetPos)
		{
			return false;
		}

		public void OnIsSearchingChanged(bool oldValue, bool newValue)
		{
		}

		public void OnIsTargetIdChanged(int oldValue, int newValue)
		{
		}

		public void OnSearchRadiusChanged(float oldValue, float newValue)
		{
		}

		public virtual void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public virtual void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public virtual bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public virtual void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
