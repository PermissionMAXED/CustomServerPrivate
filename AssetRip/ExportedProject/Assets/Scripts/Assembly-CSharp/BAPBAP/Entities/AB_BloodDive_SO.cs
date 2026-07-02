using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_BloodDive_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_BloodDive.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
