using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityWorldPositionSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharWorldPosition> components;

		public void Register(CharWorldPosition charWorldPosition)
		{
		}

		public void Unregister(CharWorldPosition charWorldPosition)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
