using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class AutoFillUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public bool isAutoFill;
		}

		public string @event;

		public Payload payload;
	}
}
