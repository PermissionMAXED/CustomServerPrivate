using UnityEngine;

namespace BAPBAP.UI
{
	public class UIDirectionalIconToggle : MonoBehaviour
	{
		[Tooltip("Sets this icon rect parented to the attached transform, and keeps it oriented straight")]
		[SerializeField]
		public RectTransform iconRect;

		[Tooltip("Toggles this transform active/deactive")]
		[SerializeField]
		public Transform followDirTransform;

		public void LateUpdate()
		{
		}

		public void OnItemPingDirEnabled()
		{
		}

		public void OnItemPingDirDisabled()
		{
		}
	}
}
