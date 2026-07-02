using System;
using System.Collections.Generic;
using BAPBAP.Entities.View;
using BAPBAP.Game;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BattleRoyaleZone : NetworkBehaviour
	{
		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public UICanvasEffect uiCanvasEffect;

		[NonSerialized]
		public EntityInterpolator entityInterp;

		[Header("References")]
		[SerializeField]
		public Transform zoneCylinderMesh;

		[Min(0f)]
		[Tooltip("Process character zone every X seconds")]
		[Header("Settings")]
		[SerializeField]
		public float svProcessCharsZoneRate;

		[Min(0f)]
		[SerializeField]
		public float clProcessCharsZoneRate;

		[NonSerialized]
		public int damage;

		[NonSerialized]
		public float damageHpPercent;

		[NonSerialized]
		public float damageRate;

		[NonSerialized]
		public float botDmgMultiplier;

		[NonSerialized]
		public float damageTimer;

		[NonSerialized]
		public float closeTimer;

		[NonSerialized]
		public float closeDuration;

		[NonSerialized]
		public float initialRadius;

		[NonSerialized]
		public float targetRadius;

		[NonSerialized]
		public Vector2 initialPos;

		[NonSerialized]
		public Vector2 targetPos;

		[NonSerialized]
		public float svProcessCharsTime;

		[NonSerialized]
		public float clProcessCharsTime;

		[NonSerialized]
		public float sqrRadius;

		[NonSerialized]
		public List<EntityManager> charsInZone;

		[NonSerialized]
		public EntityManager clLocalCharInZone;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void ProcessAllCharactersZoneCollision()
		{
		}

		public void ProcessCharacterZoneCollision(EntityManager entityManager)
		{
		}

		public bool TestCharacterInZone(Transform charTransform)
		{
			return false;
		}

		public bool IsCharacterInZone(EntityManager entityManager)
		{
			return false;
		}

		public void SvCharZoneEnter(EntityManager entityManager)
		{
		}

		public void OnZoneEnter(EntityManager entityManager)
		{
		}

		public void OnZoneExit(EntityManager entityManager)
		{
		}

		[Server]
		public void DamageAllPlayersInZone()
		{
		}

		public void Initialize(int damage, float damageHpPercent, float damageRate)
		{
		}

		public float GetCurrentZoneRadius()
		{
			return 0f;
		}

		public float GetCurrentZoneRadiusSqr()
		{
			return 0f;
		}

		public float GetTargetZoneRadius()
		{
			return 0f;
		}

		public float GetTargetZoneRadiusSqr()
		{
			return 0f;
		}

		public Vector3 GetCurrentZonePosition()
		{
			return default(Vector3);
		}

		public Vector2 GetCurrentZonePositionV2()
		{
			return default(Vector2);
		}

		public Vector3 GetTargetZonePosition()
		{
			return default(Vector3);
		}

		public Vector2 GetTargetZonePositionV2()
		{
			return default(Vector2);
		}

		public void SetDamage(int damage)
		{
		}

		public void SetDamageHpPercent(float damageHpPercent)
		{
		}

		public bool IsClosing()
		{
			return false;
		}

		[Server]
		public void StartClosingZone(float duration, Vector2 targetPos, float targetRadius)
		{
		}

		[Server]
		public void SetTargetValues(Vector2 targetPos, float targetRadius)
		{
		}

		[Server]
		public void SvSetZoneRadiusAndPos(Vector2 pos, float radius)
		{
		}

		[Server]
		public void SetZoneClosingFinished()
		{
		}

		[Server]
		public void ForceZoneTargetPos()
		{
		}

		public void ClOnZoneEnter(EntityManager entityManager)
		{
		}

		public void ClOnZoneExit(EntityManager entityManager)
		{
		}

		[ClientRpc]
		public void RpcSetNewPosition(int svTickNum, Vector3 scale, Vector3 position)
		{
		}

		[TargetRpc]
		public void TargetRpcZoneOverlayToggle(NetworkConnection conn, bool isEnabled)
		{
		}

		[ClientRpc]
		public void RpcSetZoneOverlay(EntityManager entityManager, bool isEnabled)
		{
		}

		public void SetZoneValuesToShader(Vector2 pos, float radius)
		{
		}

		public void SetZonePreviewRingToShader(Vector2 pos, float radius)
		{
		}

		[ClientRpc]
		public void RpcEnablePreviewRing(Vector2 targetPos, float targetRadius)
		{
		}

		[ClientRpc]
		public void RpcDisablePreviewRing()
		{
		}

		public void OnDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSetNewPosition__Int32__Vector3__Vector3(int svTickNum, Vector3 scale, Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSetNewPosition__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcZoneOverlayToggle__NetworkConnection__Boolean(NetworkConnection conn, bool isEnabled)
		{
		}

		public static void InvokeUserCode_TargetRpcZoneOverlayToggle__NetworkConnection__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetZoneOverlay__EntityManager__Boolean(EntityManager entityManager, bool isEnabled)
		{
		}

		public static void InvokeUserCode_RpcSetZoneOverlay__EntityManager__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcEnablePreviewRing__Vector2__Single(Vector2 targetPos, float targetRadius)
		{
		}

		public static void InvokeUserCode_RpcEnablePreviewRing__Vector2__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDisablePreviewRing()
		{
		}

		public static void InvokeUserCode_RpcDisablePreviewRing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static BattleRoyaleZone()
		{
		}
	}
}
