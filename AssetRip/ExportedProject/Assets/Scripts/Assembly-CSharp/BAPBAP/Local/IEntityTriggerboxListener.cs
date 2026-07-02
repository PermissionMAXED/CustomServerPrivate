using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public interface IEntityTriggerboxListener
	{
		void TriggerEnter(Collider collider)
		{
		}

		void TriggerExit(Collider collider)
		{
		}

		void OnEnter(EntityManager entity);

		void OnExit(EntityManager entity);

		void EntityDisable(EntityManager entity)
		{
		}
	}
}
