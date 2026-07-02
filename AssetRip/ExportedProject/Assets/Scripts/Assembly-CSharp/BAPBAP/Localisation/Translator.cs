using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Localisation
{
	public class Translator
	{
		[Serializable]
		public class Configuration
		{
			public bool keyForceUppercase;

			public string keyFailureString;

			public string ignoreTranslationString;
		}

		[NonSerialized]
		public Configuration configuration;

		[NonSerialized]
		public SystemLanguage language;

		[NonSerialized]
		public Dictionary<string, string> phraseLookup;

		public SystemLanguage Language => default(SystemLanguage);

		public Translator(Configuration configuration, SystemLanguage language, Dictionary<string, string> phraseLookup)
		{
		}

		public string LocalisePhrase(string key)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
