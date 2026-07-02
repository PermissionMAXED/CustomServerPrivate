using System;
using System.Text;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BehaviourAbilityComponent : Ability
	{
		[NonSerialized]
		public AbilityBehaviour abInstance;

		[NonSerialized]
		public int abilityBehaviourId;

		[NonSerialized]
		public float cooldownTimeElapsed;

		[NonSerialized]
		public float cooldownTime;

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void Start()
		{
		}

		public void Update()
		{
		}

		public void OnDestroy()
		{
		}

		public override void ClStartAuth()
		{
		}

		public override void ClStopAuth()
		{
		}

		public override float GetAbilityCooldownTimeElapsed()
		{
			return 0f;
		}

		public override float GetAbilityCooldownTime()
		{
			return 0f;
		}

		public void SetAbilityBehaviour(int newAbilityBehaviourId, AbilityBehaviourSO abilityBehaviour)
		{
		}

		public override void OnTargetHit(EntityManager otherCharManager, HitboxBase hitbox)
		{
		}

		public override void OnHitboxDestroy(HitboxBase hitboxBase)
		{
		}

		public override void ForceInterrupt()
		{
		}

		public override bool OnStopItemRemoved()
		{
			return false;
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3(Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static BehaviourAbilityComponent()
		{
		}
	}
}
