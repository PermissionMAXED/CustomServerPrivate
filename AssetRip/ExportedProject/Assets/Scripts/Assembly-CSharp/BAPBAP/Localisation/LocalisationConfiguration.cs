using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Localisation
{
	[CreateAssetMenu(fileName = "LocalisationConfiguration", menuName = "BAPBAP/Configuration/Localisation/Configuration")]
	public class LocalisationConfiguration : ScriptableObject
	{
		[Serializable]
		public class Localisation
		{
			public SystemLanguage language;

			public string languageName;

			public Sprite languageIcon;

			public TextAsset phraseData;
		}

		[Serializable]
		public class DebugConfig
		{
			public bool overrideSystemLanguage;

			public SystemLanguage languageOverride;

			public bool outputLocalisation;
		}

		[SerializeField]
		public TextAsset keyData;

		[SerializeField]
		public Localisation defaultLocalisation;

		[SerializeField]
		public Localisation[] localisations;

		[SerializeField]
		public DebugConfig debug;

		[SerializeField]
		public Translator.Configuration translation;

		[NonSerialized]
		public Translator defaultTranslator;

		[NonSerialized]
		public Dictionary<SystemLanguage, Translator> localisationLookup;

		public Translator DefaultTranslator => null;

		public void OnEnable()
		{
		}

		public Translator GetTranslator(SystemLanguage language)
		{
			return null;
		}

		public Translator GetSystemTranslator()
		{
			return null;
		}

		public Translator GetSavedTranslator()
		{
			return null;
		}

		public Translator LoadFromConfig(Localisation configuration)
		{
			return null;
		}

		public int GetLocalisationIdFromSystemLanguage(SystemLanguage systemLanguage)
		{
			return 0;
		}

		public SystemLanguage GetSystemLanguageFromLocalisationId(int localisationIndex)
		{
			return default(SystemLanguage);
		}
	}
}
