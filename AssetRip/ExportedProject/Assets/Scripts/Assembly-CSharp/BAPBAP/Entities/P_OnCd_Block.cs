using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_Block : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public GameObject vfxReadyPrefab;

			public GameObject vfxShieldBrokenPrefab;

			public GameObject vfxFollowPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnCd_Block passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public bool buffered;

			public CustomPassiveSubroutine(P_OnCd_Block _ability, byte _triggerFinished)
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		[NonSerialized]
		public int vfxShieldBrokenId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnCd_Block(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void ApplyBlock()
		{
		}

		public void ResetBlock()
		{
		}

		public override void OnImmuneDamageTrigger(int damage)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
