using System;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class InteractableStation : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public UIInteractableWindows uiInteractableWindows;

		[Header("References")]
		[SerializeField]
		public InteractableCollider[] iSlots;

		[SerializeField]
		public Transform uiWindowPivot;

		[Header("Settings")]
		[Tooltip("The priority for selecting this interactable. Higher priority numbers will be selected first.")]
		[SerializeField]
		public int interactablePriority;

		[SerializeField]
		public float interactCastDuration;

		[SerializeField]
		public Sprite spriteIcon;

		[SerializeField]
		public ItemTiers spriteTierColor;

		[Header("View FX")]
		[SerializeField]
		public GameObject successVfxPrefab;

		[SerializeField]
		public AudioSource failAudioSource;

		[SerializeField]
		public AudioPlayRandom failAudioPlay;

		[SerializeField]
		public AudioPlayRandom successAudioPlay;

		[Header("FX")]
		[SerializeField]
		public AudioSource completeAudioSource;

		[SerializeField]
		public float randomPitchSpread;

		[SerializeField]
		[Header("Voicelines")]
		public CharVoicelineConfig voicelineUse;

		[SerializeField]
		public CharVoicelineConfig voicelineSuccess;

		[SerializeField]
		public CharVoicelineConfig voicelineFail;

		[SyncVar(hook = "OnActiveChanged")]
		[NonSerialized]
		public bool active;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_active;

		public UIInteractableTooltip uiWindow => null;

		public bool Networkactive
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

		public virtual void Awake()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void OnSlotEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public virtual void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		[Server]
		public virtual void OnSlotInteract(EntityManager entity, InteractableCollider slot)
		{
		}

		public virtual void ClOnForceUpdate(EntityManager entity, InteractableCollider slot)
		{
		}

		public virtual void OnLocalAuthPlayerChanged(EntityManager entity, InteractableCollider slot)
		{
		}

		public virtual void OnCastingStarted(EntityManager entity, int slotId)
		{
		}

		public virtual void OnCastingCompleted(EntityManager entity, int slotId)
		{
		}

		public void OnCastingUpdate(float normFactor)
		{
		}

		public virtual void OnCastingCanceled(EntityManager entity, int slotId)
		{
		}

		public virtual bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public virtual bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public virtual void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public virtual void ClOnExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public void TryUpdateCurrentInteractable(int slotId = 0)
		{
		}

		public void TryExitCurrentInteractable(int slotId = 0)
		{
		}

		[ClientRpc]
		public virtual void RpcOnUseCastingStart(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public virtual void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public virtual void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		public virtual void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public virtual void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public virtual void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public void UISetCastingProgress(float normFactor)
		{
		}

		public void UIStopCastingProgress()
		{
		}

		public virtual void OnActiveChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public virtual void UserCode_RpcOnUseCastingStart__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public static void InvokeUserCode_RpcOnUseCastingStart__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public virtual void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public virtual void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static InteractableStation()
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
