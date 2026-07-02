using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_SpawnEntityOnPos_Base : AB_UseOnPosition_Base
	{
		[Serializable]
		public new class Config : AB_UseOnPosition_Base.Config
		{
			[Header("Entity Config")]
			public GameObject entityPrefab;
		}

		[NonSerialized]
		public new Config config;

		public AB_SpawnEntityOnPos_Base(Config config)
			: base(null)
		{
		}

		public override void DoUse(Vector3 spawnPos)
		{
		}
	}
}
