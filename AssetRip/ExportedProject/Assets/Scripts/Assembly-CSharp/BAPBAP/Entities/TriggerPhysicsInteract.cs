using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TriggerPhysicsInteract : MonoBehaviour
	{
		[NonSerialized]
		public CharacterController cc;

		public const float maxVel = 7f;

		public void Awake()
		{
		}

		public void OnCollisionEnter(Collision col)
		{
		}

		public void ApplyForce(Collision col)
		{
		}
	}
}
