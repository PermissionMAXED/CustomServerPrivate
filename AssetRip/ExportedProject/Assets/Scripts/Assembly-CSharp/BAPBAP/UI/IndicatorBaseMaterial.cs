using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class IndicatorBaseMaterial : MonoBehaviour
	{
		[SerializeField]
		[Header("Components")]
		public SpriteRenderer arrowRenderer;

		[SerializeField]
		public SpriteRenderer ringDiscRenderer;

		[SerializeField]
		public SpriteRenderer shadow;

		[SerializeField]
		public GameObject toggleObj;

		[Header("Settings")]
		[SerializeField]
		public Color selfColor;

		[SerializeField]
		public Color allyColor;

		[SerializeField]
		public Color enemyColor;

		[SerializeField]
		public float arrowAdditiveAlpha;

		[SerializeField]
		public float arrowOffset;

		[SerializeField]
		public float minShadowAlpha;

		[SerializeField]
		public float downedOpacity;

		[NonSerialized]
		public IShape ringDisc;

		[NonSerialized]
		public BaseIndicatorTarget target;

		[NonSerialized]
		public float originalShadowAlpha;

		[NonSerialized]
		public bool downed;

		public void Awake()
		{
		}

		public void SetDowned(bool isDowned)
		{
		}

		public void SetVisibility(bool isVisible)
		{
		}

		public void ToggleActive(bool isActive)
		{
		}

		public void UpdateRing(float ringRadius, BaseIndicatorTarget indicatorTarget)
		{
		}

		public void SetShadowAlpha(float alphaNorm)
		{
		}
	}
}
