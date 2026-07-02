using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class SfxRandomDestroySubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SfxRandomSubroutine sfxSubroutine;

		public SfxRandomDestroySubroutine(EntityManager entityManager, SfxRandomSubroutine sfxSubroutine)
		{
		}

		public SfxRandomDestroySubroutine(Ability ability, SfxRandomSubroutine sfxSubroutine)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
