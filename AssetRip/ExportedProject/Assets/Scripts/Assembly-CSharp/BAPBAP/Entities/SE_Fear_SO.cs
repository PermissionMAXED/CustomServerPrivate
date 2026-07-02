using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Fear_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Fear.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
