using System;

namespace BAPBAP.Entities
{
	[Serializable]
	public class StatusEffectInfo
	{
		public StatusEffectSO statusEffect;

		public float duration;

		public float multiplier;

		public StatusEffectInfo(StatusEffectSO statusEffect, float duration, float multiplier)
		{
		}

		public StatusEffectInfo(int statusEffectId, float duration, float multiplier)
		{
		}
	}
}
