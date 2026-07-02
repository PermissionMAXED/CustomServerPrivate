using System;
using System.Collections.Generic;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class EntityTriggerboxListener : MonoBehaviour, IEntityTriggerboxListener
	{
		[Serializable]
		public class CompoundEntry
		{
			public EntityManager entityManager;

			public int count;

			public CompoundEntry(EntityManager entityManager, int count)
			{
			}
		}

		[SerializeField]
		public bool isCompoundCollider;

		[NonSerialized]
		public List<CompoundEntry> entityCompoundColCount;

		[NonSerialized]
		public List<EntityManager> trackedEntities;

		[NonSerialized]
		public bool isEnabled;

		public Action<EntityManager> onEnterAction;

		public Action<EntityManager> onExitAction;

		public bool IsCompoundCollider => false;

		public List<EntityManager> TrackedEntities => null;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void OnTriggerEnter(Collider collider)
		{
		}

		public void OnTriggerExit(Collider collider)
		{
		}

		public void TriggerEnter(Collider collider)
		{
		}

		public void TriggerExit(Collider collider)
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		public void EntityDisable(EntityManager entity)
		{
		}
	}
}
