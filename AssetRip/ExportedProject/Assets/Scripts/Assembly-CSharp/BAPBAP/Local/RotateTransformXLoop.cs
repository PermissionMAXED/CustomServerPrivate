using UnityEngine;

namespace BAPBAP.Local
{
	public class RotateTransformXLoop : MonoBehaviour
	{
		[SerializeField]
		public AnimationCurve rotationCurve;

		[SerializeField]
		public float duration;

		public void LateUpdate()
		{
		}
	}
}
