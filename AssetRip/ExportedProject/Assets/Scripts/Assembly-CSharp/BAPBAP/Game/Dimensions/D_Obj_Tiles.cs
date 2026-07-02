using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class D_Obj_Tiles : D_Obj
	{
		[Serializable]
		public class Config : D_ObjConfiguration
		{
			[Header("Custom Config")]
			public GameObject[] tileObjs;

			public float cellSize;

			public int maxSpawns;

			public float navCheckRadius;

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
		public List<GameObject> objects;

		[NonSerialized]
		public List<Tile> tiles;

		[NonSerialized]
		public List<float> spawnTimers;

		[NonSerialized]
		public float timer;

		public override D_ObjConfiguration dObjConfig => null;

		public D_Obj_Tiles(Dimension d, Config config)
			: base(null)
		{
		}

		public void SpawnObjects(int amount)
		{
		}

		public void TrySpawnObject(bool connectAfter = true)
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

		public void ConnectLineRenderers()
		{
		}

		public void ConnectToNearestTiles(Tile tile)
		{
		}

		public List<Tile> FindNearestTiles(Tile tile)
		{
			return null;
		}
	}
}
