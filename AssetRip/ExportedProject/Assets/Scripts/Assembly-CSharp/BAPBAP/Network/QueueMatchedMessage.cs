using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class QueueMatchedMessage
	{
		[Serializable]
		public class Payload
		{
			public PlayerData[] players;

			public int currentPlayerCount;

			public int maxPlayerCount;

			public int charSelectMillis;

			public int[] availableCharacters;

			public int[] gameModifierIds;

			public int levelId;

			public int unityGameMode;

			public DimensionData[] dimensionData;
		}

		public string @event;

		public Payload payload;
	}
}
