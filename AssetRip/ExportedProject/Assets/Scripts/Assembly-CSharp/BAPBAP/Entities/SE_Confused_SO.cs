using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Confused_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Confused.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
