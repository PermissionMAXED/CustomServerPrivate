using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SetCreatorCodeRequest
	{
		[Preserve]
		public string creatorCode;
	}
}
