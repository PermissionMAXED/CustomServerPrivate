using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIHpBarHp : MonoBehaviour
	{
		[NonSerialized]
		public UIHpBarShader uiHpBarsShader;

		[Header("Configs")]
		[Tooltip("How long should the lerping last? (Includes delay time)")]
		[SerializeField]
		public float dmgLerpDampDuration;

		[Tooltip("The easing curve used to lerp the dmg bar, includes delay + damping")]
		[SerializeField]
		public AnimationCurve dmgLerpDampCurve;

		[NonSerialized]
		public float dmgLerpPercent;

		[NonSerialized]
		public float dmgLerpStartPercent;

		[NonSerialized]
		public float dmgLerpDampTimeElapsed;

		[NonSerialized]
		public bool isDmgLerping;

		[NonSerialized]
		public float lifePercentCache;

		public void Awake()
		{
		}

		public void OnHpShieldChanged(int hp, int maxHp, int shield)
		{
		}

		public void OnDmg(float oldLifePercent)
		{
		}

		public void ManagedLateUpdate()
		{
		}
	}
}
