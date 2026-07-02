using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxHpCollider : MonoBehaviour
	{
		[SerializeField]
		public HitboxHp hitbox;

		public void OnTriggerEnter(Collider collider)
		{
		}
	}
}
