using System;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "CharVoicelineGlobal", menuName = "BAPBAP/Configuration/CharVoicelineGlobal")]
	public class CharVoicelineGlobalConfig : ScriptableObject
	{
		[Serializable]
		public class CharNameMapping
		{
			public string Name;

			public int ID;
		}

		[SerializeField]
		public CharNameMapping[] _nameMapping;

		[SerializeField]
		public CharVoicelineConfig _kill;

		[SerializeField]
		public CharVoicelineConfig _ace;

		[SerializeField]
		public CharVoicelineConfig _damage;

		[SerializeField]
		public CharVoicelineConfig _death;

		[SerializeField]
		public CharVoicelineConfig _resurrected;

		[SerializeField]
		public CharVoicelineConfig _zone;

		[SerializeField]
		public CharVoicelineConfig _win;

		[SerializeField]
		public CharVoicelineConfig _pingAttack;

		[SerializeField]
		public CharVoicelineConfig _pingEnemySpotted;

		[SerializeField]
		public CharVoicelineConfig _pingHealing;

		[SerializeField]
		public CharVoicelineConfig _pingHelp;

		[SerializeField]
		public CharVoicelineConfig _pingOnMyWay;

		[SerializeField]
		public CharVoicelineConfig _pingRetreat;

		[SerializeField]
		public CharVoicelineConfig _pingStickTogether;

		[SerializeField]
		public CharVoicelineConfig _pingWait;

		[SerializeField]
		public CharVoicelineConfig _pingNeedGold;

		[SerializeField]
		public CharVoicelineConfig _select;

		[SerializeField]
		public CharVoicelineConfig _unlock;

		[SerializeField]
		public CharVoicelineConfig _mastery;

		[SerializeField]
		public CharVoicelineConfig _mvp;

		[SerializeField]
		public CharVoicelineConfig _legendaryItem;

		[SerializeField]
		public CharVoicelineConfig[] _configs;

		[SerializeField]
		public bool _logMissingVoicelines;

		[NonSerialized]
		public Dictionary<int, string> _nameLookup;

		[NonSerialized]
		public Dictionary<int, CharVoicelineConfig> _configLookup;

		public static CharVoicelineGlobalConfig _instance;

		public static CharVoicelineConfig Kill => null;

		public static CharVoicelineConfig Ace => null;

		public static CharVoicelineConfig Damage => null;

		public static CharVoicelineConfig Death => null;

		public static CharVoicelineConfig Resurrected => null;

		public static CharVoicelineConfig Zone => null;

		public static CharVoicelineConfig Win => null;

		public static CharVoicelineConfig PingAttack => null;

		public static CharVoicelineConfig PingEnemySpotted => null;

		public static CharVoicelineConfig PingHealing => null;

		public static CharVoicelineConfig PingHelp => null;

		public static CharVoicelineConfig PingOnMyWay => null;

		public static CharVoicelineConfig PingStickTogether => null;

		public static CharVoicelineConfig PingRetreat => null;

		public static CharVoicelineConfig PingWait => null;

		public static CharVoicelineConfig PingNeedGold => null;

		public static CharVoicelineConfig Select => null;

		public static CharVoicelineConfig Unlock => null;

		public static CharVoicelineConfig Mastery => null;

		public static CharVoicelineConfig MVP => null;

		public static CharVoicelineConfig LegendaryItem => null;

		public static bool LogMissingVoicelines => false;

		public static bool TryGetEvent(int charId, CharVoicelineConfig config, out EventDescription eventDescription)
		{
			eventDescription = default(EventDescription);
			return false;
		}

		public static bool TryGetConfig(int id, out CharVoicelineConfig config)
		{
			config = null;
			return false;
		}

		public void OnEnable()
		{
		}
	}
}
