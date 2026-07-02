using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharNearbyDetect : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public List<GameObject> charsDetected;

		[Header("References")]
		[SerializeField]
		public SphereCollider detectCollider;

		[SerializeField]
		[Header("Settings")]
		public float colliderRadius;

		[SerializeField]
		public bool doLineOfSight;

		[ConditionalHide("doLineOfSight", true)]
		[SerializeField]
		public float lineOfSightUpdateRate;

		[SerializeField]
		public bool doToggleClosest;

		[ConditionalHide("doToggleClosest", true)]
		[SerializeField]
		public float closestTriggerRadius;

		[NonSerialized]
		public float lineOfSightTimer;

		[NonSerialized]
		public float closestTriggerRadiusSqr;

		[NonSerialized]
		public bool detectMarkActive;

		[NonSerialized]
		public bool detectMarkIsClosest;

		[NonSerialized]
		public LayerMask obstaclesMask;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public void Update()
		{
		}

		public void OnCharDetected(GameObject detectedCharObj)
		{
		}

		public void OnCharStopDetected()
		{
		}

		public void SetDetectionMarkEnabled(bool isEnabled)
		{
		}

		public void SetDetectionMarkClosest(bool isClosest)
		{
		}

		public void TrySetCharDetectMark(Transform charTransform)
		{
		}

		public bool HasLineOfSight(Vector3 targetPosition)
		{
			return false;
		}
	}
}
