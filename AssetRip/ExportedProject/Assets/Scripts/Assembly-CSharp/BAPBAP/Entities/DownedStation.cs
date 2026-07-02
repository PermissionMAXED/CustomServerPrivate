using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DownedStation : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CWaitToDestroy_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public DownedStation _003C_003E4__this;

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
			public _003CWaitToDestroy_003Ed__33(int _003C_003E1__state)
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

		[Header("Properties")]
		[SerializeField]
		public float allyCastTime;

		[SerializeField]
		public float enemyCastTime;

		[SerializeField]
		[Header("References")]
		public Sprite enemyIcon;

		[SerializeField]
		public Sprite allyIcon;

		[SerializeField]
		public Transform windowTransform;

		[SerializeField]
		public GameObject reviveVfx;

		[SerializeField]
		public GameObject executeVfx;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxExecuteStart;

		[SerializeField]
		public AudioClipData sfxReviveStart;

		[Header("Voiceline")]
		[SerializeField]
		public CharVoicelineConfig voicelineResurrecting;

		[SerializeField]
		[Header("Localization")]
		public string executeKey;

		[SerializeField]
		public string executingKey;

		[SerializeField]
		public string reviveKey;

		[SerializeField]
		public string revivingKey;

		[NonSerialized]
		public string executeStr;

		[NonSerialized]
		public string executingStr;

		[NonSerialized]
		public string reviveStr;

		[NonSerialized]
		public string revivingStr;

		[SyncVar(hook = "OnCurrentControllingCharChanged")]
		public EntityManager currentControllingChar;

		[SyncVar(hook = "OnCharDownedChanged")]
		[NonSerialized]
		public CharDowned charDowned;

		[NonSerialized]
		public GameObject currentInteractVfx;

		[NonSerialized]
		public LayerMask obstaclesMask;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___currentControllingCharNetId;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___charDownedNetId;

		public Action<EntityManager, EntityManager> _Mirror_SyncVarHookDelegate_currentControllingChar;

		public Action<CharDowned, CharDowned> _Mirror_SyncVarHookDelegate_charDowned;

		public EntityManager NetworkcurrentControllingChar
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
		}

		public CharDowned NetworkcharDowned
		{
			get
			{
				return null;
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

		public void Initialize(CharDowned _charDowned)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnSlotEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void OnSlotInteract(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void OnCastingCanceled(EntityManager entity, int slotId)
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

		public void SvStopCastAndDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToDestroy_003Ed__33))]
		public IEnumerator WaitToDestroy()
		{
			return null;
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public bool IsAlly(EntityManager entity)
		{
			return false;
		}

		public bool HasLineOfSight(Vector3 targetPos)
		{
			return false;
		}

		[ClientRpc]
		public override void RpcOnUseCastingStart(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public void RpcOnReviveStart()
		{
		}

		[ClientRpc]
		public void RpcOnExecuteStart()
		{
		}

		[ClientRpc]
		public void RpcOnStopInteract()
		{
		}

		public void ClSpawnInteractVfx(GameObject vfxPrefab)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public void OnCurrentControllingCharChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public void OnCharDownedChanged(CharDowned oldValue, CharDowned newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseCastingStart__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseCastingStart__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnReviveStart()
		{
		}

		public static void InvokeUserCode_RpcOnReviveStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnExecuteStart()
		{
		}

		public static void InvokeUserCode_RpcOnExecuteStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnStopInteract()
		{
		}

		public static void InvokeUserCode_RpcOnStopInteract(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static DownedStation()
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
