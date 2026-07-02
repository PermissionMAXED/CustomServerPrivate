using System;
using BAPBAP.Items;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharItemPickupAnim : MonoBehaviour
	{
		[Header("General Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public Vector3 worldSpaceOffset;

		[Header("Animation Settings")]
		[SerializeField]
		public ItemObjectVisualizer itemVisualizerAnimPrefab;

		[SerializeField]
		[Header("Animation Settings")]
		public AnimationCurve heightCurve;

		[SerializeField]
		public AnimationCurve moveLerpCurve;

		[SerializeField]
		public AnimationCurve scaleHeightCurve;

		[SerializeField]
		public AnimationCurve scaleWidthCurve;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public int currentItemId;

		[NonSerialized]
		public ItemObjectVisualizer itemVisualizer;

		[NonSerialized]
		public Transform itemHolderTransform;

		[NonSerialized]
		public Transform charAnimTransform;

		public void Awake()
		{
		}

		public void StartItemAnim(Transform itemTransform, int itemId, int amount = 1)
		{
		}

		public void OnItemDropped(int itemId)
		{
		}

		public void DeactivateItemHolder()
		{
		}

		public void LateUpdate()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
