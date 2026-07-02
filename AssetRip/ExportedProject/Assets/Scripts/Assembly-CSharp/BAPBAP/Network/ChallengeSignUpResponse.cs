using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeSignUpResponse
	{
		[Serializable]
		public class Reward
		{
			[Preserve]
			public int assetId;

			[Preserve]
			public int amount;
		}

		[Preserve]
		public string refCode;

		[Preserve]
		public Reward reward;
	}
}
