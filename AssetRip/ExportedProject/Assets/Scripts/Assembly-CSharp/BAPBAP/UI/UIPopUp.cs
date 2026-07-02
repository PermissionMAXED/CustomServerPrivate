using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIPopUp : MonoBehaviour
	{
		public enum PointType
		{
			Critical = 0,
			Negative = 1,
			Neutral = 2,
			Positive = 3,
			XP = 4,
			Gold = 5,
			White = 6,
			Mitigated = 7,
			LocalPlayerDamaged = 8
		}

		[Header("References")]
		[SerializeField]
		public Transform entryParent;

		[Header("UI Settings")]
		[NamedArray(typeof(PointType), 0)]
		[SerializeField]
		public Color[] typeColors;

		[SerializeField]
		public float criticalHitScale;

		[SerializeField]
		public float criticalStartingScaleAdd;

		[SerializeField]
		public float textScale;

		[SerializeField]
		public float goldScale;

		[SerializeField]
		[Header("Stack Points")]
		public bool stackSamePointType;

		[SerializeField]
		public float maxTimeToStack;

		[SerializeField]
		public float scaleIncreasePerStack;

		[SerializeField]
		public float scaleIncreasePerStackMax;

		[Header("Damage Points Scale Mult")]
		[SerializeField]
		public bool scaleByPointRange;

		[SerializeField]
		public int pointNormRange;

		[SerializeField]
		public RangeFloat scaleMultRange;

		[Header("Configuration")]
		[SerializeField]
		public UIPopUpEntry.Configuration popUpEntryConfig;

		[SerializeField]
		public UIPopUpEntry.Configuration popUpKillIconEntryConfig;

		[NonSerialized]
		public UIPopUpEntry.Pool _popUpEntryPool;

		[NonSerialized]
		public UIPopUpEntry.Pool _popUpKillIconEntryPool;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void SpawnPopUpPoints(int points, PointType pointType, Transform target = null, float duration = 1f)
		{
		}

		public void SpawnPopUpTextOnWorldPos(string text, PointType pointT, Vector3 targetPos, Transform target = null, float duration = 1f)
		{
		}

		public void SpawnPopUpGoldOnWorldPos(string text, Vector3 targetPos, Transform target = null, float duration = 1f)
		{
		}

		public void SpawnPopUpKillOnWorldPos(Vector3 targetPos, float duration = 1f)
		{
		}
	}
}
