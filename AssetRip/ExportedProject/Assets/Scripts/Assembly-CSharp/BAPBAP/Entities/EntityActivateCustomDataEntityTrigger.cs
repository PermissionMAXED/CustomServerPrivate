using System.Collections.Generic;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(IEntityDataProperty))]
	public class EntityActivateCustomDataEntityTrigger : EntityActivateBase, IEntityDataProperty
	{
		[SerializeField]
		public EntityActivateBase[] entityActivateReferences;

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

		public override bool Weaved()
		{
			return false;
		}
	}
}
