using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class LinkResponse
	{
		[Preserve]
		public string provider;

		[Preserve]
		public string @params;
	}
}
