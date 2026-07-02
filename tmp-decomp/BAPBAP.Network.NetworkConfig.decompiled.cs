using System;
using BAPBAP.Build;
using UnityEngine;

namespace BAPBAP.Network;

[CreateAssetMenu(fileName = "NetworkConfig", menuName = "BAPBAP/Configuration/Network")]
public class NetworkConfig : ScriptableObject
{
	[Serializable]
	public class ServerConfig
	{
		public string MatchmakingHost;

		public int ListenPort;

		public string HeaderSecretKey;

		public string HeaderSecret;

		public string DebugPassword;

		public string DebugSquadPassword;

		public string DevGameAuthId;

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	public class ClientConfig
	{
		public string ApiHost;

		public string CookieDomain;

		public string CookieSessionKey;

		public override string ToString()
		{
			return null;
		}
	}

	public const string SERVER_RESOURCE_PATH = "Server";

	public const string CLIENT_RESOURCE_PATH = "Client";

	[SerializeField]
	public BuildEnvironment _targetEnvironment;

	[NamedArray(typeof(BuildEnvironment), 0)]
	[SerializeField]
	public ServerConfig[] _serverList;

	[SerializeField]
	[NamedArray(typeof(BuildEnvironment), 0)]
	public ClientConfig[] _clientList;

	[NonSerialized]
	public ServerConfig _server;

	[NonSerialized]
	public ClientConfig _client;

	public BuildEnvironment TargetEnvironment => default(BuildEnvironment);

	public ServerConfig Server => null;

	public ClientConfig Client => null;

	public T LoadJsonFromResources<T>(string path)
	{
		return default(T);
	}

	public ServerConfig GetServer(BuildEnvironment environment)
	{
		return null;
	}

	public ClientConfig GetClient(BuildEnvironment environment)
	{
		return null;
	}
}
