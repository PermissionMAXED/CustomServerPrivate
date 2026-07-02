using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class CustomUpdateSettingsMessage
	{
		[Serializable]
		public class Payload
		{
			public CustomGameSettingsData settings;
		}

		public string @event;

		public Payload payload;
	}
}
