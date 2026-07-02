using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class CustomUpdateSettingsResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public CustomGameSettingsData settings;

			[Preserve]
			public string warningMessage;

			[Preserve]
			public string errorCode;

			[Preserve]
			public int maxTeams;

			[Preserve]
			public MapMappingEntry[] mapMapping;
		}

		[Serializable]
		public class MapMappingEntry
		{
			public int unityGameModeId;

			public int[] mapIds;
		}

		[Preserve]
		public Payload payload;
	}
}
