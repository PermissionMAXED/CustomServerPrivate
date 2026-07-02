using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAlphaLoopTime : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public CanvasGroup canvasGroup;

		[Header("Settings")]
		[SerializeField]
		public AnimationCurve alphaCurve;

		[SerializeField]
		public float loopDuration;

		public void Update()
		{
		}
	}
}
