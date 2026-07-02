using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class GiveXpBody
	{
		[Preserve]
		public int charId;

		[Preserve]
		public int amount;
	}
}
