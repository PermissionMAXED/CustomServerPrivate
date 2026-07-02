using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityBushInteractSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharBushInteract> components;

		public void Register(CharBushInteract charBushInteract)
		{
		}

		public void Unregister(CharBushInteract charBushInteract)
		{
		}

		public void Update()
		{
		}
	}
}
