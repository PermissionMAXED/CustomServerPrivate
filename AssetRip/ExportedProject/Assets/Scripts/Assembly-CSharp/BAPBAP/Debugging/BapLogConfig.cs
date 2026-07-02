using System;
using AYellowpaper.SerializedCollections;
using BAPBAP.Build;
using UnityEngine;

namespace BAPBAP.Debugging
{
	[CreateAssetMenu(fileName = "BapLogConfig", menuName = "BAPBAP/Configuration/Debug/BapLog")]
	public class BapLogConfig : ScriptableObject
	{
		public const string RESOURCE_PATH = "Logs";

		public SerializedDictionary<BapLog.BapLogLevel, LogType> LogLevelTypeMapping;

		[SerializeField]
		public BuildEnvironment _targetEnvironment;

		[SerializeField]
		[NamedArray(typeof(BuildEnvironment), 0)]
		public LogConfig[] _logConfigList;

		[NonSerialized]
		public LogConfig _logConfig;

		public BuildEnvironment TargetEnvironment => default(BuildEnvironment);

		public LogConfig Config => null;

		public T LoadJsonFromResources<T>(string path)
		{
			return default(T);
		}

		public LogConfig GetLogConfig(BuildEnvironment environment)
		{
			return null;
		}
	}
}
