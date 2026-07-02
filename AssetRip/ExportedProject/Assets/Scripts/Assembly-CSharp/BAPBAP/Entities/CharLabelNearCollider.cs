using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharLabelNearCollider : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharLabelNear charLabelNear;

		[NonSerialized]
		public SphereCollider sphereCollider;

		public void Initialize(EntityManager _entityManager, CharLabelNear _charLabelNear)
		{
		}

		public void Start()
		{
		}

		public void SetEnabled(bool isEnabled)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}
	}
}
