using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ErrorResponse
	{
		[Preserve]
		public long responseCode;

		[Preserve]
		public string errorCode;
	}
}
