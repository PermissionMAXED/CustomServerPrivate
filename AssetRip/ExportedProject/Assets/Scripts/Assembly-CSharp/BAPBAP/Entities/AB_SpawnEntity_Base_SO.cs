using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_SpawnEntity_Base_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_SpawnEntity_Base.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
