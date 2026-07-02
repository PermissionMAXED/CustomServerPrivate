using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class StartCustomGameFailResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string warningMessage;

			[Preserve]
			public string errorCode;

			[Preserve]
			public bool showForceStartModal;
		}

		[Preserve]
		public Payload payload;
	}
}
