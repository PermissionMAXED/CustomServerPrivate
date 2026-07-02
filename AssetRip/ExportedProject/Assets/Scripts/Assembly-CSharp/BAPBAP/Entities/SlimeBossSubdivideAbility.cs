using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SlimeBossSubdivideAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossSubdivideAbility ability;

			public CustomShootSubroutine(SlimeBossSubdivideAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSetMinHealthSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossSubdivideAbility ability;

			[NonSerialized]
			public bool doSet;

			public CustomSetMinHealthSubroutine(SlimeBossSubdivideAbility _ability, bool _doSet)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public SlimeBossBehaviour slimeBehaviour;

		[SerializeField]
		[Header("General")]
		public Transform firingPoint;

		[SerializeField]
		public float angleSpread;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public GameObject castVfxPrefab;

		[SerializeField]
		public GameObject finishedVfxPrefab;

		[SerializeField]
		public AnimLayerIndices animLayer;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData divideSfx;

		[SerializeField]
		public AudioClipData divideVoSfx;

		[Header("Divide Settings")]
		[SerializeField]
		public float blobSpawnOffsetAmount;

		[SerializeField]
		public GameObject slimePrefabA;

		[SerializeField]
		public GameObject slimePrefabB;

		[NonSerialized]
		public LayerMask obstacleMask;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		[ClientRpc]
		public void RpcPlayCastVFX()
		{
		}

		public void Divide()
		{
		}

		public void SpawnSlimeBoss(Vector3 spawnPos, GameObject slime, List<SlimeBossBehaviour> newSlimes)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayCastVFX()
		{
		}

		public static void InvokeUserCode_RpcPlayCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SlimeBossSubdivideAbility()
		{
		}
	}
}
