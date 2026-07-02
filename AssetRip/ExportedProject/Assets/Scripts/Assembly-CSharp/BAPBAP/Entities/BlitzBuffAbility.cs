using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BlitzBuffAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BlitzBuffAbility ability;

			public CustomShootSubroutine(BlitzBuffAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public PassiveSO blitzBuffPassive;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public int blitzBuffPassiveId;

		public override void PreAwake(EntityManager _entityManager)
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
