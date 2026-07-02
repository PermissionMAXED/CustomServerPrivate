using System;
using BAPBAP.Player;

namespace BAPBAP.Local
{
	public class GM_ReviveTeammateOnKill : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public GM_ReviveTeammateOnKill(Config _config = null)
		{
		}

		public override void OnPlayerKilled(PlayerManager killerPlayer, PlayerManager killedPlayer)
		{
		}
	}
}
