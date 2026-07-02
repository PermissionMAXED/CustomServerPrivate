using System;

namespace BAPBAP.Debugging
{
	public static class BapLog
	{
		public enum BapLogLevel
		{
			Trace = 0,
			Debug = 1,
			Info = 2,
			Warning = 3,
			Error = 4
		}

		public static BapLogLevel _currentLogLevel;

		public static void SetSettings(LogConfig config)
		{
		}

		public static void SetLogLevel(BapLogLevel logLevel)
		{
		}

		public static void Trace(string msg)
		{
		}

		public static void Debug(string msg)
		{
		}

		public static void Info(string msg)
		{
		}

		public static void Warning(string msg)
		{
		}

		public static void Error(string msg)
		{
		}

		public static void Exception(Exception e)
		{
		}
	}
}
