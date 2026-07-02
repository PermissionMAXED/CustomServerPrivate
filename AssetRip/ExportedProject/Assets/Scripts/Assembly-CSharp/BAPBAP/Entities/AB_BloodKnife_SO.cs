using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_BloodKnife_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_BloodKnife.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
