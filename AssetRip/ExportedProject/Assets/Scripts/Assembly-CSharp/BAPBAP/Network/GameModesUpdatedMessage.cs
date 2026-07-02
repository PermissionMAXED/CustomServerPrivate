using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class GameModesUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public int gameModeId;

			public int status;

			public string message;

			public string timestampStart;

			public string timestampEnd;

			public bool isPasswordProtected;
		}

		public string @event;

		public Payload[] payload;
	}
}
