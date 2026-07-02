using UnityEngine;

namespace BAPBAP.Pooling
{
	public class NetworkPrefabLibrary : ScriptableObject
	{
		public GameObject[] InstantiatedPrefabs;

		public NetworkPrefabPool.Config[] PooledPrefabs;
	}
}
