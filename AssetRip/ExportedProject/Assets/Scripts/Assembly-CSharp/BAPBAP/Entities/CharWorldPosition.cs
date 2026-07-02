using System;
using BAPBAP.Systems;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharWorldPosition : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SystemManager systemManager;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void ManagedLateUpdate()
		{
		}
	}
}
