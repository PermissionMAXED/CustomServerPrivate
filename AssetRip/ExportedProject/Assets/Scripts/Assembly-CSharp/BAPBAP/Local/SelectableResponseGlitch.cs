using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(menuName = "BAPBAP/Selectable/SelectableResponseGlitch")]
	public class SelectableResponseGlitch : SelectableResponse
	{
		public RenderObjectsToTextureFeature glitchFeature;

		public int frames;

		public override void OnSelect(ISelectable selectable)
		{
		}
	}
}
