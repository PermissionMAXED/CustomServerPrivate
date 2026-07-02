using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TeleportTestAbility : Ability
	{
		public class CustomTeleportTestSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public TeleportTestAbility ability;

			public CustomTeleportTestSubroutine(TeleportTestAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("State-related")]
		public float autoCastTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float distance;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
