using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class CustomSetTeamMessage
	{
		[Serializable]
		public class Payload
		{
			public int teamId;
		}

		public string @event;

		public Payload payload;
	}
}
