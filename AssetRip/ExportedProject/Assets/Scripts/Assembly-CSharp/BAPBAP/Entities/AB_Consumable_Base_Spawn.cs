using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Consumable_Base_Spawn : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

			[Tooltip("Interrupts the casting if entity just got damaged")]
			public bool interuptCastOnDamage;

			[Header("Place Config")]
			[Tooltip("Placement range for this consumable")]
			public float maxDistance;

			[Tooltip("Perform a line of sight check with obstacles, and clamps the position to the nearest wall")]
			public bool clampOnLineOfSight;

			[Tooltip("Ensures the place position is within the bounds of the navmesh. Enable to ensure consumable gets placed in the playable area")]
			public bool pointNavMeshClamp;

			[ConditionalHide("pointNavMeshClamp", true)]
			public float pointNavRadiusAmount;

			[Header("Mouse Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorMouseHalfScale;

			public Vector2 indicatorBaseHalfScale;

			public Vector2 indicatorOffset;

			public float indicatorConeAngle;

			public bool indicatorRotateWithDirection;

			[Header("VFX/SFX")]
			public GameObject castVfx;

			public AudioClipData castSfx;

			public GameObject loopVfx;

			public AudioClipData loopSfx;
		}

		public class CustomPlaceConsumableSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Consumable_Base_Spawn behaviour;

			[NonSerialized]
			public RaycastHit hit;

			[NonSerialized]
			public LayerMask obstacleMask;

			public CustomPlaceConsumableSubroutine(AB_Consumable_Base_Spawn behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public AB_Consumable_Base_Spawn(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public virtual void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}

		public void DoDropConsumable(GameObject consumablePrefab, Vector3 landingPoint, Quaternion rotation, ItemTiers consumableTier, Action<GameObject> afterInstantiateAction = null, int teamId = -1)
		{
		}
	}
}
