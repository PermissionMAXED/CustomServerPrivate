using System;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.Game.Dimensions
{
	public class DimensionableObject : Dimensionable
	{
		[Serializable]
		public new class DimensionInfo : Dimensionable.DimensionInfo
		{
			[Space(5f)]
			public GameObject sourceInstance;

			public GameObject swapPrefab;

			public Transform swapInstanceParent;

			[NonSerialized]
			public GameObject spawnedInstance;

			[NonSerialized]
			public int originalInstanceLayer;

			public UnityEvent OnEnter;

			public UnityEvent OnExit;

			[ExHeader("Server", 1f, 1f, 0f)]
			public GameObject hitboxReplacement;

			public GameObject originalHitbox;
		}

		[SerializeField]
		public DimensionInfo[] dimensionInfo;

		public override void SvOnDimensionEnter(int dimensionId)
		{
		}

		public override void SvOnDimensionExit(int dimensionId)
		{
		}

		public void SvApplyDimensionSwap(DimensionInfo info)
		{
		}

		public void SvRevertDimensionSwap(DimensionInfo info)
		{
		}

		public override void ClOnDimensionEnter(int dimensionId)
		{
		}

		public override void ClOnDimensionExit(int dimensionId)
		{
		}

		public void ClApplyDimensionSwap(DimensionInfo info)
		{
		}

		public void ClRevertDimensionSwap(DimensionInfo info)
		{
		}
	}
}
