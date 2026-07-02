using UnityEngine;

namespace BAPBAP.Entities
{
	public interface IPhysicsResimulated
	{
		void SimTriggerEnter(Collider collider);

		void SimTriggerExit(Collider collider);
	}
}
