using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_RCDrone_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_RCDrone.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
