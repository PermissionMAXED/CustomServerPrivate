using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class InternalServersResponse
	{
		[Preserve]
		public InternalServerData[] servers;
	}
}
