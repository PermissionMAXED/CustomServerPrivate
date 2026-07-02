using UnityEngine;

namespace BAPBAP.Local
{
	public class TranslateTransformYLoop : MonoBehaviour
	{
		[SerializeField]
		public AnimationCurve posYCurve;

		[SerializeField]
		public float duration;

		public void LateUpdate()
		{
		}
	}
}
