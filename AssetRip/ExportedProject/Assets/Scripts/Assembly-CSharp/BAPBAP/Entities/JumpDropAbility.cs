using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class JumpDropAbility : Ability
	{
		public class CustomJumpSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public JumpDropAbility ability;

			public CustomJumpSubroutine(JumpDropAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDiveSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public JumpDropAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			public CustomDiveSubroutine(JumpDropAbility _ability, byte _trigger, float _waitTime)
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

			public override void OnNetDeserialize(NetworkReader netReader)
			{
			}

			public override void OnNetSerialize(NetworkWriter netWriter)
			{
			}

			public override bool OnNetDebugCompare(NetworkReader netReader)
			{
				return false;
			}

			public override void OnNetDebugLog(StringBuilder sb)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float selfShieldPercentage;

		[SerializeField]
		public float allyShieldPercentage;

		[SerializeField]
		public float shieldDuration;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float diveTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

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

		[SerializeField]
		[Header("Misc")]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
		public float jumpRadiusCheck;

		[SerializeField]
		public float maxDiveDistance;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxJumpPrefab;

		[SerializeField]
		public GameObject vfxDivePrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxCast;

		[SerializeField]
		public AudioClipData sfxDive;

		[SerializeField]
		public CharVoicelineConfig voiceline;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public Vector3 jumpPoint;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		[Server]
		public override void OnHitboxEnd(List<EntityManager> entityHits)
		{
		}

		public void Shoot(Vector3 landingPosition, int predTickNum)
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

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
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

		static JumpDropAbility()
		{
		}
	}
}
