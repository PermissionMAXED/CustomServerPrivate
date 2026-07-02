using BAPBAP.Items;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class LockedLootCrate_Key : LockedLootCrate
	{
		[SerializeField]
		public Item keyItem;

		[SerializeField]
		[Header("Translation Keys")]
		public string unlockingKey;

		[SerializeField]
		public string emptyKey;

		[SerializeField]
		public string needsKey;

		[SerializeField]
		public string costKey;

		[SerializeField]
		public EntityActivateMaterialPropertyBlock[] activateOnCasting;

		[SerializeField]
		public EntityActivateMaterialPropertyBlock[] activateOnSuccessful;

		[SerializeField]
		public EntityActivateMaterialPropertyBlock[] activateOnFailed;

		public override void InitializeLockType()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void OnCastingCompleted(EntityManager entity, int slotId)
		{
		}

		public override void OnCastingCanceled(EntityManager entity, int slotId)
		{
		}

		public override void OnCastingStarted(EntityManager entity, int slotId)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
