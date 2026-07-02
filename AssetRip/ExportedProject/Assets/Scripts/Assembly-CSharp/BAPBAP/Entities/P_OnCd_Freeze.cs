using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_Freeze : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float freezeDuration;

			public GameObject vfxReadyPrefab;

			public SFXData sfxReadyData;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnCd_Freeze passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnCd_Freeze _ability, byte _triggerFinished)
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		[NonSerialized]
		public int bufferCount;

		[NonSerialized]
		public bool startBuffer;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnCd_Freeze(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}
	}
}
