using System;

namespace BAPBAP.Entities
{
	public class SE_Recast : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Recast(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}

		public override void ClDeactivate()
		{
		}
	}
}
