using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class WinnerLiveFeedElement
	{
		public int squadKills;

		public long endedAt;

		public string[] usernames;
	}
}
