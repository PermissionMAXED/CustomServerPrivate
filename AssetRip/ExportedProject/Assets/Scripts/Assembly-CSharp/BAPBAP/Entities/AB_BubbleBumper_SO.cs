using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_BubbleBumper_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_BubbleBumper.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
