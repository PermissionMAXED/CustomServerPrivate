using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPlayOnDestroy : MonoBehaviour
	{
		[NonSerialized]
		public AudioManager audioManager;

		[SerializeField]
		public AudioClipData sfxDestroy;

		public void Awake()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
