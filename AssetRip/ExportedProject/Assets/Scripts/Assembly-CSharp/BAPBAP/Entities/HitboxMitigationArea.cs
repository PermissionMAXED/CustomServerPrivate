using System;
using Mirror;

namespace BAPBAP.Entities
{
	public class HitboxMitigationArea : HitboxTriggerbox
	{
		[NonSerialized]
		public float mitigationAmount;

		public new void Start()
		{
		}

		[ServerCallback]
		public new void Update()
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
