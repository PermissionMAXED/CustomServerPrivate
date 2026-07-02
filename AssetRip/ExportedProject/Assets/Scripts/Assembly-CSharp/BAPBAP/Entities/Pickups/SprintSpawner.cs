using UnityEngine;

namespace BAPBAP.Entities.Pickups
{
	public class SprintSpawner : PickupSpawner
	{
		[Header("References")]
		[SerializeField]
		public GameObject sprintHitboxPrefab;

		[Header("Sprint Spawner Settings")]
		[SerializeField]
		public float speedIncreaseDuration;

		[SerializeField]
		public float additiveSpeed;

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
