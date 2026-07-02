using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharAbilities : NetworkBehaviour, INetworkPredicted
	{
		public const int CONSTANT_ITEM_OFFSET = 4;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharHidden charHidden;

		[NonSerialized]
		public CharAnimator charAnim;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIAbilities uiAbilities;

		[NonSerialized]
		public UIPopUp uIPopUp;

		[NonSerialized]
		public RngManager rngManager;

		[NonSerialized]
		public Ability[] abilities;

		[NonSerialized]
		public Ability[] abilitiesByPriority;

		[NonSerialized]
		public Ability[] abilitiesWithAutoCancel;

		[NonSerialized]
		public CmdBufferSystem cmdBufferSystem;

		[SerializeField]
		public Transform[] attachables;

		[SerializeField]
		[Header("Stats")]
		public float baseCritDmg;

		[SerializeField]
		public float baseCritChance;

		[SerializeField]
		public float baseLifeSteal;

		[SerializeField]
		[Header("Caps")]
		public float maxAttackSpeed;

		[NonSerialized]
		public CastFlags castFlags;

		[NonSerialized]
		public byte silenceLocks;

		[NonSerialized]
		public byte teleportLocks;

		[NonSerialized]
		public float damage;

		[NonSerialized]
		public float attackSpeed;

		[NonSerialized]
		public float cooldown;

		[NonSerialized]
		public float critChance;

		[NonSerialized]
		public float critDmg;

		[NonSerialized]
		public float lifesteal;

		[NonSerialized]
		public float shred;

		[NonSerialized]
		public float luck;

		[NonSerialized]
		public bool isHiddenByAbility;

		[NonSerialized]
		public byte forceFullbodyAnimLocks;

		[NonSerialized]
		public byte animLocks;

		[NonSerialized]
		public float damageModifier;

		[NonSerialized]
		public float weakenModifer;

		[NonSerialized]
		public bool isParrying;

		[NonSerialized]
		public bool blockCastFlagsOverride;

		[NonSerialized]
		public bool consumableCastLock;

		[NonSerialized]
		public float gameModeDamageMultiplier;

		[NonSerialized]
		public float damageMultiplier;

		[NonSerialized]
		public float damageToPlayersMultiplier;

		public Action OnAddSilenceLockAction;

		public byte SilenceLocks => 0;

		public byte ForceFullbodyAnimLocks => 0;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void ClStartAuth()
		{
		}

		public void ClStopAuth()
		{
		}

		public void ResetAllAbilities()
		{
		}

		public void ForceInterruptAllAbilities()
		{
		}

		public void SortAbilitiesByPriority()
		{
		}

		public void SortAbilitiesAutoCancel()
		{
		}

		public void TryToggleCastingBar()
		{
		}

		public void AddSilenceLocks()
		{
		}

		public void RemoveSilenceLocks()
		{
		}

		public void AddFullBodyAnimLocks()
		{
		}

		public void RemoveFullBodyAnimLocks()
		{
		}

		public void UpdateConsumableItem(int slotId)
		{
		}

		public bool IsConsumableOnCooldown(int slotId)
		{
			return false;
		}

		public void UpdateLootableAbility()
		{
		}

		public bool IsLootableAbilityOnCooldown()
		{
			return false;
		}

		public void SetCastAbility(CastFlags castFlag)
		{
		}

		public void ResetCastAbility(CastFlags castFlag)
		{
		}

		public bool IsAbilityBeingCanceled(int cmdId)
		{
			return false;
		}

		public bool IsCasting()
		{
			return false;
		}

		public bool IsCriticalDamage(int predTickNum, int nonce = 0)
		{
			return false;
		}

		public int GetModifiedDamage(int sourceDmg, float damageScaling = 1f, bool isCrit = false)
		{
			return 0;
		}

		public void SetHidden(bool isHidden)
		{
		}

		public void SvTriggerBushReveal()
		{
		}

		[ClientRpc]
		public void RpcTriggerBushReveal()
		{
		}

		[ClientRpc]
		public void RpcResetText()
		{
		}

		[ClientRpc]
		public void RpcCastResult(bool isSuccess)
		{
		}

		[ClientRpc]
		public void RpcAbilityReady(int cmdId)
		{
		}

		[ClientRpc]
		public void RpcSetSilenced(int cmdId, bool isSilenced)
		{
		}

		public void OnAttackSpeedChanged()
		{
		}

		public void OnSilenceLocksChanged()
		{
		}

		public void OnStatChanged()
		{
		}

		public void OnHiddenByAbilityChanged()
		{
		}

		public void OnForceFullbodyAnimLocksChanged()
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

		public void UserCode_RpcTriggerBushReveal()
		{
		}

		public static void InvokeUserCode_RpcTriggerBushReveal(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcResetText()
		{
		}

		public static void InvokeUserCode_RpcResetText(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcCastResult__Boolean(bool isSuccess)
		{
		}

		public static void InvokeUserCode_RpcCastResult__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcAbilityReady__Int32(int cmdId)
		{
		}

		public static void InvokeUserCode_RpcAbilityReady__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetSilenced__Int32__Boolean(int cmdId, bool isSilenced)
		{
		}

		public static void InvokeUserCode_RpcSetSilenced__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharAbilities()
		{
		}
	}
}
