using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CatShotAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CatShotAbility ability;

			public CustomShootSubroutine(CatShotAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public GameObject catSpellPrefabSmall;

		[SerializeField]
		public GameObject catSpellPrefabBig;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float abilityRadius;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxActivateTime;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		[Header("Cats")]
		public float catWaitDuration;

		[SerializeField]
		public float catTtl;

		[SerializeField]
		public float catTravelSpeed;

		[SerializeField]
		public float catSpawnDistanceAroundTarget;

		[SerializeField]
		public AnimationCurve catSpeedCurve;

		[SerializeField]
		public float catInterpDuration;

		[SerializeField]
		public float height;

		[SerializeField]
		public AnimationCurve heightCurve;

		[Header("Cat Heal")]
		[SerializeField]
		public int catBigHealAmount;

		[SerializeField]
		[Range(0f, 1f)]
		public float catBigHealPercent;

		[SerializeField]
		public int catSmallHealAmount;

		[SerializeField]
		[Range(0f, 1f)]
		public float catSmallHealPercent;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public GameObject visibleIndicatorEnemyPrefab;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData castSfx;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 landingPoint, int predTickNum)
		{
		}

		[Server]
		public void OnHitSuccess(EntityManager hittedEntity, HitboxBase hitboxBase)
		{
		}

		[Server]
		public void OnHitSuccessHealSmall(EntityManager hittedEntity, HitboxBase hitboxBase)
		{
		}

		[Server]
		public void OnHitSuccessHealBig(EntityManager hittedEntity, HitboxBase hitboxBase)
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3(Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CatShotAbility()
		{
		}
	}
}
