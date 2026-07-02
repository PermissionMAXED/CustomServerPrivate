using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpawnOnDestroy : NetworkBehaviour
	{
		[Header("Prefab References")]
		[SerializeField]
		public GameObject obj;

		[NonSerialized]
		public bool doSpawn;

		public void OnDestroy()
		{
		}

		[Server]
		public void SpawnObj()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
