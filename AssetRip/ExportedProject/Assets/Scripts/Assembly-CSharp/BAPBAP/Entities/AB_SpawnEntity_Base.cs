using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_SpawnEntity_Base : AB_Use_Base
	{
		[Serializable]
		public new class Config : AB_Use_Base.Config
		{
			[Header("Entity Config")]
			public GameObject entityPrefab;
		}

		[NonSerialized]
		public new Config config;

		public AB_SpawnEntity_Base(Config config)
			: base(null)
		{
		}

		public override void DoUse()
		{
		}
	}
}
