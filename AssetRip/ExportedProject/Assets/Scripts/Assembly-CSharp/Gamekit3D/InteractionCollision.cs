using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
	[RequireComponent(typeof(Collider))]
	public class InteractionCollision : MonoBehaviour
	{
		public LayerMask layers;

		public UnityEvent OnCollision;

		public void Reset()
		{
		}

		public void OnCollisionEnter(Collision c)
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
