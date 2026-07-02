using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIFishingMinigame : MonoBehaviour
	{
		[SerializeField]
		public UIManager.InfoStatus[] colorsByProgressNorm;

		[Header("References")]
		[SerializeField]
		public RectTransform areaBgTr;

		[SerializeField]
		public Image areaBgImage;

		[SerializeField]
		public RectTransform pivotDirectionTr;

		[SerializeField]
		public RectTransform validAreaDirectionTr;

		[SerializeField]
		public Image validAreaImage;

		[SerializeField]
		public RectTransform fishDirectionTr;

		[SerializeField]
		public RectTransform fishIcon;

		[SerializeField]
		public TransformScaleAnimation pullAnim;

		[SerializeField]
		public TransformScaleAnimation fishIconPullAnim;

		[SerializeField]
		public Transform fishIconImage;

		[Header("Settings")]
		[SerializeField]
		public Color areaNormalColor;

		[SerializeField]
		public Color areaInAreaColor;

		[SerializeField]
		public float radialImageQuadSize;

		public void Awake()
		{
		}

		public void SetPivotDirection(float worldYAngle)
		{
		}

		public void SetAreaDirection(float localAngle)
		{
		}

		public void SetInArea(bool isInArea)
		{
		}

		public void SetFishDirection(float localAngle)
		{
		}

		public void OnFishPull()
		{
		}

		public void SetFishScale(float ratio)
		{
		}

		public void SetAreaBgRadius(float radius)
		{
		}

		public void SetValidAreaRadius(float radius)
		{
		}

		public void SetAreaRadius(float radius, RectTransform areaRectTr, Material matInstance)
		{
		}
	}
}
