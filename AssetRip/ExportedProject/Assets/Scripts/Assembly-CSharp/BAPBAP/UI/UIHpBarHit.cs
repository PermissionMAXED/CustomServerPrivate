using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIHpBarHit : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public Image healthBlinkBar;

		[SerializeField]
		public CanvasGroup healthBlink;

		[SerializeField]
		public Image dmgHitImage;

		[SerializeField]
		public CanvasGroup dmgHitAlpha;

		[SerializeField]
		public RectTransform dmgHitTransform;

		[SerializeField]
		public float hitAnimHeightMultiplier;

		[SerializeField]
		public float animSpeed;

		[NonSerialized]
		public float hitTimer;

		[NonSerialized]
		public bool isCritDmgHit;

		[NonSerialized]
		public float damageFactor;

		[NonSerialized]
		public float hpPosFactor;

		[NonSerialized]
		public RectTransform barRoot;

		[NonSerialized]
		public Color criticalDamageColor;

		public void Awake()
		{
		}

		public void Reset()
		{
		}

		public void DoHitAnimation(float _hpPosFactor, float _damageFactor, bool isCriticalDamage)
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void UpdateHitAnimation()
		{
		}
	}
}
