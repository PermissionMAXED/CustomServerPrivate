using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class AsyncPurchaseMessage
	{
		[Serializable]
		public class Payload
		{
			public string source;

			public Asset[] rewards;
		}

		public Payload payload;
	}
}
