using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MechSlashAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechSlashAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomShootSubroutine(MechSlashAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDashSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public MechSlashAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float dashTime;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(MechSlashAbility ability, byte trigger, float dashTime)
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

		[SerializeField]
		[Header("General")]
		public Transform firingPoint;

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
		public GameObject damage1Prefab;

		[SerializeField]
		public GameObject damage2Prefab;

		[SerializeField]
		public GameObject hitboxDashPrefab;

		[SerializeField]
		public int damage1;

		[SerializeField]
		public float damage1Scaling;

		[SerializeField]
		public float ttl1;

		[SerializeField]
		public int damage2;

		[SerializeField]
		public float damage2Scaling;

		[SerializeField]
		public float ttl2;

		[SerializeField]
		public int damageDash;

		[SerializeField]
		public float damageDashScaling;

		[SerializeField]
		public float ttlDash;

		[SerializeField]
		public float dashDuration;

		[SerializeField]
		public float dashSpeed;

		[SerializeField]
		public float dashDecel;

		[SerializeField]
		public List<StatusEffectInfo> statusEffectsDash;

		[SerializeField]
		[Header("State-related")]
		public float castingTime1;

		[SerializeField]
		public float recoveryTime1;

		[SerializeField]
		public float cooldownTime1;

		[SerializeField]
		public float castingTime2;

		[SerializeField]
		public float recoveryTime2;

		[SerializeField]
		public float cooldownTime2;

		[SerializeField]
		public float castingTime3;

		[SerializeField]
		public float recoveryTime3;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float comboResetTime;

		[SerializeField]
		public float finalKickcomboResetTime;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxKick1Prefab;

		[SerializeField]
		public GameObject vfxKick2Prefab;

		[SerializeField]
		public GameObject vfxKick3Prefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast1;

		[SerializeField]
		public AudioClipData sfxCast2;

		[SerializeField]
		public AudioClipData sfxCast3;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void DoPunch(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, float ttl, int predTickNum, int id)
		{
		}

		public void ShootDash(Vector3 lookDir, int predTickNum)
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
