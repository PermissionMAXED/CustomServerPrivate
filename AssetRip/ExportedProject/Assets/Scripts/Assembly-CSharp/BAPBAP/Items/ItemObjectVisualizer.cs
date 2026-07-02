using System;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemObjectVisualizer : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public Transform transformPiv;

		[SerializeField]
		public MeshFilter meshFilter;

		[SerializeField]
		public MeshRenderer meshRenderer;

		[SerializeField]
		public MeshFilter secondaryMeshFilter;

		[SerializeField]
		public MeshRenderer secondaryMeshRenderer;

		[NonSerialized]
		public GameObject meshVfxInstance;

		[NonSerialized]
		public MaterialPropertyBlock propBlock;

		[NonSerialized]
		public MaterialPropertyBlock secondaryPropBlock;

		public MaterialPropertyBlock PropBlock => null;

		public MaterialPropertyBlock SecondaryPropBlock => null;

		public MeshRenderer MeshRenderer => null;

		public void Initialize(int itemId, int amount = 1)
		{
		}

		public void Initialize(Item item, int amount = 1)
		{
		}

		public void SetTierColor(Color tierColor, int tierInt = -1)
		{
		}

		public void SetOutlineSize(float size)
		{
		}
	}
}
