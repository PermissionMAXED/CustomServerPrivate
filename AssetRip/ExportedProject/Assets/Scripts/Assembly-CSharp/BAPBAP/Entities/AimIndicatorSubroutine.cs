using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AimIndicatorSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public float range;

		[NonSerialized]
		public bool projectile;

		public AimIndicatorSubroutine(Ability ability, float range, bool projectile = true)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
