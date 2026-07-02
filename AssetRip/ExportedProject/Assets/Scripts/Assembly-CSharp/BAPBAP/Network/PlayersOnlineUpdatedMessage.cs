using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class PlayersOnlineUpdatedMessage
	{
		public string @event;

		public int payload;
	}
}
