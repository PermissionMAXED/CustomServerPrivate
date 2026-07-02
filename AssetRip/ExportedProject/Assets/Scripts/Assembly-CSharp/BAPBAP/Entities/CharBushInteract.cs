using System;
using BAPBAP.Systems;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharBushInteract : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharHideArea charHideArea;

		[NonSerialized]
		public SystemManager systemManager;

		[NonSerialized]
		public Vector2 playerVelocityLerp;

		[SerializeField]
		public float directionLerpSpeed;

		[NonSerialized]
		public Transform rendTransform;

		[NonSerialized]
		public Vector3 prevPos;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void UpdateShaderValues()
		{
		}
	}
}
