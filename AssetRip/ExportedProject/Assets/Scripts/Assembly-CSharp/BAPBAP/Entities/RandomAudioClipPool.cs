using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	[Serializable]
	public class RandomAudioClipPool
	{
		public enum RandomType
		{
			Random = 0,
			RandomNoRepeats = 1
		}

		[Serializable]
		public class ClipData
		{
			public AudioClipData clipData;

			[Tooltip("After playing this audio clip, should try to not select it during a cooldown time?")]
			[Min(0f)]
			public bool doCooldown;

			[ConditionalHide("doCooldown", true)]
			[Min(0f)]
			public float cooldown;

			[NonSerialized]
			public float cooldownTime;
		}

		public RandomType randomType;

		public ClipData[] clips;
	}
}
