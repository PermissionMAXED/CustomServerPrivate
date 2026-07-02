using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HeavyDigitalBeamAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyDigitalBeamAbility ability;

			public CustomShootSubroutine(HeavyDigitalBeamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCloneAimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyDigitalBeamAbility ability;

			public CustomCloneAimSubroutine(HeavyDigitalBeamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCloneFireSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyDigitalBeamAbility ability;

			public CustomCloneFireSubroutine(HeavyDigitalBeamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCloneSilencedSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyDigitalBeamAbility ability;

			public CustomCloneSilencedSubroutine(HeavyDigitalBeamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

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
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxMuzzlePrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		public AudioClipData sfxMuzzle;

		[SerializeField]
		public CharVoicelineConfig voicelineCast;

		[SerializeField]
		public CharVoicelineConfig voicelineKill;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public DigitalCloneAbility digitalCloneAbility;

		[NonSerialized]
		public DigitalCloneUpgradeAbility digitalCloneUpgradeAbility;

		[NonSerialized]
		public List<HeavyDigitalBeamCloneAbility> cloneAbilities;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetKill(EntityManager otherEntityManager)
		{
		}

		[ClientRpc]
		public void RcpOnTargetKill(int charId)
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

		public void UserCode_RcpOnTargetKill__Int32(int charId)
		{
		}

		public static void InvokeUserCode_RcpOnTargetKill__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static HeavyDigitalBeamAbility()
		{
		}
	}
}
