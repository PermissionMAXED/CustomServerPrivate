using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FMODManager : MonoBehaviour
	{
		[SerializeField]
		public EventReference _lobbyMusicEvent;

		[SerializeField]
		public EventReference _downedSnapshot;

		[NonSerialized]
		public readonly List<EventInstance> _instanceList;

		[NonSerialized]
		public readonly Dictionary<IntPtr, int> _uniqueLookup;

		[NonSerialized]
		public readonly Dictionary<int, EventInstance> _uniqueSet;

		[NonSerialized]
		public EventInstance _lobbyMusicInstance;

		[NonSerialized]
		public EventInstance _snapshotInstance;

		public EventReference DownedSnapshot => default(EventReference);

		public void Play(EventDescription @event, GameObject obj = null, bool attached = true, bool unique = false, bool @override = false)
		{
		}

		public void PlayLobbyMusic()
		{
		}

		public void StopLobbyMusic()
		{
		}

		public void SetSnapshot(EventReference eventReference)
		{
		}

		public void SetBusVolume(string name, float volume)
		{
		}

		public void Update()
		{
		}
	}
}
