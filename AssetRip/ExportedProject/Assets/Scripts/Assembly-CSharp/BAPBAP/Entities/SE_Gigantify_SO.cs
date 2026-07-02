using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Gigantify_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Gigantify.Config configuration;

		public static int Id;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
