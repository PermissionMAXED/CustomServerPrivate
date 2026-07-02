using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_WorkBench : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldownTime;

			[Header("FX Config")]
			public GameObject vfxReadyPrefab;

			public GameObject vfxSpawnedPrefab;

			public SFXData sfxSpawnedData;

			[Header("Consumable Config")]
			public Consumable[] consumables;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_WorkBench passive;

			[NonSerialized]
			public byte trigger;

			public CustomPassiveSubroutine(P_WorkBench _ability, byte _trigger)
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
		public int vfxSpawnedVfxId;

		public override PassiveConfiguration passiveConfig => null;

		public P_WorkBench(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void SpawnConsumable()
		{
		}
	}
}
