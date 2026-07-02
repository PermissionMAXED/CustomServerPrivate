using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_MoveDash_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_MoveDash.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
