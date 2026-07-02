using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Mech : MountableInteractable
	{
		[NonSerialized]
		public CharWorldPosition charWorldPos;

		[Header("Hitbox Config")]
		[ExHeader("Mech Parameters", 1f, 1f, 0f)]
		[SerializeField]
		public bool enableMoveHitbox;

		[ConditionalHide("enableMoveHitbox", true)]
		[SerializeField]
		public float speedThresholdActivateHitbox;

		[ConditionalHide("enableMoveHitbox", true)]
		[SerializeField]
		public GameObject hitboxPrefab;

		[ConditionalHide("enableMoveHitbox", true)]
		[SerializeField]
		public int hitboxDamage;

		[ConditionalHide("enableMoveHitbox", true)]
		[SerializeField]
		public float hitboxRate;

		[ConditionalHide("enableMoveHitbox", true)]
		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Space(10f)]
		[SerializeField]
		public bool debugGizmos;

		[NonSerialized]
		public Hitbox collisionHitbox;

		[NonSerialized]
		public float hitboxRateTimer;

		[NonSerialized]
		public float currentSpeed;

		[NonSerialized]
		public Vector3 svPrevPos;

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public void CreateCollisionHitbox()
		{
		}

		public override void AssignDriver(EntityManager entity)
		{
		}

		public override void RemoveDriver(EntityManager entity)
		{
		}

		public override void AssignCharInVehicle(EntityManager entity, Seat seat)
		{
		}

		public override void RemoveCharInVehicle(EntityManager entity, Seat seat)
		{
		}

		public override void FixedUpdate()
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entityManager, int slotId)
		{
		}

		public override void ClOnApplyAuth(EntityManager entity)
		{
		}

		public override void ClOnRemoveAuth(EntityManager entity)
		{
		}

		public override void OnCharVehicleChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entityManager, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static Mech()
		{
		}
	}
}
