using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIProgressBarElement : MonoBehaviour
	{
		[SerializeField]
		public bool doColorsByProgress;

		[SerializeField]
		public UIManager.InfoStatus[] colorsByProgressNorm;

		[SerializeField]
		[Header("Component References")]
		public Image progressFill;

		[Header("Fail Animation")]
		[SerializeField]
		public UIPosLerpFade failAnimation;

		[SerializeField]
		public UIAlphaFade failColorFade;

		[SerializeField]
		public AudioClipData failSfx;

		public void OnDisable()
		{
		}

		public void SetProgress(float normProgress)
		{
		}

		public void DoFailAnimation()
		{
		}
	}
}
