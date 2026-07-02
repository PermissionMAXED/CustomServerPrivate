using System;

namespace BAPBAP.Entities
{
	public class SE_Clone : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Clone(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}
	}
}
