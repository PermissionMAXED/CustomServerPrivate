using UnityEngine;

public class PhysicsIgnoreCollider : MonoBehaviour
{
	[SerializeField]
	public Collider sourceCollider;

	[SerializeField]
	public Collider targetCollider;

	public void Awake()
	{
	}
}
