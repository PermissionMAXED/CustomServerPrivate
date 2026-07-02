using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_OxygenDash_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_OxygenDash.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
