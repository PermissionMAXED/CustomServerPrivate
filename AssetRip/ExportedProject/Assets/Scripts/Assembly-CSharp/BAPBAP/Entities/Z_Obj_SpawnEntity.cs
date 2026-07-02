using System;
using System.Collections.Generic;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Z_Obj_SpawnEntity : Z_Obj
	{
		[Serializable]
		public class Config : Z_ObjConfiguration
		{
			[Serializable]
			public class EntityGroup
			{
				public GameObject[] entityPrefabs;
			}

			[Header("Custom Config")]
			public GameObject[] entityPrefabs;

			public EntityGroup[] entityGroups;

			[Tooltip("For each entity spawn, chance to try to spawn a group of entities instead")]
			[Range(0f, 1f)]
			public float groupSpawnChance;

			[Min(0f)]
			[Tooltip("How much distance to spread the entities in the group from the spawn position")]
			public float groupSpread;

			[Tooltip("Try to spawn an npc at this time interval")]
			[Min(0f)]
			public float spawnRate;

			[Tooltip("Once this time has been surpassed, stop spawning more entities")]
			[Min(0f)]
			public float maxSpawnDuration;

			[Tooltip("Range of npcs to spawn randomly inside the current zone")]
			[Header("Spawn Config")]
			public IntRange countRange;

			[Tooltip("The min distance from other spawned entities to allow spawning")]
			public float density;

			[Header("Other Config")]
			public float navCheckRadius;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public List<GameObject> spawnedObjs;

		[NonSerialized]
		public int spawnCount;

		[NonSerialized]
		public float densitySqrd;

		[NonSerialized]
		public float spawnTimer;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public int spawnCounter;

		[NonSerialized]
		public bool done;

		public override Z_ObjConfiguration dObjConfig => null;

		public Z_Obj_SpawnEntity(Config config)
		{
		}

		public void SetConfig(IntRange countRange, float density)
		{
		}

		public void SpawnAllEntities()
		{
		}

		public override void SvTick(float fixedDt)
		{
		}

		public bool TrySpawnEntity()
		{
			return false;
		}

		public void SpawnEntity(GameObject prefab, Vector3 spawnPos)
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
	}
}
