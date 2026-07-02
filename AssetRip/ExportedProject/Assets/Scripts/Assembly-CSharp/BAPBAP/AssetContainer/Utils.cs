using UnityEngine;

namespace BAPBAP.AssetContainer
{
	public static class Utils
	{
		static Utils()
		{
		}

		public static Owner GetOwner(GameObject gameObject)
		{
			return null;
		}

		public static AssetContainer<T> GetContainer<T>(T @object, Owner owner, string overridePath = null) where T : Object
		{
			return null;
		}

		public static AssetContainer<T> CreateNewContainer<T>(string containerPath, Owner owner) where T : Object
		{
			return null;
		}
	}
}
