using UnityEngine;

namespace BAPBAP.Local
{
	public class MinimapTextureRenderer : MonoBehaviour
	{
		[Header("General References")]
		[SerializeField]
		public Mesh quadMesh;

		[SerializeField]
		public Mesh circleMesh;

		[SerializeField]
		public Material minimapBlitMat;

		[Header("Settings")]
		[SerializeField]
		public int minResolution;

		[SerializeField]
		public float texResolutionMultiplier;

		[SerializeField]
		public int antialiasingSamples;

		[Tooltip("When rendering obstacle colliders, their scale will be at least of this scale, in order to avoid too small shapes in the minimap.")]
		[SerializeField]
		public float minColliderSize;

		[SerializeField]
		[Tooltip("Add a small radius expand so cylinders cover a bit more area in the map, to try to cover small gaps.")]
		public float circleMeshExpand;
	}
}
