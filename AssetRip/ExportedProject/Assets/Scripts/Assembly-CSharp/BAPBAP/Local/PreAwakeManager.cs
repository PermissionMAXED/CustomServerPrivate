using BAPBAP.Build;
using BAPBAP.Debugging;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Local
{
	public class PreAwakeManager : MonoBehaviour
	{
		[SerializeField]
		public BapLogConfig bapLogConfig;

		[SerializeField]
		public NetworkConfig networkConfig;

		public static BuildEnvironment environment;

		public void Awake()
		{
		}
	}
}
