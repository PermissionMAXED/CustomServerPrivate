using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	public class InteractableCollider : MonoBehaviour, ICharInteractable
	{
		public delegate int IntAction();

		[Header("References")]
		[SerializeField]
		public AudioSource castStartSfx;

		[SerializeField]
		public ParticleSystem progressVfx;

		[SerializeField]
		public AudioSource progressSfx;

		[SerializeField]
		public GameObject activeVfx;

		[SerializeField]
		public GameObject meshObj;

		[Header("Settings")]
		[SerializeField]
		public bool isCompoundCollider;

		[FormerlySerializedAs("isInteruptableOnRecentlyDamaged")]
		[SerializeField]
		public bool interuptableOnRecentlyDamaged;

		[SerializeField]
		public bool interruptableOnTriggerLocked;

		[NonSerialized]
		public Action<EntityManager, InteractableCollider> onEnter;

		[NonSerialized]
		public Action<EntityManager, InteractableCollider> onExit;

		[NonSerialized]
		public Action<EntityManager, InteractableCollider> onInteract;

		[NonSerialized]
		public Action<EntityManager, InteractableCollider> onForceUpdate;

		[NonSerialized]
		public Action<EntityManager, InteractableCollider> onLocalAuthPlayerChanged;

		[NonSerialized]
		public IntAction getInteractablePriority;

		[NonSerialized]
		public EntityManager entityManager;

		public void Initialize(Action<EntityManager, InteractableCollider> onEnter, Action<EntityManager, InteractableCollider> onExit, Action<EntityManager, InteractableCollider> onInteract, Action<EntityManager, InteractableCollider> onForceUpdate, Action<EntityManager, InteractableCollider> onLocalAuthPlayerChanged, IntAction getInteractablePriority, EntityManager entityManager)
		{
		}

		public void OnInteractableTriggerEnter(EntityManager entity)
		{
		}

		public void OnStartHovering(EntityManager entity)
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		public void OnInteract(EntityManager entity)
		{
		}

		public void OnForceUpdate(EntityManager entity)
		{
		}

		public void OnLocalAuthPlayerChanged(EntityManager entity)
		{
		}

		public int GetPriority()
		{
			return 0;
		}

		public bool IsSelectable(EntityManager entity)
		{
			return false;
		}

		public bool IsCompoundCollider()
		{
			return false;
		}

		public bool InteruptableOnDamaged()
		{
			return false;
		}

		public bool InterruptableOnTriggerLocked()
		{
			return false;
		}

		public EntityManager GetEntityManager()
		{
			return null;
		}

		public Transform GetTransform()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}
	}
}
