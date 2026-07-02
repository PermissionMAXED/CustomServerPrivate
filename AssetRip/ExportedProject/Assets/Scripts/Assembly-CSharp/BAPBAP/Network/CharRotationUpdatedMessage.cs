using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class CharRotationUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public int[] charIdsInRotation;
		}

		public string @event;

		public Payload payload;
	}
}
