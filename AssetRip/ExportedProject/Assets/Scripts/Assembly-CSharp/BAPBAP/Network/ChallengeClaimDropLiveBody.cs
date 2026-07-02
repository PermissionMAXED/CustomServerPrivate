using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeClaimDropLiveBody
	{
		[Preserve]
		public string listingId;

		[Preserve]
		public string entitlementId;
	}
}
