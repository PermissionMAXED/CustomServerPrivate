using System;
using System.Collections.Generic;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharLabelNear : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIWorldLabel uiWorldLabel;

		[Header("References")]
		[SerializeField]
		public GameObject detectColliderPrefab;

		[SerializeField]
		[Header("Settings")]
		public float detectionRadius;

		[SerializeField]
		public float updateRate;

		[NonSerialized]
		public List<LabelElement> nearLabelObjects;

		[NonSerialized]
		public CharLabelNearCollider labelNearCollider;

		[NonSerialized]
		public float lineOfSightTimer;

		[NonSerialized]
		public LayerMask obstaclesMask;

		[NonSerialized]
		public bool isClient;

		public void PreAwake(EntityManager e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public bool IsLineOfSightBlocked(Vector3 targetPos)
		{
			return false;
		}

		public void AddLabel(LabelElement label)
		{
		}

		public void RemoveLabel(LabelElement label)
		{
		}

		public void SetLabelHidden(LabelElement label, bool isHidden)
		{
		}

		public void SetDetectLabelEnabled(bool isEnabled)
		{
		}

		public void RemoveLabelsAndDisable()
		{
		}

		public void OnDestroy()
		{
		}
	}
}
