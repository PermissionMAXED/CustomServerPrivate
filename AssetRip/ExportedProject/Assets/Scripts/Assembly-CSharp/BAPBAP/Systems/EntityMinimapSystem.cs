using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityMinimapSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharMinimap> components;

		public void Register(CharMinimap charMinimap)
		{
		}

		public void Unregister(CharMinimap charMinimap)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
