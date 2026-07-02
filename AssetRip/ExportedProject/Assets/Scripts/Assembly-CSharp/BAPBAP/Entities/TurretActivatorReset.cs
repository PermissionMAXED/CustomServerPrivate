using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TurretActivatorReset : NetworkBehaviour
	{
		[NonSerialized]
		public TurretActivator activator;

		[SerializeField]
		public SpawnOnDestroy spawner;

		public void SetActivator(TurretActivator _activator)
		{
		}

		public void OnDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
