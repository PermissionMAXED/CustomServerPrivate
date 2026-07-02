using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
	[RequireComponent(typeof(Collider))]
	public class InteractOnTrigger : MonoBehaviour
	{
		public LayerMask layers;

		public UnityEvent OnEnter;

		public UnityEvent OnExit;

		public Collider collider;

		public InventoryController.InventoryChecker[] inventoryChecks;

		public void Reset()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public virtual void ExecuteOnEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public virtual void ExecuteOnExit(Collider other)
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
