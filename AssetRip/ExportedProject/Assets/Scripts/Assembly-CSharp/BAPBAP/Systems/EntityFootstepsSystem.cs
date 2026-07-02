using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityFootstepsSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharFootsteps> components;

		public void Register(CharFootsteps charFootsteps)
		{
		}

		public void Unregister(CharFootsteps charFootsteps)
		{
		}

		public void Update()
		{
		}
	}
}
