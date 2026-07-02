using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_CDReset_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_CDReset.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
