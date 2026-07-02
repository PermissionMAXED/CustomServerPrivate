using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RunNGunAbility : Ability
	{
		public class CustomStartCycleSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RunNGunAbility ability;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public int maxBullets;

			public CustomStartCycleSubroutine(RunNGunAbility ability, byte triggerFinished, int maxBullets)
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

		public class CustomCycleSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public RunNGunAbility ability;

			[NonSerialized]
			public byte shootTrigger;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public byte triggerCanceled;

			[NonSerialized]
			public float cycleTime;

			[NonSerialized]
			public float timeElapsed;

			public CustomCycleSubroutine(RunNGunAbility ability, byte shootTrigger, byte triggerFinished, byte triggerCanceled, float cycleTime)
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

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RunNGunAbility ability;

			public CustomShootSubroutine(RunNGunAbility ability)
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
		public Transform firingPointL;

		[SerializeField]
		public Transform firingPointR;

		[SerializeField]
		public float spread;

		[SerializeField]
		public int maxBullets;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float cycleTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxMuzzlePrefab;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public int bulletsLeft;

		[NonSerialized]
		public bool isCrit;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
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
