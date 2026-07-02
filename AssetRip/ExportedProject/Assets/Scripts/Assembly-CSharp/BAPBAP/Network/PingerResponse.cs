using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class PingerResponse
	{
		[Preserve]
		public PingerData[] pingers;
	}
}
