using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class FullbodyAnimLockSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public FullbodyAnimLockAction action;

		public FullbodyAnimLockSubroutine(EntityManager entityManager, FullbodyAnimLockAction action)
		{
		}

		public FullbodyAnimLockSubroutine(Ability ability, FullbodyAnimLockAction action)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
