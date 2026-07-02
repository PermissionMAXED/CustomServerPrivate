using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class StartCustomGameSuccessResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string message;
		}

		[Preserve]
		public Payload payload;
	}
}
