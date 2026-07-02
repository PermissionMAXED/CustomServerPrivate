using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class Teleporter : NetworkBehaviour, IEntityDataProperty
	{
		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[Header("Settings")]
		[SerializeField]
		public Vector3 teleportPoint;

		[SerializeField]
		public float chargeDuration;

		[SerializeField]
		public float cooldownDuration;

		[SerializeField]
		public bool pages;

		[SerializeField]
		public int pagesCount;

		[SerializeField]
		public GameObject pageEnable;

		[NonSerialized]
		public NavMeshLink navMeshLink;

		[NonSerialized]
		public float chargeTimer;

		[NonSerialized]
		public bool isCharging;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public List<EntityManager> currentChars;

		[NonSerialized]
		public int currentPassivecount;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		[Server]
		public void StartTeleporterCharge()
		{
		}

		[Server]
		public void TeleportAllChars()
		{
		}

		[Server]
		public void TeleportChar(EntityManager entity)
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
