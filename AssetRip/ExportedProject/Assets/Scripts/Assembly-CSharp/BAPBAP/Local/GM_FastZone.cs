using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_FastZone : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public float zoneDurationMult;
		}

		[NonSerialized]
		public Config config;

		public GM_FastZone(Config _config = null)
		{
		}

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}
	}
}
