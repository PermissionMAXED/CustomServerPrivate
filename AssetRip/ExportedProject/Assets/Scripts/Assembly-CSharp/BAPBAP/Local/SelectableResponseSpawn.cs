using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(menuName = "BAPBAP/Selectable/SelectableResponseSpawn")]
	public class SelectableResponseSpawn : SelectableResponse
	{
		public GameObject prefab;

		public bool onSelect;

		public bool onHover;

		public Vector3 offsetMin;

		public Vector3 offsetMax;

		public Vector3 scaleMin;

		public Vector3 scaleMax;

		public override void OnSelect(ISelectable selectable)
		{
		}

		public override void OnHoverEnter(ISelectable selectable)
		{
		}

		public void Spawn(ISelectable selectable)
		{
		}
	}
}
