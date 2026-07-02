using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AimConstraintSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public bool aimed;

		[NonSerialized]
		public bool assist;

		[NonSerialized]
		public bool cardinal;

		[NonSerialized]
		public bool move;

		[NonSerialized]
		public float range;

		[NonSerialized]
		public InputSource source;

		public AimConstraintSubroutine(Ability ability, bool aimed = false, bool assist = true, bool cardinal = false, bool move = false, float range = 0f, InputSource source = InputSource.Any)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SetRange(float r)
		{
		}

		public bool IsLocalClient()
		{
			return false;
		}

		public bool IsExpectedSource()
		{
			return false;
		}
	}
}
