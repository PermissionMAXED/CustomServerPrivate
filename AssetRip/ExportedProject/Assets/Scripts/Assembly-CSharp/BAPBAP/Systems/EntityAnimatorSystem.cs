using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityAnimatorSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharAnimator> components;

		public void Register(CharAnimator charAnim)
		{
		}

		public void Unregister(CharAnimator charAnim)
		{
		}

		public void Update()
		{
		}
	}
}
