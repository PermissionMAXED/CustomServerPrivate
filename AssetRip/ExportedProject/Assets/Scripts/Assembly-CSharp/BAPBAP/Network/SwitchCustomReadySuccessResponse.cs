using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchCustomReadySuccessResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;

			[Preserve]
			public bool isReady;
		}

		[Preserve]
		public Payload payload;
	}
}
