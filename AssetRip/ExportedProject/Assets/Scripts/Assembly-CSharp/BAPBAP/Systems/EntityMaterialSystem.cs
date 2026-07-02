using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityMaterialSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharMaterial> components;

		public void Register(CharMaterial charMaterial)
		{
		}

		public void Unregister(CharMaterial charMaterial)
		{
		}

		public void Update()
		{
		}
	}
}
