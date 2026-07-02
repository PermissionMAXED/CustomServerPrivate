using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class PingerData
	{
		[Preserve]
		public string pingerUrl;

		[Preserve]
		public string regionId;
	}
}
