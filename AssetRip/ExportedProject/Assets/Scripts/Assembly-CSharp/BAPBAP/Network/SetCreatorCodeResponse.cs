using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SetCreatorCodeResponse
	{
		[Preserve]
		public string creatorCode;

		[Preserve]
		public string creatorName;
	}
}
