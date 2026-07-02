using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Amplify_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Amplify.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
