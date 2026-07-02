using System;

namespace BAPBAP.Network
{
	[Serializable]
	public struct PingData
	{
		public string subdomain;

		public int httpPort;

		public int wsPort;

		public int kcpPort;

		public int tcpPort;

		public string version;

		public PingStatus status;

		public override string ToString()
		{
			return null;
		}
	}
}
