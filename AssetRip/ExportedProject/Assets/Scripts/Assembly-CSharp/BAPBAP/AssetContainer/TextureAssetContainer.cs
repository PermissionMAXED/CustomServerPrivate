using UnityEngine;

namespace BAPBAP.AssetContainer
{
	public class TextureAssetContainer : AssetContainer<Texture2D>
	{
		public override Texture2D OptimizeAsset(Texture2D asset)
		{
			return null;
		}

		public override bool ValidateAsset(Texture2D asset)
		{
			return false;
		}
	}
}
