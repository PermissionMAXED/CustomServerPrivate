using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Ward_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_Ward.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
