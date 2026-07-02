using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_BubbleBumper : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			[Header("Custom Config")]
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float startCooldownTime;

			public float castTime;

			[ConditionalHide("cancelable", true)]
			public float canceledTime;

			public float recoveryTime;

			public float baseCooldown;

			[Header("Aim Config")]
			public float maxDistance;

			public bool clampOnLineOfSight;

			public bool pointNavMeshClamp;

			[ConditionalHide("pointNavMeshClamp", true)]
			public float pointNavRadiusAmount;

			[Header("Mouse Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorMouseHalfScale;

			public Vector2 indicatorBaseHalfScale;

			public Vector2 indicatorOffset;

			public bool indicatorRotateWithDirection;

			[Header("VFX/SFX")]
			public GameObject vfxCast;

			public AudioClipData sfxCast;

			[Space(5f)]
			public GameObject loopVfx;

			public AudioClipData loopSfx;

			[Space(5f)]
			public GameObject vfxUse;

			public AudioClipData sfxUse;

			[Header("Entity Config")]
			public GameObject entityPrefab;
		}

		public class CustomSpawnEntitySubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_BubbleBumper behaviour;

			[NonSerialized]
			public RaycastHit hit;

			[NonSerialized]
			public LayerMask obstacleMask;

			public CustomSpawnEntitySubroutine(AB_BubbleBumper _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Vector3 spawnPos;

		public AB_BubbleBumper(Config config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void DoUse(Vector3 spawnPos)
		{
		}
	}
}
