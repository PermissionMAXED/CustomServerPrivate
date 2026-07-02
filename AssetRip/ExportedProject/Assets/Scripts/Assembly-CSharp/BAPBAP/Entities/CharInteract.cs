using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharInteract : NetworkBehaviour, INetworkPredicted, IEntityTriggerboxListener
	{
		[Serializable]
		public class CompoundEntry
		{
			public ICharInteractable interactable;

			public int count;

			public CompoundEntry(ICharInteractable interactable, int count)
			{
			}
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAim charAim;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public GameManager gameManager;

		[SerializeField]
		[Tooltip("The rate at which hovered interactables will be processed to select the closest one")]
		public float distUpdRate;

		[SerializeField]
		public bool useLookAtTargetConstraint;

		[ConditionalHide("useLookAtTargetConstraint", true)]
		[SerializeField]
		public LookAtTargetConstraint lookAtTargetConstraint;

		public List<ICharInteractable> interactablesDetected;

		[NonSerialized]
		public List<CompoundEntry> interactablesCompoundColCount;

		public ICharInteractable currentInteractable;

		[NonSerialized]
		public float distTimer;

		[NonSerialized]
		public bool isCasting;

		[NonSerialized]
		public ICharInteractable currentCastingInteractable;

		[NonSerialized]
		public float castingElapsedTime;

		[NonSerialized]
		public float castingDuration;

		[NonSerialized]
		public Action castingCompletedAction;

		[NonSerialized]
		public Action<float> castingUpdateAction;

		[NonSerialized]
		public Action castingCanceledAction;

		[NonSerialized]
		public bool autoSelectEnabled;

		[NonSerialized]
		public bool exitEnabled;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public bool _isClient;

		public bool AutoSelectEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ExitEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void PreAwake(EntityManager e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void Update()
		{
		}

		public bool IsUnableToInteract(Command cmd)
		{
			return false;
		}

		public void Interact()
		{
		}

		public void SelectCurrentInteractable()
		{
		}

		public void AssignNewInteractable(ICharInteractable newInteractable)
		{
		}

		public int GetBestHoveringInteractableIndex()
		{
			return 0;
		}

		public static bool InteractableEquals(ICharInteractable interactableA, ICharInteractable interactableB)
		{
			return false;
		}

		public bool ContainsInteractable(ICharInteractable interactable)
		{
			return false;
		}

		public bool InteractableIsInvalid(ICharInteractable interactable)
		{
			return false;
		}

		public void NotifyItemsChanged()
		{
		}

		public void ClOnForceUpdate()
		{
		}

		public void ForceCurrentInteractableEnter(ICharInteractable interactable)
		{
		}

		public void ForceCurrentInteractableExit(ICharInteractable interactable)
		{
		}

		public void ForceInteractableTriggerExit(ICharInteractable interactable)
		{
		}

		public void StartInteractCasting(ICharInteractable interactable, Action completedAction, Action<float> updateAction, Action canceledAction, float duration)
		{
		}

		public void CompleteIntractCast()
		{
		}

		public void CancelIntractCast()
		{
		}

		public void EndIntractCast()
		{
		}

		public void ClearIntract()
		{
		}

		public void ClStartCastingLerp(Action<float> updateAction, float duration)
		{
		}

		public void ClStopCastingLerp()
		{
		}

		public void OnTriggerEnter(Collider col)
		{
		}

		public void OnTriggerExit(Collider col)
		{
		}

		public void OnInteractableTriggerEnter(ICharInteractable interactable)
		{
		}

		public void OnInteractableTriggerExit(ICharInteractable interactable)
		{
		}

		public void ExitCurrentInteractable()
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
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
	}
}
