using System;
using System.Text.RegularExpressions;

namespace BAPBAP.Profanity
{
	public class ProfanityFilter
	{
		[Serializable]
		public class Configuration
		{
			public string[] censorCharSet;
		}

		[NonSerialized]
		public Configuration configuration;

		[NonSerialized]
		public Regex censorRegex;

		public ProfanityFilter(Configuration configuration, Regex censorRegex)
		{
		}

		public string TryCensorProfanity(string str)
		{
			return null;
		}

		public bool ContainsProfanity(string str)
		{
			return false;
		}

		public string GetCensorCharacters(string s)
		{
			return null;
		}
	}
}
