using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class D_Obj_Oxygen : D_Obj
	{
		[Serializable]
		public class Config : D_ObjConfiguration
		{
			[Header("Custom Config")]
			public float cellSize;

			public int maxAmount;

			public float spawnEdgeAdjustMaxDistance;

			public float navCheckRadius;

			public float edgeDistance;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public List<GameObject> objects;

		[NonSerialized]
		public List<Vector3> spawnPoints;

		[NonSerialized]
		public float startRadius;

		public override D_ObjConfiguration dObjConfig => null;

		public D_Obj_Oxygen(Dimension d, Config config)
			: base(null)
		{
		}

		public Bounds GetNavMeshBounds()
		{
			return default(Bounds);
		}

		public List<Vector3> GetSpawnPointsOnNavMesh()
		{
			return null;
		}

		public void TrySpawnObjects()
		{
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
