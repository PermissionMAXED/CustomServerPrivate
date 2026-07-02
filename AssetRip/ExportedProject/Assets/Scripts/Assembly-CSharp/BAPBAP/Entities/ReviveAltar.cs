using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class ReviveAltar : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CPlayRingInterruptAnim_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ReviveAltar _003C_003E4__this;

			public float ringFailedProgress;

			[NonSerialized]
			public float _003Ctimer_003E5__2;

			[NonSerialized]
			public Color _003Cc_003E5__3;

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
			public _003CPlayRingInterruptAnim_003Ed__54(int _003C_003E1__state)
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
		public GameManager gameManager;

		[NonSerialized]
		public PingableEntity pingableEntity;

		[NonSerialized]
		public UIInteractableTooltip uiWindow;

		[NonSerialized]
		public EntityTriggerboxListener entityTriggerboxListener;

		[Header("References")]
		[SerializeField]
		public ItemDrops itemDrops;

		[SerializeField]
		public Transform spawnPoint;

		[SerializeField]
		public MeshRenderer meshRenderer;

		[Header("Settings")]
		[Tooltip("How much to wait to finish the revive")]
		[SerializeField]
		public float reviveDuration;

		[Tooltip("When the reviving player gets interrupted, how much to wait in cooldown before starting again")]
		[SerializeField]
		public float cooldownDuration;

		[SerializeField]
		public Sprite spriteIcon;

		[SerializeField]
		[Tooltip("When respawning the players, spawn them in a random radius of this length")]
		public float spawnPosRadius;

		[SerializeField]
		public int reviveUseCount;

		[Header("SFX")]
		[SerializeField]
		public AudioSource progressAudioSource;

		[SerializeField]
		public AudioFade progressAudioFade;

		[SerializeField]
		public AudioSource activeAmbientAudioSource;

		[SerializeField]
		public CharVoicelineConfig voiceline;

		[Header("VFX")]
		[SerializeField]
		public ReviveAltarProximity respawnProximity;

		[SerializeField]
		[Tooltip("Plays while the revive is being in progress")]
		public ParticleSystem reviveProgressVfx;

		[Tooltip("Plays when the revive was finished")]
		[SerializeField]
		public ParticleSystem reviveSuccessVfx;

		[Tooltip("Plays when the revive failed successfully")]
		[SerializeField]
		public ParticleSystem reviveFailVfx;

		[Tooltip("Sets object visibility based on revive status")]
		[SerializeField]
		public GameObject activeObj;

		[Header("Ring FX")]
		[SerializeField]
		public SpriteRenderer ringRenderer;

		[SerializeField]
		public Color ringColor;

		[SerializeField]
		public Color ringInterruptColor;

		[SerializeField]
		public float interruptRingAnimTime;

		[Range(0f, 360f)]
		[SerializeField]
		public float ringFullLengthDegrees;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public float ringFullLengthNorm;

		[NonSerialized]
		public string reviveStr;

		[NonSerialized]
		public string noReviveStr;

		[NonSerialized]
		public EntityManager reviverCharManager;

		[NonSerialized]
		public List<EntityManager> charInside;

		[NonSerialized]
		public int uses;

		[SyncVar(hook = "OnRespawnTimerChanged")]
		[NonSerialized]
		public float reviveTimer;

		[NonSerialized]
		[SyncVar(hook = "OnIsActiveChanged")]
		public bool isActive;

		public Action<float, float> _Mirror_SyncVarHookDelegate_reviveTimer;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isActive;

		public float NetworkreviveTimer
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkisActive
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public void OnEnter(EntityManager entityManager)
		{
		}

		public void OnExit(EntityManager entityManager)
		{
		}

		public void OnRespawnEnter(EntityManager entityManager)
		{
		}

		public void OnRespawnExit(EntityManager entityManager)
		{
		}

		public void OnUpdateCurrentReviver()
		{
		}

		public void FindNewReviver()
		{
		}

		public void SetNewReviverChar(EntityManager newReviver)
		{
		}

		public void RemoveAndInterruptCurrentReviver()
		{
		}

		public void InterruptRevive()
		{
		}

		public void OnReviveSuccess()
		{
		}

		public void CheckActive()
		{
		}

		public void ReviveTeammates(EntityManager otherManager)
		{
		}

		[Server]
		public void SetReviveActiveClients(bool reviveIsActive)
		{
		}

		public void ShowUI(bool doShow)
		{
		}

		[ClientRpc]
		public void RpcOnReviveSuccess()
		{
		}

		[ClientRpc]
		public void RpcOnReviveFail(float failedProgressPercentage)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayRingInterruptAnim_003Ed__54))]
		public IEnumerator PlayRingInterruptAnim(float ringFailedProgress)
		{
			return null;
		}

		public void PlayReviveProgressVfx()
		{
		}

		public void StopReviveProgressVfx()
		{
		}

		public void PlayReviveProgressSfx(float time)
		{
		}

		public void StopReviveProgressSfx()
		{
		}

		public void SetRingColor(Color color)
		{
		}

		public void SetProgressRing(float percentage)
		{
		}

		public void OnRespawnTimerChanged(float oldValue, float newValue)
		{
		}

		public void OnIsActiveChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnReviveSuccess()
		{
		}

		public static void InvokeUserCode_RpcOnReviveSuccess(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnReviveFail__Single(float failedProgressPercentage)
		{
		}

		public static void InvokeUserCode_RpcOnReviveFail__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ReviveAltar()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
