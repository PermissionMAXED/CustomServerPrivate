using System;
using System.Collections.Generic;
using BAPBAP.Entities.TargetDetection;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MechTargetedMissilesAbility : Ability
	{
		public class CustomFindTargetsSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechTargetedMissilesAbility ability;

			[NonSerialized]
			public List<EntityManager> temp;

			public CustomFindTargetsSubroutine(MechTargetedMissilesAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechTargetedMissilesAbility ability;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public byte silenceTrigger;

			[NonSerialized]
			public float shootDurationTime;

			[NonSerialized]
			public int numProjectiles;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public float fireRateTimer;

			[NonSerialized]
			public int spawnedProjectiles;

			public CustomShootSubroutine(MechTargetedMissilesAbility _ability, byte _finishTrigger, byte _silenceTrigger)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomClearUIMarkersSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechTargetedMissilesAbility ability;

			public CustomClearUIMarkersSubroutine(MechTargetedMissilesAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public BAPBAP.Entities.TargetDetection.TargetDetection targetDetection;

		[SerializeField]
		public GameObject mineSpellPrefab;

		[SerializeField]
		public GameObject explosionSpellPrefab;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("Indicator")]
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

		[Header("Hitbox-related")]
		[SerializeField]
		public float abilityRange;

		[SerializeField]
		public int maxTargets;

		[SerializeField]
		public float fireRate;

		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float explosionRadius;

		[SerializeField]
		public float explosionTtl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Misc")]
		[SerializeField]
		public float interpDuration;

		[SerializeField]
		public float height;

		[SerializeField]
		public AnimationCurve heightCurve;

		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
		public GameObject uiTargetMarkerPrefab;

		[Header("State-related")]
		[SerializeField]
		public float searchDuration;

		[SerializeField]
		public float searchCancelTime;

		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxShootPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxSearch;

		[SerializeField]
		public AudioClipData sfxSearchLoop;

		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public Dictionary<EntityManager, GameObject> uiTargetMarkers;

		public List<EntityManager> foundTargets => null;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void Start()
		{
		}

		[Server]
		public void SpawnHitbox(Transform target, int predTickNum)
		{
		}

		[ClientRpc]
		public void RpcOnMineStart(GameObject mineObj)
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

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnMineStart__GameObject(GameObject mineObj)
		{
		}

		public static void InvokeUserCode_RpcOnMineStart__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static MechTargetedMissilesAbility()
		{
		}
	}
}
