using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_HealingPotion_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_HealingPotion.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
