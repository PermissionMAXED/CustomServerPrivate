using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityInterpolatorSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharInterpolator> components;

		public void Register(CharInterpolator charInterpolator)
		{
		}

		public void Unregister(CharInterpolator charInterpolator)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
