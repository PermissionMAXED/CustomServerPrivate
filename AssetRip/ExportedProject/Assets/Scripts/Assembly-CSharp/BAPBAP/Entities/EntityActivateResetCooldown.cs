using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateResetCooldown : EntityActivateBase
	{
		[SerializeField]
		public CharVoicelineConfig _voiceline;

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
