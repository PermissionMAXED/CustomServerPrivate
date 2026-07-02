using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Entities.HideArea;
using UnityEngine;

namespace BAPBAP.Local
{
	public class BushManager : MonoBehaviour
	{
		[NonSerialized]
		public Dictionary<int, List<EntityManager>> bushIdToChars;

		[NonSerialized]
		public Dictionary<int, HideArea> bushIdToBush;

		public void AddCharToBush(int bushId, EntityManager entityManager)
		{
		}

		public void RemoveCharFromBush(int bushId, EntityManager entityManager)
		{
		}

		public List<EntityManager> GetCharsFromBushId(int bushId)
		{
			return null;
		}

		public void UpdateCharsAndBush(int bushId)
		{
		}

		public bool IsCharVisibleInBush(int bushId, int localCharTeam)
		{
			return false;
		}

		public void UpdateAllCharactersAndBushes()
		{
		}

		public bool IsAllyInsideBush(int bushId)
		{
			return false;
		}

		public void RemoveCharFromAllBushesAndUpdate(EntityManager entityManager)
		{
		}

		public void LogAllCharsInAllBushes()
		{
		}

		public HideArea GetBushById(int bushId)
		{
			return null;
		}

		public void RegisterBush(int bushId, HideArea hideArea)
		{
		}

		public void UnregisterBush(int bushId)
		{
		}

		public void LogAllBushes()
		{
		}
	}
}
