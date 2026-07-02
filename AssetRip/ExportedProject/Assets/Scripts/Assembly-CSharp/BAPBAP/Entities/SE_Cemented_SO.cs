using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Cemented_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Cemented.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
