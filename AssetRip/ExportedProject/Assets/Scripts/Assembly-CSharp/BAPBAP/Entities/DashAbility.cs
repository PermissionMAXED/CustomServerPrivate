using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DashAbility : Ability
	{
		public class CustomAnimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DashAbility ability;

			[NonSerialized]
			public AnimLayerIndices animLayer;

			[NonSerialized]
			public int stateHash;

			[NonSerialized]
			public CastFlags castFlag;

			public CustomAnimSubroutine(DashAbility ability, AnimAction action, string animState, AnimLayerIndices animLayer)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDashSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public DashAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float dashTime;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(DashAbility ability, byte trigger, float dashTime)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
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

		public class CustomCooldownHitSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DashAbility ability;

			[NonSerialized]
			public byte trigger;

			public CustomCooldownHitSubroutine(DashAbility _ability, byte trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[SerializeField]
		[Header("General")]
		public float dashSpeed;

		[SerializeField]
		public float dashDecel;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float dashTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public bool hitSuccess;

		[NonSerialized]
		public bool cdrQReady;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void ResetCd()
		{
		}

		public void ResetCDR()
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
	}
}
