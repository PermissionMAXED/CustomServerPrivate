using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class D_Obj_Riptide : D_Obj
	{
		[Serializable]
		public class Config : D_ObjConfiguration
		{
			[Header("Custom Config")]
			public float cellSize;

			public int maxSpawns;

			public float spawnTime;

			public float trySpawnTimer;

			public int trySpawnAmount;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float densitySqrd;

		[NonSerialized]
		public float startRadius;

		[NonSerialized]
		public int startAmount;

		[NonSerialized]
		public List<RiptideHolder> objects;

		[NonSerialized]
		public List<float> spawnTimers;

		[NonSerialized]
		public float timer;

		public override D_ObjConfiguration dObjConfig => null;

		public D_Obj_Riptide(Dimension d, Config config)
			: base(null)
		{
		}

		public void SpawnObjects(int amount)
		{
		}

		public void TrySpawnMaxObjects()
		{
		}

		public void TrySpawnObject()
		{
		}

		public override void SvTick(float fixedDt)
		{
		}

		public void DestroyRiptide(RiptideHolder riptide)
		{
		}
	}
}
