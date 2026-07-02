using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
	[RequireComponent(typeof(SphereCollider))]
	public class InteractionTrigger : MonoBehaviour
	{
		public LayerMask layers;

		public UnityEvent OnEnter;

		public UnityEvent OnExit;

		public SphereCollider collider;

		public void Reset()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public void OnDrawGizmos()
		{
		}

		public void OnDrawGizmosSelected()
		{
		}
	}
}
