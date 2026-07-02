using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxRing : HitboxDps
	{
		[SerializeField]
		public float ringSize;

		public override void ApplyHit(Hitbox.EntityHit entityHit)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
