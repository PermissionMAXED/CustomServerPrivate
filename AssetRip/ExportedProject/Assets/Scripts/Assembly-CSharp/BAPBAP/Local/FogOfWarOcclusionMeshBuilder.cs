using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FogOfWarOcclusionMeshBuilder : MonoBehaviour
	{
		[NonSerialized]
		public GameObject container;

		[NonSerialized]
		public Mesh generatedMesh;

		public const float meshHeight = 80f;

		public bool getCollidersInChildren;

		public bool ignoreTriggerColliders;

		public bool spawnedInLocalSpace;

		[NonSerialized]
		public bool setEnabled;

		public void Start()
		{
		}

		public void SetFowObjectEnabled(bool e)
		{
		}

		public CombineInstance[] GetOcclusionCombineInstances()
		{
			return null;
		}

		public void GenerateCombinedMesh(CombineInstance[] ci)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
