using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.Local
{
	public class PhysicsPropImpactFxPlay : MonoBehaviour
	{
		[Min(0f)]
		[SerializeField]
		public float impactThreshold;

		[SerializeField]
		public GameObject[] impactPrefabVfx;

		[SerializeField]
		public AudioClipData[] impactSfx;

		[SerializeField]
		public StudioEventEmitter impactFmodEmitter;

		[SerializeField]
		public bool checkIsClient;

		[SerializeField]
		public UnityEvent OnImpact;

		public void Start()
		{
		}

		public void OnCollisionEnter(Collision other)
		{
		}

		public void PlayImpact(Vector3 worldPos, Vector3 dir)
		{
		}
	}
}
