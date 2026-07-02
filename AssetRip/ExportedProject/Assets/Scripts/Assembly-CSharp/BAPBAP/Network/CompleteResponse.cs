using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class CompleteResponse
	{
		[Preserve]
		public string accountId;

		[Preserve]
		public string username;

		[Preserve]
		public int discriminator;

		[Preserve]
		public int level;

		[Preserve]
		public bool isAdmin;

		[Preserve]
		public bool isCompleted;

		[Preserve]
		public bool isGuest;

		[Preserve]
		public string email;
	}
}
