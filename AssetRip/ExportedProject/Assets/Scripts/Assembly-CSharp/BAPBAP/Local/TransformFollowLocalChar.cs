using UnityEngine;

namespace BAPBAP.Local
{
	public class TransformFollowLocalChar : MonoBehaviour
	{
		public float yOffset;

		[Header("References")]
		[SerializeField]
		public Transform posTransform;

		public void LateUpdate()
		{
		}
	}
}
