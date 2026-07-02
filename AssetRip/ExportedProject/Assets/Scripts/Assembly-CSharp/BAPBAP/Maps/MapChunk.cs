using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public struct MapChunk
	{
		public struct CeilingGroupData
		{
			public List<LevelRuntimeManager.CombineInstanceData> staticObjs;

			public List<GameObject> instantiatedObjs;

			public CeilingGroupData(bool ok)
			{
				staticObjs = null;
				instantiatedObjs = null;
			}
		}

		public bool initialized;

		public GameObject prebakedCollidersObj;

		public List<TiledColliderInstance> tiledColliders;

		public List<LevelRuntimeManager.CombineInstanceData> staticObjs;

		public List<GameObject> instantiatedObjs;

		public Dictionary<int, CeilingGroupData> ceilingGroups;

		public void Initialize(int capacity = 0)
		{
		}
	}
}
