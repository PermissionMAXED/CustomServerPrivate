using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public interface IEntityDataProperty
	{
		string PropertyName()
		{
			return null;
		}

		MapEntityData.Property.Field[] GetPropertyFields();

		void CopyProperties(IEntityDataProperty source);

		void AssignSpawnedReferences(Dictionary<int, GameObject> spawnedEntitiesByInstanceId)
		{
		}
	}
}
