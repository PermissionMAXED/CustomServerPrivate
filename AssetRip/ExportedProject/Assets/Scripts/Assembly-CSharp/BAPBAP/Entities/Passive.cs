using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Passive : IComparable
	{
		public struct VfxInstanceData
		{
			public int id;

			public GameObject instance;

			public VfxInstanceData(int id, GameObject instance)
			{
				this.id = 0;
				this.instance = null;
			}
		}

		[Serializable]
		public class PassiveConfiguration
		{
			public Sprite icon;

			public string name;

			[TextArea(1, 3)]
			[Tooltip("Simplified description. Defaults to long description if empty")]
			public string shortDescription;

			[TextArea(1, 3)]
			[Tooltip("Full description with all details")]
			public string longDescription;

			[Tooltip("Only allow for a single instance of this passive to be activated on the entity")]
			[Header("Config")]
			public bool oneInstance;

			[Tooltip("Should this passive be shown in the player ui?")]
			[Header("UI Config")]
			public bool showUI;

			[Tooltip("Should this passive stack into the same ui element when activating a new instance?")]
			public bool stackable;

			[Tooltip("Should this passive stack show as only max 1 count?")]
			public bool show1Stack;

			[Tooltip("Should this passive stack starting counting from zero?")]
			public bool startStackAtZero;

			[Space(10f)]
			public ItemStat[] stats;

			public virtual string GetShortDescription()
			{
				return null;
			}

			public virtual string GetLongDescription()
			{
				return null;
			}
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharPassives charPassives;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharFX charFx;

		[NonSerialized]
		public CharItems charItems;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public CharStatusEffects charStatusEffects;

		[NonSerialized]
		public int passiveId;

		[NonSerialized]
		public CastFlags targetAbilityFlags;

		[NonSerialized]
		public List<VfxInstanceData> spawnedVfxObjs;

		[NonSerialized]
		public UIPassiveElement uiPassive;

		[NonSerialized]
		public bool hasFsm;

		[NonSerialized]
		public SimulationFsm fsm;

		[NonSerialized]
		public byte stateId;

		[NonSerialized]
		public byte triggerId;

		[NonSerialized]
		public byte TRIGGER_NONE;

		[NonSerialized]
		public byte TRIGGER_FORCEINTERRUPT_EXT;

		public virtual PassiveConfiguration passiveConfig => null;

		public Passive(EntityManager _entityManager)
		{
		}

		public virtual void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void ClTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void ActivatePassive()
		{
		}

		public virtual void Reactivate()
		{
		}

		public virtual void TryDeactivate()
		{
		}

		public virtual void DeactivatePassive()
		{
		}

		public virtual void ClActivatePassive()
		{
		}

		public virtual void ClDeactivatePassive()
		{
		}

		public virtual void ClStartAuth()
		{
		}

		public virtual void ClStopAuth()
		{
		}

		public virtual void ForceInterrupt()
		{
		}

		public virtual string GetPassiveName()
		{
			return null;
		}

		public virtual float GetValue()
		{
			return 0f;
		}

		public virtual float GetFloat1()
		{
			return 0f;
		}

		public virtual void AddFloat1(float f)
		{
		}

		public virtual Vector3 ApplyInputDirModification(Vector3 inputDir)
		{
			return default(Vector3);
		}

		public virtual void SetSharedData(float floatA = 0f, float floatB = 0f, Vector3 vectorA = default(Vector3))
		{
		}

		public void ClSpawnUI()
		{
		}

		public void ClPlayUIPickupAnim()
		{
		}

		public void ClDespawnUI()
		{
		}

		public virtual void OnAbilityTrigger(EntityManager cM, int abilityId)
		{
		}

		public virtual void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public virtual void OnBonusHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public virtual void OnHealedTrigger(EntityManager cM)
		{
		}

		public virtual void OnConsumeConsumableTrigger(EntityManager cM, int consumableItemId)
		{
		}

		public virtual void OnItemsChanged(EntityManager cM)
		{
		}

		public virtual void OnStatsChanged(bool added, ItemStat stat)
		{
		}

		public virtual void OnHitTrigger(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public virtual void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public virtual void OnDealtDamageInteractableTrigger(EntityManager otherEntityManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public virtual void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}

		public virtual void OnImmuneDamageTrigger(int damage)
		{
		}

		public virtual void OnKillTrigger(EntityManager cM)
		{
		}

		public virtual void OnKilledTrigger(EntityManager killerManager)
		{
		}

		public virtual void OnAssistTrigger(EntityManager otherCharManager, float timer)
		{
		}

		public virtual void OnMinHpTrigger()
		{
		}

		public virtual void OnPickUpTrigger()
		{
		}

		public virtual void OnStatusEffectAppliedToEnemyTrigger(int statusEffectId, bool alreadyApplied)
		{
		}

		public virtual void OnStatusEffectAppliedToSelfTrigger(int statusEffectId)
		{
		}

		public virtual void OnCastCompleteTrigger()
		{
		}

		public virtual void OnZoneEnter()
		{
		}

		public virtual void OnZoneExit()
		{
		}

		[Client]
		public GameObject ClSpawnLoopVfxObj(int vfxId, Transform transform)
		{
			return null;
		}

		[Client]
		public void ClDestroyLoopVfxObj(int id)
		{
		}

		[Client]
		public GameObject ClSpawnVfxObj(int vfxId, Transform transform)
		{
			return null;
		}

		public virtual void ClCustomEvent0()
		{
		}

		public virtual void ClCustomEvent1()
		{
		}

		public bool IsAbilityIdActive(int abilityId)
		{
			return false;
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

		public int CompareTo(object obj)
		{
			return 0;
		}

		public int CompareTo(Passive other)
		{
			return 0;
		}
	}
}
