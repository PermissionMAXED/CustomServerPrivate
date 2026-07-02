using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class DailyResponse
	{
		[Preserve]
		public string timestamp;

		[Preserve]
		public int progress;

		[Preserve]
		public int max;
	}
}
