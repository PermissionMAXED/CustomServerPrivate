using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using Mirror;
using PathCreation;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class GrindRail : InteractableStation, IMapEntityIndex
	{
		[Serializable]
		public class Passenger
		{
			public EntityManager entityManager;

			public bool isLerpingIn;

			public int direction;

			public float normPosInPath;

			public float currentSpeed;

			public float currentTime;

			public Passenger(EntityManager entityManager, int direction, float normPosInPath)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CClWaitInitialize_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GrindRail _003C_003E4__this;

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
			public _003CClWaitInitialize_003Ed__25(int _003C_003E1__state)
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
		[Min(0f)]
		public float speed;

		[SerializeField]
		[Min(0f)]
		public float accelerationMultiplier;

		[Min(0f)]
		[SerializeField]
		public float accelerationTime;

		[Min(0f)]
		[SerializeField]
		public float passengerLerpInDuration;

		[SerializeField]
		public float charRailHeight;

		[Header("References")]
		[SerializeField]
		public PathMeshGenerate pathMeshGenerator;

		[SerializeField]
		public MeshCollider obstacleMeshCollider;

		[SerializeField]
		public Transform interactableCollidersHolder;

		[SerializeField]
		public PathCreator pathCreator;

		[Header("Vertex Path")]
		[SerializeField]
		public float colliderMaxAngleError;

		[SerializeField]
		public float colliderMinVertexSpacing;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData grindStartSfx;

		[SerializeField]
		public AudioClipData grindEndSfx;

		[SerializeField]
		[Header("Translation Keys")]
		public string grindTranslationKey;

		[SerializeField]
		public string exitTranslationKey;

		[NonSerialized]
		public string grindStr;

		[NonSerialized]
		public string exitStr;

		[NonSerialized]
		public VertexPath vertexPath;

		[NonSerialized]
		public bool isLooping;

		[NonSerialized]
		public List<Passenger> passengers;

		[SyncVar]
		[NonSerialized]
		public int mapEntityIndex;

		public int NetworkmapEntityIndex
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public void SetMapEntityIndex(int index)
		{
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CClWaitInitialize_003Ed__25))]
		public IEnumerator ClWaitInitialize()
		{
			return null;
		}

		public void InitializeGrindRail()
		{
		}

		public void BuildGrindRail()
		{
		}

		public void BuildCollisionMesh()
		{
		}

		public void BuildInteractMesh()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public void UIShowMountWindow(InteractableCollider slot, EntityManager entity)
		{
		}

		public void UIShowDismountWindow(InteractableCollider slot, EntityManager entity)
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

		public void AssignPassenger(EntityManager entity, bool doLerpIn = true)
		{
		}

		public void RemovePassenger(EntityManager entity)
		{
		}

		public void AssignCharInRail(EntityManager entity)
		{
		}

		public void RemoveCharInRail(EntityManager entity)
		{
		}

		public void FixedUpdate()
		{
		}

		[Server]
		public void MovePassengerInPath(Passenger passenger)
		{
		}

		public bool IsPassenger(EntityManager entity)
		{
			return false;
		}

		public bool TryGetPassenger(EntityManager entity, out Passenger passenger)
		{
			passenger = null;
			return false;
		}

		public Vector3 GetCharDropPos(EntityManager entity)
		{
			return default(Vector3);
		}

		public Vector3 GetWorldPosAtNormPathPos(float normTime)
		{
			return default(Vector3);
		}

		public Vector3 GetNormalAtNormPathPos(float normTime)
		{
			return default(Vector3);
		}

		[ClientRpc]
		public void RpcOnEntityAssigned(EntityManager entity)
		{
		}

		[ClientRpc]
		public void RpcOnEntityFinishLerpIn(EntityManager entity)
		{
		}

		[ClientRpc]
		public void RpcOnEntityRemoved(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnEntityAssigned__EntityManager(EntityManager entity)
		{
		}

		public static void InvokeUserCode_RpcOnEntityAssigned__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnEntityFinishLerpIn__EntityManager(EntityManager entity)
		{
		}

		public static void InvokeUserCode_RpcOnEntityFinishLerpIn__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnEntityRemoved__EntityManager(EntityManager entity)
		{
		}

		public static void InvokeUserCode_RpcOnEntityRemoved__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GrindRail()
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
