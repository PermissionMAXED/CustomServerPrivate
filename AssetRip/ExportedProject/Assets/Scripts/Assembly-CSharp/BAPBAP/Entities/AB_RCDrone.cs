using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_RCDrone : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Custom Config")]
			public GameObject rcxdPrefab;

			public CommandId inputTargetAbility;

			public GameObject usingLoopVfx;

			[Header("Drop Config")]
			public float shootRecoveryTime;

			public int maxAmmo;

			public float activeTtl;
		}

		public new class CustomPlaceConsumableSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCDrone behaviour;

			[NonSerialized]
			public RaycastHit hit;

			[NonSerialized]
			public LayerMask obstacleMask;

			public CustomPlaceConsumableSubroutine(AB_RCDrone behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFireSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCDrone behaviour;

			public CustomFireSubroutine(AB_RCDrone behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomTryStopSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCDrone behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte doneTrigger;

			public CustomTryStopSubroutine(AB_RCDrone behaviour, byte trigger, byte doneTrigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomDestroySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_RCDrone behaviour;

			public CustomDestroySubroutine(AB_RCDrone behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public new Config config;

		[NonSerialized]
		public RCDroneController droneInstance;

		[NonSerialized]
		public int ammo;

		[NonSerialized]
		public float usingElapsedTime;

		[NonSerialized]
		public bool isUsing;

		[NonSerialized]
		public VFXStopParticles usingLoopVfxInstance;

		public AB_RCDrone(Config _config)
			: base(null)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnDeactivate()
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

		public void OnIsUsingChanged()
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
}
