using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityHiddenSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharHidden> components;

		public void Register(CharHidden charHidden)
		{
		}

		public void Unregister(CharHidden charHidden)
		{
		}

		public void Update()
		{
		}
	}
}
