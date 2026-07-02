using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityStatusEffectSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharStatusEffects> components;

		public void Register(CharStatusEffects charWorldPosition)
		{
		}

		public void Unregister(CharStatusEffects charWorldPosition)
		{
		}

		public void Update()
		{
		}
	}
}
