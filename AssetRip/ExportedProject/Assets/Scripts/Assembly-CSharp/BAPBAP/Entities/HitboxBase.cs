using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Pooling;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxBase : NetworkBehaviour, IPoolDespawnListener
	{
		[NonSerialized]
		public ProjectileMove projMove;

		[NonSerialized]
		public VFXSpawn vfxSpawn;

		[NonSerialized]
		public AudioPlay audioPlay;

		[NonSerialized]
		public AudioPlayIntervals audioPlayIntervals;

		[NonSerialized]
		[SyncVar]
		public int ownerPlayerId;

		[NonSerialized]
		[SyncVar]
		public int teamId;

		[NonSerialized]
		public bool ignoreObstacles;

		[NonSerialized]
		public bool destroyOnCharHit;

		[NonSerialized]
		public bool destroyOnStaticCollision;

		[NonSerialized]
		public bool destroyOnInteractableHit;

		[NonSerialized]
		public bool doTtl;

		[NonSerialized]
		public float ttl;

		[SerializeField]
		public bool onlyHitAllies;

		[SerializeField]
		public bool allowHitToOwnerPlayer;

		[SerializeField]
		public bool allowHitToTeam;

		[NonSerialized]
		public bool allowHitToInteractables;

		[NonSerialized]
		public bool allowLifesteal;

		[NonSerialized]
		public bool allowThorns;

		[NonSerialized]
		public bool collidesWithLowObstacles;

		[NonSerialized]
		public bool allowTriggerObstacleCollision;

		[NonSerialized]
		public bool playImpactOnChar;

		[NonSerialized]
		public bool playImpactOnObstacleCollision;

		[NonSerialized]
		public bool playImpactImpactPoint;

		[NonSerialized]
		public bool ignoreParry;

		[NonSerialized]
		public GameObject otherChar;

		[NonSerialized]
		public int damage;

		[NonSerialized]
		public bool isCriticalDamage;

		[NonSerialized]
		public float addDamageHpPercentage;

		[NonSerialized]
		public float selfHpPercentDamageHp;

		[NonSerialized]
		public int addDamageHpPercentageNpcsLimit;

		[NonSerialized]
		public float addDamageVehicleHpPercentage;

		[NonSerialized]
		public float damageToPlayersMultiplier;

		[NonSerialized]
		public bool overHealToShields;

		[NonSerialized]
		public bool applyZeroDamageHit;

		[NonSerialized]
		public bool stayOnOwnerDestroyed;

		[NonSerialized]
		public bool counterable;

		[NonSerialized]
		public bool directional;

		[NonSerialized]
		public bool alwaysHitInteractables;

		[NonSerialized]
		public bool forceTriggerImmune;

		[NonSerialized]
		public bool hasPassive;

		[NonSerialized]
		public bool secondaryHitbox;

		[NonSerialized]
		public bool primaryHitboxDidHit;

		[NonSerialized]
		public bool ignoreEntities;

		[NonSerialized]
		public bool whiteListEntities;

		[NonSerialized]
		public List<GameObject> ignoredEntities;

		[NonSerialized]
		public List<GameObject> whiteListedEntities;

		[NonSerialized]
		public List<StatusEffectInfo> _statusEffects;

		[NonSerialized]
		public bool onlyApplyHitOncePerChar;

		[NonSerialized]
		public List<EntityManager> hittedEntities;

		[NonSerialized]
		public bool destroyed;

		[NonSerialized]
		public bool hasHitEntity;

		[NonSerialized]
		public float destroyTimer;

		[NonSerialized]
		public float clDestroyTimer;

		[NonSerialized]
		public bool clSpawnDestroyVfx;

		[NonSerialized]
		public Vector3 clDestroyPos;

		[NonSerialized]
		public Ability ability;

		public Action<EntityManager, HitboxBase> OnHitSuccessAction;

		[NonSerialized]
		public List<EntityManager> allEntityHits;

		public virtual float ElapsedTime => 0f;

		public bool OnlyApplyHitOncePerChar
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Destroyed => false;

		public List<StatusEffectInfo> statusEffects
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int NetworkownerPlayerId
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

		public int NetworkteamId
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

		public virtual void Awake()
		{
		}

		public virtual void OnDespawn()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public void SetAbility(Ability a)
		{
		}

		public void TryRemoveFromHitList(EntityManager otherEntityManager)
		{
		}

		public void AddIgnoredEntity(GameObject entityObj)
		{
		}

		public void RemoveIgnoredEntity(GameObject entityObj)
		{
		}

		public void AddWhiteListedEntity(GameObject entityObj)
		{
		}

		public void RemoveWhiteListedEntity(GameObject entityObj)
		{
		}

		public void OnHitSuccess(EntityManager otherEntityManager)
		{
		}

		public void OnHitKill(EntityManager otherEntityManager)
		{
		}

		public virtual void OnHitboxHit(Hitbox otherHbox, HitboxBase originalHitbox)
		{
		}

		public void OnWallHit()
		{
		}

		[Server]
		public void DestroyHitbox(bool spawnDestroyVFX = true, Vector3 destroyPos = default(Vector3), float destroyDelay = 0f)
		{
		}

		public void SvDelayDestroyHitbox(float delay = 0f)
		{
		}

		public void SvDestroyHitbox()
		{
		}

		public Vector3 GetHitboxDirection(Transform otherTransform)
		{
			return default(Vector3);
		}

		public bool CanHitEntity(int otherTeamId, int otherPlayerId)
		{
			return false;
		}

		public bool IsInteractableHittable(EntityManager otherEntityManager)
		{
			return false;
		}

		[ClientRpc]
		public void RpcOnHitboxImpact(Vector3 impactPosition)
		{
		}

		[ClientRpc]
		public void RpcDestroyHitbox(bool spawnDestroyVFX, Vector3 destroyPos)
		{
		}

		[ClientRpc]
		public void RpcDestroyHitboxAtPosition(bool spawnDestroyVFX, Vector3 destroyPos)
		{
		}

		public void ClOnHitboxImpact(Vector3 impactPosition)
		{
		}

		public void ClDestroyHitbox(bool spawnDestroyVFX, Vector3 destroyPos)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnHitboxImpact__Vector3(Vector3 impactPosition)
		{
		}

		public static void InvokeUserCode_RpcOnHitboxImpact__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyHitbox__Boolean__Vector3(bool spawnDestroyVFX, Vector3 destroyPos)
		{
		}

		public static void InvokeUserCode_RpcDestroyHitbox__Boolean__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyHitboxAtPosition__Boolean__Vector3(bool spawnDestroyVFX, Vector3 destroyPos)
		{
		}

		public static void InvokeUserCode_RpcDestroyHitboxAtPosition__Boolean__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static HitboxBase()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
