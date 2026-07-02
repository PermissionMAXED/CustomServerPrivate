using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	public class ColliderEnable : MonoBehaviour
	{
		[SerializeField]
		public float ttl;

		[SerializeField]
		[FormerlySerializedAs("hitboxColliders")]
		public Collider[] colliders;

		[SerializeField]
		public bool doSetEnabled;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool isEnabled;

		public void OnEnable()
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
