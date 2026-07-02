using System;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemObjectAnim : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public Transform itemTransform;

		[SerializeField]
		public Transform itemRotationPiv;

		[SerializeField]
		public GameObject itemEnable;

		[Header("Drop Anim Settings")]
		[SerializeField]
		public AnimationCurve dropHeightCurve;

		[SerializeField]
		public float heightMultiplier;

		[SerializeField]
		public float rotationAmount;

		[SerializeField]
		public float animDuration;

		[NonSerialized]
		public float animTimer;

		[NonSerialized]
		public Vector3 startingLerpPos;

		[NonSerialized]
		public Vector3 direction;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void Initialize(Vector3 _startingLerpPos)
		{
		}

		public void EndAnimation()
		{
		}

		public void Update()
		{
		}

		public void Animate(float f)
		{
		}
	}
}
