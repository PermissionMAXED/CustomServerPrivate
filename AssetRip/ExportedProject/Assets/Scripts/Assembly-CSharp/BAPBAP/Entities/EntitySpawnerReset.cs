using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntitySpawnerReset : NetworkBehaviour
	{
		[NonSerialized]
		public EntityBehaviour _entityBehav;

		[SerializeField]
		public bool forceOnDestroy;

		[NonSerialized]
		public EntitySpawner entitySpawner;

		[NonSerialized]
		public bool respawnAble;

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void DoDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
