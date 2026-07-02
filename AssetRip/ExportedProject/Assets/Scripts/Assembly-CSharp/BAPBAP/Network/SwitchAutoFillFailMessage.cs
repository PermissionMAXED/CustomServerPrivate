using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchAutoFillFailMessage
	{
		[Serializable]
		public class Payload
		{
			public string errorCode;
		}

		public string @event;

		public Payload payload;
	}
}
