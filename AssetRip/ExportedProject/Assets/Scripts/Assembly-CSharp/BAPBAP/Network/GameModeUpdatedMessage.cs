using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class GameModeUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public int gameModeId;
		}

		public string @event;

		public Payload payload;
	}
}
