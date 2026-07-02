using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI
{
	public class LayoutFitParentPercentage : UIBehaviour
	{
		public enum Axis
		{
			Horizontal = 0,
			Vertical = 1,
			Both = 2
		}

		[Header("References")]
		[SerializeField]
		public RectTransform parentRect;

		[SerializeField]
		public RectTransform fillRect;

		[Header("Settings")]
		[SerializeField]
		public Axis expandAxis;

		[ConditionalEnumHide("expandAxis", 0, 2, true)]
		[SerializeField]
		public float hPercentageNorm;

		[ConditionalEnumHide("expandAxis", 1, 2, true)]
		[SerializeField]
		public float vPercentageNorm;

		public float horizontalPercentageNorm
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float verticalPercentageNorm
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override void OnRectTransformDimensionsChange()
		{
		}

		public void UpdateFillRect()
		{
		}

		public void SetHorizontalPercentage()
		{
		}

		public void SetVerticalPercentage()
		{
		}

		public void SetBothAxisPercentage()
		{
		}
	}
}
