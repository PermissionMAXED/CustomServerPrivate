using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(Vehicle))]
	public class VehicleForkliftJump : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public Vehicle vehicle;

		[Header("References")]
		[SerializeField]
		public EntityActivateFling entityFling;

		[SerializeField]
		public Animator animator;

		[SerializeField]
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 baseHalfScale;

		[Header("Hitbox")]
		[SerializeField]
		public GameObject flingHitboxPrefab;

		[SerializeField]
		public float jumpHitboxTtl;

		[Header("Settings")]
		[SerializeField]
		public CommandId jumpCommandId;

		[SerializeField]
		public float jumpCastDuration;

		[SerializeField]
		public float jumpCdDuration;

		[SerializeField]
		public string jumpAnimationHash;

		[SerializeField]
		public AudioClipData[] jumpStartSfx;

		[NonSerialized]
		public bool isJumping;

		[NonSerialized]
		public bool inCooldown;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void StartJump()
		{
		}

		public void EndJump()
		{
		}

		public void DoJump()
		{
		}

		public void OnFlingEnter(EntityManager entity, HitboxBase hitboxBase)
		{
		}

		[ClientRpc]
		public void OnJumpStart()
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_OnJumpStart()
		{
		}

		public static void InvokeUserCode_OnJumpStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static VehicleForkliftJump()
		{
		}
	}
}
