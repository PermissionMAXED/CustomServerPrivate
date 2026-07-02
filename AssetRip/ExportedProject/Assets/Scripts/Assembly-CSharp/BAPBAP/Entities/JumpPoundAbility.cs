using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class JumpPoundAbility : Ability
	{
		public class CustomAimConstraintSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public InputSystem inputSystem;

			[NonSerialized]
			public JumpPoundAbility ability;

			[NonSerialized]
			public bool aoe;

			[NonSerialized]
			public bool assist;

			[NonSerialized]
			public bool aimLock;

			[NonSerialized]
			public float range;

			public CustomAimConstraintSubroutine(JumpPoundAbility ability, bool aoe = false, bool assist = true, bool aimLock = false, float range = 0f)
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

			public float GetRange()
			{
				return 0f;
			}
		}

		public class CustomMouseIndicatorSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public JumpPoundAbility ability;

			[NonSerialized]
			public IndicatorMouse indMouse;

			[NonSerialized]
			public Vector2 mouseHalfScale;

			[NonSerialized]
			public Vector2 baseHalfScale;

			[NonSerialized]
			public float maxDistance;

			[NonSerialized]
			public bool rotateWithDirection;

			[NonSerialized]
			public float hitboxScaleRatio;

			[NonSerialized]
			public float jumpDistanceRatio;

			[NonSerialized]
			public bool indicatorActive;

			public CustomMouseIndicatorSubroutine(JumpPoundAbility ability, GameObject indicatorPrefab, Vector2 mouseHalfScale, Vector2 baseHalfScale, float maxDistance, float angleSpread, bool rotateWithDirection)
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

			public void ClSetIndicatorState(bool isEnabled)
			{
			}

			public void OnIndicatorChanged()
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

		public class CustomDestroyVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public JumpPoundAbility ability;

			public CustomDestroyVisibleIndicatorSubroutine(JumpPoundAbility ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public JumpPoundAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 jumpPoint;

			public CustomJumpSubroutine(JumpPoundAbility _ability, byte _trigger, float _waitTime)
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

		[Header("Hitbox-related")]
		[SerializeField]
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
		public float rageHitboxRadius;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

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
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public GameObject visibleIndicatorEnemyPrefab;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastingPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Misc")]
		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float jumpRadiusCheck;

		[SerializeField]
		public float maxJumpDistance;

		[SerializeField]
		public float rageMaxJumpDistance;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public RageAbility rageAbility;

		[NonSerialized]
		public GameObject currentIndicatorObject;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void ResetCooldown()
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
		public void RpcSpawnVisibleIndicator(Vector3 position, float radius)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3__Single(Vector3 position, float radius)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static JumpPoundAbility()
		{
		}
	}
}
