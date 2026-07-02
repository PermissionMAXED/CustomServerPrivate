using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class EntityVisibility : MonoBehaviour
	{
		[NonSerialized]
		public CameraManager camManager;

		[Header("References")]
		[SerializeField]
		public SphereCollider col;

		[SerializeField]
		public Transform posTransform;

		[Header("Settings")]
		[SerializeField]
		[Tooltip("The rate at which all the characters currently active will update their visibility")]
		public float refreshRate;

		public Transform followTarget;

		[NonSerialized]
		public int followTeamId;

		[NonSerialized]
		public int ignoreFowLocks;

		[NonSerialized]
		public float refreshTimer;

		[NonSerialized]
		public Plane[] cameraFrustumPlanes;

		[NonSerialized]
		public List<EntityManager> activeEntities;

		[NonSerialized]
		public List<EntityManager> allyVisionVisibleCharacters;

		[NonSerialized]
		public bool isOwned;

		[NonSerialized]
		public LayerMask obstaclesMask;

		[NonSerialized]
		public RaycastHit losHit;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}

		public void ForceRefresh()
		{
		}

		public void SetVisibilityRadius(float radius)
		{
		}

		public void EnableEntityVisibility(EntityManager followChar)
		{
		}

		public void EnableEntityVisibility(Transform followTransform, int teamId, bool hasAuth)
		{
		}

		public void DisableEntityVisibility()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public void SetCharVisibility(EntityManager otherEntity, bool setVisible = false, bool forceOutOfCameraView = false)
		{
		}

		public bool IsLineOfSightBlocked(Vector3 originPos, EntityManager targetEntity)
		{
			return false;
		}

		public bool IsOnCameraView(EntityManager entityManager)
		{
			return false;
		}

		public bool HasAllyVision(EntityManager target)
		{
			return false;
		}

		public bool IsRevealed(EntityManager target)
		{
			return false;
		}

		public bool SolvePortalCollision(Vector3 originPos, Vector3 targetPos)
		{
			return false;
		}
	}
}
