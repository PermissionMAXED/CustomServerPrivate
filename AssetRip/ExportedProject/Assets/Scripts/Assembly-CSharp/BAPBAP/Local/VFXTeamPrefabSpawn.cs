using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXTeamPrefabSpawn : MonoBehaviour
	{
		[NonSerialized]
		public int teamId;

		[Header("Vfx Prefabs")]
		[SerializeField]
		public GameObject allyVfxPrefab;

		[SerializeField]
		public GameObject enemyVfxPrefab;

		[NonSerialized]
		public GameObject spawnedAllyVfx;

		[NonSerialized]
		public GameObject spawnedEnemyVfx;

		public void OnStart(int _teamId)
		{
		}

		public void SpawnTeamBasedVfxPrefab()
		{
		}
	}
}
