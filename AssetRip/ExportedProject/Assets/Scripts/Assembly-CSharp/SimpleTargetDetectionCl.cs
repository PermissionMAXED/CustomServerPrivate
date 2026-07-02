using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

public class SimpleTargetDetectionCl : MonoBehaviour
{
	[Header("General")]
	[Tooltip("The collider attached to this target detection. If leaving this null, a new collider will be created from the collider prefab")]
	[SerializeField]
	public Collider searchCollider;

	[Tooltip("The radius of the collider to search targets")]
	[SerializeField]
	public float searchRadius;

	[Header("Target Settings")]
	[SerializeField]
	[Min(1f)]
	public int sortTargetsRate;

	[Tooltip("Should the target detection see hidden characters?")]
	[SerializeField]
	public bool canSeeHiddenTargets;

	[Tooltip("Only choose local team players for the target detection")]
	[SerializeField]
	public bool onlyLocalTeamPlayers;

	[Header("Line Of Sight")]
	[Tooltip("Should do line of sight raycast checks when finding targets?")]
	[SerializeField]
	public bool doLineOfSight;

	[NonSerialized]
	public Action<Transform> onTargetFoundAction;

	[NonSerialized]
	public EntityManager currentTarget;

	[NonSerialized]
	public List<EntityManager> foundChars;

	[NonSerialized]
	public LayerMask obstaclesMask;

	public void Awake()
	{
	}

	public void Initialize(Action<Transform> onTargetFoundAction = null)
	{
	}

	public void Update()
	{
	}

	public void SortFoundTargets()
	{
	}

	public EntityManager ChooseBestTarget()
	{
		return null;
	}

	public void OnTriggerEnter(Collider other)
	{
	}

	public void OnTriggerExit(Collider other)
	{
	}

	public void SetSearchColliderRadius(float radius)
	{
	}

	public bool HasLineOfSight(Vector3 targetPos)
	{
		return false;
	}
}
