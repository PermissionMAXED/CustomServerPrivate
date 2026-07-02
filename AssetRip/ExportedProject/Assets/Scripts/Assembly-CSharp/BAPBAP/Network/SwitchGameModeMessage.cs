using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchGameModeMessage
	{
		[Serializable]
		public class Payload
		{
			public int gameModeId;

			public string password;
		}

		public string @event;

		public Payload payload;
	}
}
