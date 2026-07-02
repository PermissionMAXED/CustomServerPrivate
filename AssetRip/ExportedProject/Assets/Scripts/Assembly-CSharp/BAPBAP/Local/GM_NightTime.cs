using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_NightTime : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public float fowRadiusMultiplier;
		}

		[NonSerialized]
		public Config config;

		public GM_NightTime(Config _config = null)
		{
		}

		public override void ClActivate()
		{
		}

		public override void ClDeactivate()
		{
		}
	}
}
