using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using BAPBAP.AssetContainer;
using Dreamteck.Splines;
using UnityEngine;

namespace BAPBAP.Geometry
{
	public class SplineShapeCreator : MeshShapeCreator
	{
		[HideInInspector]
		[SerializeField]
		public Spline.Type splineType;

		[SerializeField]
		[HideInInspector]
		public SplineComputer.SampleMode sampleMode;

		[SerializeField]
		[HideInInspector]
		public int sampleRate;

		[SerializeField]
		[HideInInspector]
		public bool autoCount;

		[SerializeField]
		[HideInInspector]
		public int count;

		[SerializeField]
		public bool autoUpdateSplines;

		public SerializedDictionary<GameObject, string> instantiatedSplines;

		public override bool IsBaked => false;

		public override void Unbake(bool deleteAsset = true)
		{
		}

		public override void OnRequestBakeProcesses(Dictionary<MeshAssetContainer, List<MeshFilter>> bakeProcesses)
		{
		}

		public List<MeshFilter> GetSplineMeshFilters()
		{
			return null;
		}

		public override void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}
	}
}
