using System.Collections.Generic;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityDataBehaviourTrigger : EntityActivateBase, IEntityDataProperty
	{
		[Tooltip("If any of the entities are an interactable station, should it also call OnCastingCompleted on it?")]
		[SerializeField]
		public bool triggerInteractableStations;

		[ExHeader("\ud83d\udee0 [PROPERTIES] \ud83d\udee0", 0f, 1f, 1f)]
		[ObjectPicker(typeof(EntityBehaviour))]
		[SerializeField]
		public EntityBehaviour[] entityBehavReferences;

		[ServerCallback]
		public override void Activate()
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void AssignSpawnedReferences(Dictionary<int, GameObject> spawnedEntitiesByInstanceId)
		{
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public void OnDrawGizmos()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
