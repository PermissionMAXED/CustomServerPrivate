using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharFogOfWar : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void AssignFoWRendererToTarget()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
