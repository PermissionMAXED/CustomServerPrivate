using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharHurtbox : NetworkBehaviour, INetworkPredicted
	{
		public delegate void OnHitDelegate(Vector3 hitDir, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider);

		[CompilerGenerated]
		public sealed class _003CApplyHealOverTime_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float duration;

			public int intervals;

			public int totalHealAmount;

			public CharHurtbox _003C_003E4__this;

			[NonSerialized]
			public float _003CintervalDuration_003E5__2;

			[NonSerialized]
			public int _003CintervalHealAmount_003E5__3;

			[NonSerialized]
			public float _003Ctimer_003E5__4;

			[NonSerialized]
			public int _003CelapsedIntervals_003E5__5;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CApplyHealOverTime_003Ed__74(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public CharFX charFx;

		[NonSerialized]
		public CharHidden charHidden;

		[NonSerialized]
		public CharAnimator charAnim;

		[NonSerialized]
		public CharDowned charDowned;

		[NonSerialized]
		public CharHpBar charHpBar;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIPopUp uiPopUp;

		[NonSerialized]
		public CameraShake camShake;

		[NonSerialized]
		public GameManager gameManager;

		[Header("Configs")]
		[SerializeField]
		[Min(0f)]
		public int baseHp;

		[SerializeField]
		[Min(0f)]
		public int baseShield;

		[Tooltip("If enabled, all incoming damage will be clamped to a max of 1")]
		[SerializeField]
		public bool onlyTake1Damage;

		[Tooltip("If enabled, this entity wont receive any hits")]
		[SerializeField]
		public bool nonDamagable;

		[SerializeField]
		[Tooltip("Multiplier for reveiced npc damage towards this character")]
		public float damageTakenFromNpcsMultiplier;

		[Tooltip("Multiplier for reveiced zone damage towards this character")]
		[SerializeField]
		public float zoneDamageMultiplier;

		[Tooltip("Target detection scripts will ignore this character if enabled")]
		[SerializeField]
		public bool ignoredByTargeting;

		[Tooltip("How much time for this character to go out of combat when receiving a hit")]
		[SerializeField]
		public float outOfCombatDuration;

		[SerializeField]
		[Min(0f)]
		public float inPlayerCombatDuration;

		[Tooltip("How much time to grant assist/kill when last received a hit")]
		[Min(0f)]
		[SerializeField]
		public float lastPlayersHitDuration;

		[Tooltip("Prevent this entity from being killed by limiting the hp to 1")]
		[SerializeField]
		public bool min1Hp;

		[Header("Effects")]
		[Tooltip("Shows an low hp ui overlay if this character hp falls below this percentage")]
		[Range(0f, 1f)]
		[SerializeField]
		public float hpDangerEffectPercentage;

		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("What is the max HP % at which maximum trauma is applied? (E.g. 0.5 -> when receiving dmg doing 50% of hp, do max trauma)")]
		public float maxCamShakeTraumaHpPerc;

		[SerializeField]
		[Tooltip("Should this character show a ui kill pop-up element on screen when killed?")]
		public bool showKillPopup;

		[NonSerialized]
		public float lifeStealNPCPenaltyPercent;

		[NonSerialized]
		public float lastHitTimer;

		[NonSerialized]
		public float inPlayerCombatTimer;

		[NonSerialized]
		public bool isNonHittable;

		[NonSerialized]
		public byte immuneLocks;

		[NonSerialized]
		public bool overHealToShields;

		[NonSerialized]
		public int maxHp;

		[NonSerialized]
		public int hp;

		[NonSerialized]
		public int maxShield;

		[NonSerialized]
		public int shield;

		[NonSerialized]
		public float thornsPercent;

		[NonSerialized]
		public byte invincibilityLocks;

		[NonSerialized]
		public bool isOutOfCombat;

		[NonSerialized]
		public float outOfCombatTimer;

		[NonSerialized]
		public float damageTakenModiferUncapped;

		[NonSerialized]
		public float damageTakenModifer;

		[NonSerialized]
		public float amplifyModifer;

		[NonSerialized]
		public bool isDead;

		public Dictionary<int, int> svLastPlayersWhoHit;

		public Action<EntityManager> onSelfKilled;

		public Action<EntityManager> onKilledEntity;

		public Action onHpChangedHookAction;

		public OnHitDelegate onHitAction;

		public bool isRecentlyDamaged => false;

		public byte InvincibilityLocks => 0;

		public bool IsInPlayerCombatTimer => false;

		public void PreAwake(EntityManager e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void AddInvincibilityLocks()
		{
		}

		public void RemoveInvincibilityLocks()
		{
		}

		public int GetModifiedDamage(int currentDamage, float otherCharShred)
		{
			return 0;
		}

		public void ApplyHit(int damage, StatusEffectInfo[] statusEffects = null, int otherPlayerId = -1, GameObject otherCharObj = null, bool isCrit = false, bool applyLifeSteal = true, bool applyThorns = true, bool interruptOutCombatTimer = true, bool isTrueDamage = false, Vector3 pushDir = default(Vector3), bool applyWobble = true, bool forceTriggerImmune = false, Collider collider = null)
		{
		}

		public void OnCharacterKilled(EntityManager otherCharManager, int otherPlayerId)
		{
		}

		public void Kill(int otherPlayerId = -1)
		{
		}

		public void ApplyStatusEffects(StatusEffectInfo[] statusEffects, int ownerPlayerId, Vector3 pushDir, GameObject otherChar)
		{
		}

		public void TryAggroNpc(GameObject otherChar, int otherPlayerId)
		{
		}

		public void TryApplyLifesteal(CharHurtbox otherCharState, int dealtDamage)
		{
		}

		public void TryApplyThorns(PlayerManager otherPlayerManager, GameObject otherChar, int thornDamage)
		{
		}

		public void ApplyHeal(int amount, bool spawnVfx = true, bool spawnCharPoints = true)
		{
		}

		public void ApplyHealPercent(float percent)
		{
		}

		public void ApplyHealPercentOverTime(float percent, float duration, int intervals)
		{
		}

		[IteratorStateMachine(typeof(_003CApplyHealOverTime_003Ed__74))]
		public IEnumerator ApplyHealOverTime(int totalHealAmount, float duration, int intervals)
		{
			return null;
		}

		public void ApplyShield(int tempShield)
		{
		}

		public void RemoveShield(int tempShield)
		{
		}

		public void ApplyShieldHeal(int amount, bool spawnVfx = true, bool spawnCharPoints = true)
		{
		}

		public void ApplyMaxHp(int amount)
		{
		}

		public void TriggerInCombat()
		{
		}

		public bool IsDamageFromAlly(EntityManager otherCharManager)
		{
			return false;
		}

		public void OnKilledEntity(EntityManager entityManager, EntityManager killerManager)
		{
		}

		[Server]
		public void SvSetHp(int newHp)
		{
		}

		[Server]
		public void SvSetShield(int newShield)
		{
		}

		public void SvUpdateHpShieldOnTeammates()
		{
		}

		public void SvTriggerOnHitReceived(int otherPlayerId)
		{
		}

		public void SvTriggerOnHitLanded(int otherPlayerId, PlayerManager otherPlayer)
		{
		}

		[ClientRpc]
		public void RpcSetInPlayerCombat()
		{
		}

		[ClientRpc]
		public void RpcOnHit(int oldLife, int newLife, int oldTotalLife, int newTotalLife, int fullDmg, bool isCrit, bool applyDamageFx, bool trueDamage, int otherPlayerId)
		{
		}

		public void ClOnHitPoints(int fullDmg, bool isCrit, bool trueDamage, int otherPlayerId)
		{
		}

		[ClientRpc]
		public void RpcSpawnUIPoints(int points, UIPopUp.PointType pointType, bool trueDamage)
		{
		}

		[ClientRpc]
		public void RpcSpawnHealPoints(int amount)
		{
		}

		public void SpawnUIPoints(int points, UIPopUp.PointType pointType, bool trueDamage = false)
		{
		}

		[ClientRpc]
		public void RpcWobbleHit(Vector2 direction, int damage)
		{
		}

		[ClientRpc]
		public void RpcPushHit(Vector2 direction, float duration)
		{
		}

		[ClientRpc]
		public void RpcShakeHit()
		{
		}

		[ClientRpc]
		public void RpcOnCharDestroy()
		{
		}

		public void ClOnCharDestroy()
		{
		}

		[ClientRpc]
		public void RpcSpawnDestroyVFXLastPlayer()
		{
		}

		[ClientRpc]
		public void RpcSpawnHealVFX()
		{
		}

		[ClientRpc]
		public void RpcSpawnThornsVFX()
		{
		}

		[ClientRpc]
		public void RpcSpawnExecuteVfx()
		{
		}

		[ClientRpc]
		public void RpcSpawnAirborneLandingVfx()
		{
		}

		[ClientRpc]
		public void RpcSpawnChainHitVfx()
		{
		}

		public void ClPlaySpinAnim(float duration, float time)
		{
		}

		public void ClStopSpinAnim()
		{
		}

		public void ClPlayAirborneAnim(float duration, float intensity, float time)
		{
		}

		public void ClStopAirborneAnim()
		{
		}

		public void ClPlayStunAnim()
		{
		}

		public void ClPlayKnockAnim(float duration, float intensity)
		{
		}

		public void ClPlayGrindJumpAnim()
		{
		}

		public void ClPlayGrindAnim()
		{
		}

		public void ClStopFullbodyAnim()
		{
		}

		public void OnHpShieldChanged(int hp, int maxHp, int shield, int maxShield)
		{
		}

		public void OnInvincibilityChanged()
		{
		}

		public void TriggerLowHpOverlay(int hp)
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

		public void UserCode_RpcSetInPlayerCombat()
		{
		}

		public static void InvokeUserCode_RpcSetInPlayerCombat(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnHit__Int32__Int32__Int32__Int32__Int32__Boolean__Boolean__Boolean__Int32(int oldLife, int newLife, int oldTotalLife, int newTotalLife, int fullDmg, bool isCrit, bool applyDamageFx, bool trueDamage, int otherPlayerId)
		{
		}

		public static void InvokeUserCode_RpcOnHit__Int32__Int32__Int32__Int32__Int32__Boolean__Boolean__Boolean__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnUIPoints__Int32__PointType__Boolean(int points, UIPopUp.PointType pointType, bool trueDamage)
		{
		}

		public static void InvokeUserCode_RpcSpawnUIPoints__Int32__PointType__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnHealPoints__Int32(int amount)
		{
		}

		public static void InvokeUserCode_RpcSpawnHealPoints__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcWobbleHit__Vector2__Int32(Vector2 direction, int damage)
		{
		}

		public static void InvokeUserCode_RpcWobbleHit__Vector2__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPushHit__Vector2__Single(Vector2 direction, float duration)
		{
		}

		public static void InvokeUserCode_RpcPushHit__Vector2__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcShakeHit()
		{
		}

		public static void InvokeUserCode_RpcShakeHit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnCharDestroy()
		{
		}

		public static void InvokeUserCode_RpcOnCharDestroy(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnDestroyVFXLastPlayer()
		{
		}

		public static void InvokeUserCode_RpcSpawnDestroyVFXLastPlayer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnHealVFX()
		{
		}

		public static void InvokeUserCode_RpcSpawnHealVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnThornsVFX()
		{
		}

		public static void InvokeUserCode_RpcSpawnThornsVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnExecuteVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnExecuteVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnAirborneLandingVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnAirborneLandingVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnChainHitVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnChainHitVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharHurtbox()
		{
		}
	}
}
