using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_PoisonInfuse_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_PoisonInfuse.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
