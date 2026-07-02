using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_BananaSlide_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_BananaSlide.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
