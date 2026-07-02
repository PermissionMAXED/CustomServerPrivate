using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class JiroPunchAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public JiroPunchAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomShootSubroutine(JiroPunchAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomAnimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public JiroPunchAbility ability;

			[NonSerialized]
			public AnimLayerIndices animLayer;

			[NonSerialized]
			public int stateHash;

			[NonSerialized]
			public CastFlags castFlag;

			public CustomAnimSubroutine(JiroPunchAbility ability, AnimAction action, string animState, AnimLayerIndices animLayer)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
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
		public GameObject damage3Prefab;

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
		public int damage3;

		[SerializeField]
		public float damage3Scaling;

		[SerializeField]
		public float ttl3;

		[Header("State-related")]
		[SerializeField]
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

		[SerializeField]
		[Header("SFX")]
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
