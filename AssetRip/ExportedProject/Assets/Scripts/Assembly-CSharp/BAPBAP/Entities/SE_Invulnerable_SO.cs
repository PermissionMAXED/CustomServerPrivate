using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Invulnerable_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Invulnerable.Config configuration;

		public static int Id;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
