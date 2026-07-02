using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Chains_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_Chains.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
