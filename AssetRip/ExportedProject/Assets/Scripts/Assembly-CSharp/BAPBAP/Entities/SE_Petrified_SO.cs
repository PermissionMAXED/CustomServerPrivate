using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Petrified_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Petrified.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
