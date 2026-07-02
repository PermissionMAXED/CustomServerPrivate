using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_RCXD : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Custom Config")]
			public GameObject rcxdPrefab;

			public GameObject usingVfx;

			public CommandId inputTargetAbility;

			public float activeTtl;
		}

		public new class CustomPlaceConsumableSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCXD behaviour;

			[NonSerialized]
			public RaycastHit hit;

			[NonSerialized]
			public LayerMask obstacleMask;

			public CustomPlaceConsumableSubroutine(AB_RCXD behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomWaitToDetonateSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCXD behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float elapsedTime;

			public CustomWaitToDetonateSubroutine(AB_RCXD behaviour, byte trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomDetonateSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCXD behaviour;

			public CustomDetonateSubroutine(AB_RCXD behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public new Config config;

		[NonSerialized]
		public RCXDController rcxdInstance;

		public AB_RCXD(Config _config)
			: base(null)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void ClStartAuth()
		{
		}

		public override void ClStopAuth()
		{
		}

		public override void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}
	}
}
