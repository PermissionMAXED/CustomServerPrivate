using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class FriendGameTimeResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;

			[Preserve]
			public int timestampStart;
		}

		[Preserve]
		public Payload payload;
	}
}
