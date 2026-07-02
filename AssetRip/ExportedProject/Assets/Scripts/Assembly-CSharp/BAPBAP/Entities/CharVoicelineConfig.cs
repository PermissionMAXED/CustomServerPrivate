using System;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "CharVoiceline", menuName = "BAPBAP/Configuration/CharVoiceline")]
	public class CharVoicelineConfig : ScriptableObject
	{
		[SerializeField]
		public string _event;

		[SerializeField]
		public CharVoicelineParameters _parameters;

		[SerializeField]
		public int _id;

		[NonSerialized]
		public Dictionary<string, EventDescription> _eventCache;

		[NonSerialized]
		public HashSet<string> _invalidCache;

		[NonSerialized]
		public EventDescription _invalidEvent;

		public int ID => 0;

		public CharVoicelineParameters Parameters => null;

		public void OnEnable()
		{
		}

		public bool TryGetEvent(string charName, out EventDescription @event)
		{
			@event = default(EventDescription);
			return false;
		}
	}
}
