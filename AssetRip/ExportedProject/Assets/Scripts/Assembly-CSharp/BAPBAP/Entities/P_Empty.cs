using System;

namespace BAPBAP.Entities
{
	public class P_Empty : Passive
	{
		[NonSerialized]
		public PassiveConfiguration config;

		public override PassiveConfiguration passiveConfig => null;

		public P_Empty(EntityManager entityManager, PassiveConfiguration config)
			: base(null)
		{
		}
	}
}
