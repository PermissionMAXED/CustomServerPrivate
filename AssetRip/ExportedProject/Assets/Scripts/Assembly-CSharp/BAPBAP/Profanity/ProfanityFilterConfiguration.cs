using System;
using UnityEngine;

namespace BAPBAP.Profanity
{
	[CreateAssetMenu(fileName = "ProfanityFilterConfiguration", menuName = "BAPBAP/Configuration/Profanity/ProfanityFilterConfiguration")]
	public class ProfanityFilterConfiguration : ScriptableObject
	{
		[Serializable]
		public class Configuration
		{
			public TextAsset json;
		}

		[Serializable]
		public class ProfanityFilterData
		{
			public string[] allowedWords;

			public string[] censorWords;
		}

		[Serializable]
		public class SerialisationConfig
		{
			public string keyPhraseDeliminator;
		}

		[Serializable]
		public class DebugConfig
		{
			public bool outputProfanityFilter;
		}

		[SerializeField]
		public Configuration c;

		[SerializeField]
		public SerialisationConfig serialisation;

		[SerializeField]
		public ProfanityFilter profanityFilter;

		[SerializeField]
		public DebugConfig debug;

		[SerializeField]
		public ProfanityFilter.Configuration configuration;

		public ProfanityFilter GetProfanityFilter()
		{
			return null;
		}

		public ProfanityFilter LoadFromConfig(Configuration config)
		{
			return null;
		}
	}
}
