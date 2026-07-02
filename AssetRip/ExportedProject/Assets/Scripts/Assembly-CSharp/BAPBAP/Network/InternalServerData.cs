using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class InternalServerData
	{
		[Preserve]
		public string hostname;

		[Preserve]
		public int kcpPort;

		[Preserve]
		public int tcpPort;

		[Preserve]
		public int wsPort;
	}
}
