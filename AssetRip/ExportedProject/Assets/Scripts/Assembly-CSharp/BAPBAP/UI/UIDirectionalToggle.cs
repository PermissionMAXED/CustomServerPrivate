using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIDirectionalToggle : MonoBehaviour
	{
		[Tooltip("When ping points to a direction, toggle this image enabled/disabled")]
		[SerializeField]
		public Image pingIcon;

		[SerializeField]
		[Tooltip("When ping points to a direction, toggle this to be active/deactive")]
		public GameObject dirIcon;

		public void OnItemPingDirEnabled()
		{
		}

		public void OnItemPingDirDisabled()
		{
		}
	}
}
