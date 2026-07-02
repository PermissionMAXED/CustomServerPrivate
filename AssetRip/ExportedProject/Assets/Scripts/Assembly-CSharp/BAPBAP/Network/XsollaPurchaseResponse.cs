using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class XsollaPurchaseResponse
	{
		[Preserve]
		public string token;

		[Preserve]
		public string url;

		[Preserve]
		public bool sandbox;
	}
}
