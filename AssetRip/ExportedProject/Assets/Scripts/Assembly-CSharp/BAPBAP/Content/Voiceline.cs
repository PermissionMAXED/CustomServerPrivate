using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class Voiceline : Emote
	{
		[Tooltip("Audio data for multiple versions of this voice line, to have different takes or volumes")]
		public AudioClipData[] voicelinesAudioData;

		public GameObject visualizerPrefab;

		public AudioClipData GetVoicelineData(int voicelineId = 0)
		{
			return null;
		}

		public override GameObject GetSpawnableVisualizer()
		{
			return null;
		}

		public override void InitializeSpawnedVisualizer(GameObject spawnedVisInstance)
		{
		}

		public override void InitializeUIDisplay(Image displayImage, bool allowVisualizeSpawn = true)
		{
		}
	}
}
