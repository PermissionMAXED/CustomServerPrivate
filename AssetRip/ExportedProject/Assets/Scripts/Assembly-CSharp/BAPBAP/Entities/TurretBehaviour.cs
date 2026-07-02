using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TurretBehaviour : NpcBehaviour
	{
		public class CustomAlertStateSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public TurretBehaviour npcBehaviour;

			[NonSerialized]
			public byte targetLostTrigger;

			public CustomAlertStateSubroutine(TurretBehaviour _turretBehaviour, byte _targetLostTrigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[Header("General")]
		[SerializeField]
		public Transform turretAim;

		[SerializeField]
		[Header("Abilities")]
		public AbilityTriggerData shotAbility;

		[SerializeField]
		public AbilityTriggerData chargedShotAbility;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager e)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
