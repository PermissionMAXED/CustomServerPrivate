using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class EquipSkinBody
	{
		[Preserve]
		public int charId;

		[Preserve]
		public int assetId;
	}
}
