using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateHeal : EntityActivateBase
	{
		[Header("Hitbox Settings")]
		[SerializeField]
		public int healAmount;

		[SerializeField]
		[Range(0f, 1f)]
		public float healPercentage;

		[Server]
		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
