using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class D_Obj_Bubble : D_Obj
	{
		[Serializable]
		public class Config : D_ObjConfiguration
		{
			[Header("Custom Config")]
			public float cellSize;

			public int maxSpawns;

			public float navCheckRadius;

			public float spawnTime;
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
		public List<GameObject> objects;

		[NonSerialized]
		public List<float> spawnTimers;

		public override D_ObjConfiguration dObjConfig => null;

		public D_Obj_Bubble(Dimension d, Config config)
			: base(null)
		{
		}

		public void SpawnObjects(int amount)
		{
		}

		public void TrySpawnObject()
		{
		}

		public Vector3 RandomPositionWithinRadius()
		{
			return default(Vector3);
		}

		public bool IsPositionValid(Vector3 position)
		{
			return false;
		}

		public override void SvOnObjectExit(GameObject g)
		{
		}

		public override void SvTick(float fixedDt)
		{
		}
	}
}
