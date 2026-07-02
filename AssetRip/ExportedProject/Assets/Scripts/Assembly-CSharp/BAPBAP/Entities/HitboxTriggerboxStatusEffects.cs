using Mirror;

namespace BAPBAP.Entities
{
	public class HitboxTriggerboxStatusEffects : HitboxTriggerbox
	{
		[ServerCallback]
		public new void Update()
		{
		}

		public override void OnDespawn()
		{
		}

		public override void OnEnter(EntityManager entity)
		{
		}

		public override void OnExit(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
