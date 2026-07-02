using System;
using BAPBAP.Entities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	[DisallowMultipleComponent]
	public class DimensionDetectCollider : NetworkBehaviour
	{
		[NonSerialized]
		public Action<EntityManager> onEntityEnter;

		[NonSerialized]
		public Action<EntityManager> onEntityExit;

		[NonSerialized]
		public Action<Dimensionable> onDimensionableEnter;

		[NonSerialized]
		public Action<Dimensionable> onDimensionableExit;

		public void OnTriggerEnter(Collider collider)
		{
		}

		public void OnTriggerExit(Collider collider)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
