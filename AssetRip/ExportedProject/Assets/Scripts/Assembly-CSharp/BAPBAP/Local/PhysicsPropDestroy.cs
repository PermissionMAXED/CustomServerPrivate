using UnityEngine;

namespace BAPBAP.Local
{
	public class PhysicsPropDestroy : MonoBehaviour
	{
		[SerializeField]
		[Min(0f)]
		public float impactThreshold;

		[SerializeField]
		public GameObject[] destroyGibs;

		[SerializeField]
		public GameObject[] destroyPrefabVfx;

		[SerializeField]
		public AudioClipData[] destroySfx;

		public void Start()
		{
		}

		public void OnCollisionEnter(Collision other)
		{
		}

		public void Destroy(Vector3 force)
		{
		}
	}
}
