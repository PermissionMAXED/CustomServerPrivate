using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BossChadSequenceAbility : Ability
	{
		public class CustomAnimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadSequenceAbility ability;

			[NonSerialized]
			public AnimLayerIndices animLayer;

			[NonSerialized]
			public int stateHash;

			public CustomAnimSubroutine(BossChadSequenceAbility ability, AnimAction action, string animState, AnimLayerIndices animLayer)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSetSequenceSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadSequenceAbility ability;

			public CustomSetSequenceSubroutine(BossChadSequenceAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCastVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadSequenceAbility ability;

			public CustomCastVfxSubroutine(BossChadSequenceAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadSequenceAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(BossChadSequenceAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadSequenceAbility ability;

			[NonSerialized]
			public byte triggerNext;

			[NonSerialized]
			public byte triggerFinished;

			public CustomShootSubroutine(BossChadSequenceAbility _ability, byte next, byte finished)
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

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public GameObject spellPrefab3;

		[SerializeField]
		public Transform firingPoint1;

		[SerializeField]
		public Transform firingPoint2;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

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
		public float circleRadius;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime1;

		[SerializeField]
		public float recoveryTime2;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject rectIndicatorPrefab;

		[SerializeField]
		public float indicatorWidth;

		[SerializeField]
		public float indicatorLength;

		[SerializeField]
		public GameObject circleIndicatorPrefab;

		[Header("Effects")]
		[SerializeField]
		public float castSfxDelay;

		[Header("Sfx")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		public AudioClipData sfxCastCharge;

		[SerializeField]
		[Tooltip("Multiplier for audio source range. It will multiply min and max by this value")]
		public float sfxCastGlobalDistMult;

		[SerializeField]
		[Tooltip("Sets the minimum distance for the audio source to the given value. Its still affected by the multiplier")]
		public float sfxCastGlobalMinDist;

		[SerializeField]
		[Header("Vfx")]
		public ParticleSystem castVfx;

		[SerializeField]
		public ParticleSystem shootVfx;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public GameObject currentIndicator;

		[NonSerialized]
		public GameObject currentIndicator2;

		[NonSerialized]
		public bool disabled;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		[NonSerialized]
		public int[] attackSequence;

		[NonSerialized]
		public int currentAttackId;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void Start()
		{
		}

		public void ForceDisable()
		{
		}

		public void CastSpell(Vector3 lookDir, int attackId)
		{
		}

		public void ClDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcSpawnRectIndicator(float duration, Quaternion rot, Vector3 pos, int id)
		{
		}

		[ClientRpc]
		public void RpcSpawnCircleIndicator(Vector3 position, int id)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcPlayCastVFX()
		{
		}

		public void OnDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnRectIndicator__Single__Quaternion__Vector3__Int32(float duration, Quaternion rot, Vector3 pos, int id)
		{
		}

		public static void InvokeUserCode_RpcSpawnRectIndicator__Single__Quaternion__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnCircleIndicator__Vector3__Int32(Vector3 position, int id)
		{
		}

		public static void InvokeUserCode_RpcSpawnCircleIndicator__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlayCastVFX()
		{
		}

		public static void InvokeUserCode_RpcPlayCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static BossChadSequenceAbility()
		{
		}
	}
}
