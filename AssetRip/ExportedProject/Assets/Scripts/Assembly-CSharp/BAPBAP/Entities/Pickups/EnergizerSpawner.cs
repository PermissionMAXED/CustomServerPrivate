using UnityEngine;

namespace BAPBAP.Entities.Pickups
{
	public class EnergizerSpawner : PickupSpawner
	{
		[Header("References")]
		[SerializeField]
		public GameObject sprintHitboxPrefab;

		[Header("Spawner Settings")]
		[SerializeField]
		public float damageIncreaseDuration;

		[SerializeField]
		public float damageIncreasePercent;

		[SerializeField]
		public float ttl;

		public override bool CharGetPickup(EntityManager entityManager)
		{
			return false;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
