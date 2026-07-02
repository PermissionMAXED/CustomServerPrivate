using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace BAPBAP.Debugging
{
	[Serializable]
	public class LogConfig
	{
		public BapLog.BapLogLevel MinimumLogLevel;

		public SerializedDictionary<LogType, StackTraceLogType> LogTypeStackTraceMapping;
	}
}
