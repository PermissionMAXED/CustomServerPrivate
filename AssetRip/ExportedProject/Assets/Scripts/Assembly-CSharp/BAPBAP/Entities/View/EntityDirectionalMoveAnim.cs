using System;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityDirectionalMoveAnim : MonoBehaviour
	{
		[NonSerialized]
		public Quaternion worldRotation;

		[NonSerialized]
		public EntityManager entityManager;

		[SerializeField]
		public float lerpParam;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
