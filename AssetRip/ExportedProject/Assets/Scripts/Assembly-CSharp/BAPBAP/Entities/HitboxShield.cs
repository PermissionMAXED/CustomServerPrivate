namespace BAPBAP.Entities
{
	public class HitboxShield : Hitbox
	{
		public override void OnHitboxHit(Hitbox otherHbox, HitboxBase originalHitbox)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
