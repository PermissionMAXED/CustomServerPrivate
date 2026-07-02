using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Sniper : AbilityBehaviour
	{
		[Serializable]
		public class Config : AB_Consumable_Base_Use.Config
		{
			[Header("Shoot Config")]
			public MotionLockType usingMotionLockType;

			public RotationLockType usingRotationLockType;

			public float shootCooldown;

			public CommandId targetAbility;

			public CameraVehicle.DriverVehiclePreset camPreset;

			[Header("Hitbox Config")]
			public GameObject projectilePrefab;

			public float firingPointOffset;

			public int damage;

			public float damageScaling;

			public bool doCrits;

			public float speed;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;
		}

		public class CustomWaitForInputSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Sniper behaviour;

			[NonSerialized]
			public byte shootTrigger;

			[NonSerialized]
			public byte cancelTrigger;

			[NonSerialized]
			public CastFlags cancelCastFlags;

			public CustomWaitForInputSubroutine(AB_Sniper behaviour, byte shootTrigger, byte cancelTrigger, CastFlags cancelCastFlags)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Sniper behaviour;

			public CustomShootSubroutine(AB_Sniper behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBeginSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Sniper behaviour;

			public CustomBeginSubroutine(AB_Sniper behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFinishSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Sniper behaviour;

			public CustomFinishSubroutine(AB_Sniper behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool isUsing;

		public AB_Sniper(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnDeactivate()
		{
		}

		public void Shoot(EntityManager cM, int predTickNum)
		{
		}

		public void SetUsingEnabled()
		{
		}

		public void SetUsingDisabled()
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
