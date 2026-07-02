using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnShield_GainDmg : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float damageBuff;

			public float buffDuration;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_OnShield_GainDmg passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float time;

			[NonSerialized]
			public int shieldId;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public bool exited;

			public CustomPassiveSubroutine(P_OnShield_GainDmg _ability, byte _triggerFinished)
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

			public void UpdateExited()
			{
			}

			public void UpdateCooldown()
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public P_CooldownSubroutine cdSubroutine;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnShield_GainDmg(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnStatusEffectAppliedToSelfTrigger(int statusEffectId)
		{
		}
	}
}
