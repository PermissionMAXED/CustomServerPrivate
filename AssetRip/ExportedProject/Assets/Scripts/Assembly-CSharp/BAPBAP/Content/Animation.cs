using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class Animation : Emote
	{
		[Header("Anim Config")]
		public AnimationClip animationClip;

		public GameObject fxPrefab;

		[Header("Settings")]
		public int charId;

		public override GameObject GetSpawnableVisualizer()
		{
			return null;
		}

		public override void InitializeSpawnedVisualizer(GameObject spawnedVisInstance)
		{
		}

		public float GetAnimDuration()
		{
			return 0f;
		}

		public bool GetIsAnimLooping()
		{
			return false;
		}

		public override void InitializeUIDisplay(Image displayImage, bool allowVisualizeSpawn = true)
		{
		}

		public override bool Is3DVisualizer()
		{
			return false;
		}

		public override ContentVisualizer3D.VisualizerSettings Get3DVisualizerSettings()
		{
			return null;
		}

		public override bool IsContentEquipable()
		{
			return false;
		}
	}
}
