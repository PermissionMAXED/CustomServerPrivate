using System;
using BAPBAP.UI;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class PassResponse
	{
		[Serializable]
		public class PassLevel
		{
			[Preserve]
			public int level;

			[Preserve]
			public int xpNeeded;

			[Preserve]
			public Listing[] listings;
		}

		[Serializable]
		public class Listing
		{
			[Preserve]
			public string listingId;

			[Preserve]
			public AssetModel[] costs;

			[Preserve]
			public AssetModel[] rewards;

			[Preserve]
			public AssetModel[] requirements;

			[Preserve]
			public int purchases;
		}

		[Preserve]
		public int passId;

		[Preserve]
		public PassLevel[] passLevels;
	}
}
