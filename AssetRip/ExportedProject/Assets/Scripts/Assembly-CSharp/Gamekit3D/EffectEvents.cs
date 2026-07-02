using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
	public class EffectEvents : MonoBehaviour
	{
		[Serializable]
		public class EventData
		{
			[Serializable]
			public class EventTarget
			{
				public GameObject gameObject;

				public bool state;

				[HideInInspector]
				public ParticleSystem particlesystem;
			}

			public string eventName;

			public EventTarget[] targets;
		}

		public EventData[] events;

		[NonSerialized]
		public Dictionary<int, EventData> m_EventLookup;

		[NonSerialized]
		public Animator m_Animator;

		public void Start()
		{
		}

		public void PlayEvent(string eventName, bool inverted = false)
		{
		}
	}
}
