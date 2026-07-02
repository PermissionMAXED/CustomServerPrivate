using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengePreviewResponse
	{
		[Preserve]
		public int prizePool;

		[Preserve]
		public int numSignUps;

		[Preserve]
		public int numSignUpsNeeded;
	}
}
