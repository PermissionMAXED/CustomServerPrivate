using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.AssetContainer
{
	public abstract class AssetContainer<T> : ScriptableObject where T : Object
	{
		public Owner owner;

		[SerializeField]
		public List<T> assets;

		public void SetOwner(Owner owner)
		{
		}

		public void OnEnable()
		{
		}

		public abstract T OptimizeAsset(T asset);

		public abstract bool ValidateAsset(T asset);

		public bool Contains(T asset, Owner owner)
		{
			return false;
		}

		public bool Contains(T asset)
		{
			return false;
		}

		public T AddAsset(T asset)
		{
			return null;
		}

		public void SaveAndImport()
		{
		}

		public void RemoveAsset(T asset)
		{
		}

		public void RemoveAllAssets()
		{
		}

		public virtual string GetUniqueAssetName(List<T> assets, string name)
		{
			return null;
		}

		public AssetContainer()
		{
		}
	}
}
