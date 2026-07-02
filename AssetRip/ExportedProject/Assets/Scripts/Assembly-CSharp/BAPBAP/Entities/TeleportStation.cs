using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class TeleportStation : InteractableStation, IEntityDataProperty
	{
		[NonSerialized]
		public EntityBehaviour entityBehaviour;

		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[SerializeField]
		public Transform windowTransform;

		[ExHeader("\ud83d\udee0 [PROPERTIES] \ud83d\udee0", 0f, 1f, 1f)]
		[ObjectPicker(typeof(TeleportStation))]
		[SerializeField]
		public TeleportStation[] recievers;

		[SerializeField]
		public bool recieverOnly;

		[SerializeField]
		public float teleportDuration;

		[SerializeField]
		public float teleportEffectTimeRatio;

		[SerializeField]
		public float teleportDelay;

		[SerializeField]
		public int cooldownTime;

		[SerializeField]
		public Renderer cooldownIndicator;

		[SerializeField]
		[Header("SFX")]
		public AudioSource progressAudioSource;

		[SerializeField]
		public AudioFade progressAudioFade;

		[SerializeField]
		public AudioSource idleAudioSource;

		[SerializeField]
		public AudioClipData sfxIdleActive;

		[SerializeField]
		public AudioClipData sfxIdleCooldown;

		[SerializeField]
		public AudioSource dropAudioSource;

		[SerializeField]
		public AudioClipData tpOther;

		[Header("VFX")]
		[SerializeField]
		public ParticleSystem tpProgressVfx;

		[SerializeField]
		public ParticleSystem tpSuccessVfx;

		[Header("Anim")]
		[SerializeField]
		public Animator animator;

		[SerializeField]
		public string tpProgressString;

		[SerializeField]
		public string tpCooldownString;

		[SerializeField]
		public string tpResetString;

		[NonSerialized]
		public string cooldownStr;

		[NonSerialized]
		public string teamStr;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[SyncVar(hook = "OnCooldownChanged")]
		[NonSerialized]
		public bool onCooldown;

		[SyncVar(hook = "OnUsedChanged")]
		[NonSerialized]
		public bool used;

		[SyncVar(hook = "OnCurrentCooldownTimerSyncChanged")]
		[NonSerialized]
		public float currentCooldownTimerSync;

		[SyncVar(hook = "OnUsedTimerChanged")]
		[NonSerialized]
		public float usedTimer;

		[NonSerialized]
		public float currentCooldownTimer;

		[NonSerialized]
		public Vector3 teleportPoint;

		[NonSerialized]
		public List<EntityManager> currentEntities;

		[NonSerialized]
		public bool dropAudioPlayed;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_onCooldown;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_used;

		public Action<float, float> _Mirror_SyncVarHookDelegate_currentCooldownTimerSync;

		public Action<float, float> _Mirror_SyncVarHookDelegate_usedTimer;

		public bool NetworkonCooldown
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

		public bool Networkused
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

		public float NetworkcurrentCooldownTimerSync
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

		public float NetworkusedTimer
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

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public override void OnSlotEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public void StartRecievingTeleport(Vector3 tpPos)
		{
		}

		public void Teleport()
		{
		}

		[Server]
		public void TeleportAllEntities()
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		[ClientRpc]
		public void RpcOnTeleportSuccess()
		{
		}

		[ClientRpc]
		public void RpcPlayDropAudio()
		{
		}

		public void SetCooldownProgressRing(float normValue)
		{
		}

		public void ClOnTeleportCanceled()
		{
		}

		public void PlayTpProgressVfx()
		{
		}

		public void StopTpProgressVfx()
		{
		}

		public void PlayTpProgressSfx(float time)
		{
		}

		public void StopTpProgressSfx()
		{
		}

		public void OnCooldownChanged(bool oldValue, bool newValue)
		{
		}

		public void OnUsedChanged(bool oldValue, bool newValue)
		{
		}

		public void OnCurrentCooldownTimerSyncChanged(float oldValue, float newValue)
		{
		}

		public void OnUsedTimerChanged(float oldValue, float newValue)
		{
		}

		public void ClLockedChanged()
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void AssignSpawnedReferences(Dictionary<int, GameObject> spawnedEntitiesByInstanceId)
		{
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnTeleportSuccess()
		{
		}

		public static void InvokeUserCode_RpcOnTeleportSuccess(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlayDropAudio()
		{
		}

		public static void InvokeUserCode_RpcPlayDropAudio(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static TeleportStation()
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
