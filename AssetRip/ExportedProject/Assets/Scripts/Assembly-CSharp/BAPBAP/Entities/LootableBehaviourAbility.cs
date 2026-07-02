using System;
using BAPBAP.Local;

namespace BAPBAP.Entities
{
	public class LootableBehaviourAbility : BehaviourAbilityComponent
	{
		[NonSerialized]
		public ItemManager itemManager;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void UpdateAbilityBehaviourChanged(int consumableSlot)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
