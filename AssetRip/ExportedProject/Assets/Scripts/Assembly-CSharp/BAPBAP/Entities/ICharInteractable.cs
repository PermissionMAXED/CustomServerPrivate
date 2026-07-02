using UnityEngine;

namespace BAPBAP.Entities
{
	public interface ICharInteractable
	{
		Transform GetTransform();

		GameObject GetGameObject();

		EntityManager GetEntityManager();

		int GetPriority()
		{
			return 0;
		}

		bool IsSelectable(EntityManager entity)
		{
			return false;
		}

		bool IsCompoundCollider()
		{
			return false;
		}

		bool InteruptableOnDamaged()
		{
			return false;
		}

		bool InterruptableOnTriggerLocked()
		{
			return false;
		}

		bool InterruptableOnCasting()
		{
			return false;
		}

		bool IsEntityLocked()
		{
			return false;
		}

		void OnInteractableTriggerEnter(EntityManager entity);

		void OnStartHovering(EntityManager entity);

		void OnEnter(EntityManager entity);

		void OnExit(EntityManager entity);

		void OnInteract(EntityManager entity);

		void OnForceUpdate(EntityManager entity)
		{
		}

		void OnLocalAuthPlayerChanged(EntityManager entity)
		{
		}
	}
}
