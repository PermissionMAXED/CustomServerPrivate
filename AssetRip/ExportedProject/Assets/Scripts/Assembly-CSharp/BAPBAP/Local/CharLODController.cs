using UnityEngine;

namespace BAPBAP.Local
{
	public class CharLODController : MonoBehaviour
	{
		[Header("Settings")]
		public LocalSavedData.CharLODMode selectedLODMode;

		[SerializeField]
		[Header("References")]
		public SkinnedMeshRenderer charRenderer;

		[SerializeField]
		[Header("LOD Meshes")]
		public Mesh highResMesh;

		[SerializeField]
		public Mesh mediumResMesh;

		[SerializeField]
		public Mesh lowResMesh;

		public void Start()
		{
		}

		public void SetLODMesh(LocalSavedData.CharLODMode lodMode)
		{
		}
	}
}
