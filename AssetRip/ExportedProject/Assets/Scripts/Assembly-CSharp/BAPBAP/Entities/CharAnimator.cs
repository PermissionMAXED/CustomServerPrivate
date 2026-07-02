using System;
using BAPBAP.Systems;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharAnimator : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SystemManager systemManager;

		[Tooltip("Provide a custom animator reference for this entity. If unchecked, will search for any available animator component.")]
		[SerializeField]
		public bool customAnimator;

		[ConditionalHide("customAnimator", true)]
		[SerializeField]
		public Animator animator;

		[NonSerialized]
		public AnimatorOverrideController animatorOverrideController;

		[SerializeField]
		[Header("Parameter Damping")]
		public float moveDampDuration;

		[SerializeField]
		public float turnDampDuration;

		[SerializeField]
		[Header("Layer Blending")]
		public float layerBlendInValue;

		[SerializeField]
		public float layerBlendOutValue;

		[SerializeField]
		[Tooltip("How sensitive is the turning animation? (Higher values = more sensitive)")]
		[Header("Configs")]
		public float turnSensitivity;

		[NonSerialized]
		public float deltaRotY;

		[NonSerialized]
		public Vector3 moveVel;

		[NonSerialized]
		public bool isWalking;

		[NonSerialized]
		public bool isMoving;

		[NonSerialized]
		public float attackSpeed;

		[NonSerialized]
		public bool forceFullbodyAnim;

		[NonSerialized]
		public bool updateMoveParams;

		[NonSerialized]
		public float fullbodyWeight;

		[NonSerialized]
		public float idleUpperBodyWeight;

		[NonSerialized]
		public Vector3 localMove;

		[NonSerialized]
		public float moveSpeedMult;

		[NonSerialized]
		public int[] layers;

		[NonSerialized]
		public int[] paramHashes;

		[NonSerialized]
		public int stateNoneId;

		[NonSerialized]
		public int stateAirborneId;

		[NonSerialized]
		public int stateStunId;

		[NonSerialized]
		public int stateGrindId;

		[NonSerialized]
		public int stateGrindJumpId;

		[NonSerialized]
		public int stateKnockedId;

		[NonSerialized]
		public int emoteAnimId;

		[NonSerialized]
		public int animJetpackId;

		public float MoveSpeedMult
		{
			get
			{
				return 0f;
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

		public void ManagedUpdate()
		{
		}

		public bool HasState(int stateHash, AnimLayerIndices layerIndex)
		{
			return false;
		}

		public void SetMecanimState(int stateHash, AnimLayerIndices layerIndex, float normTime)
		{
		}

		public void CrossFadeMecanimState(int stateHash, AnimLayerIndices layerIndex, float time, float fadeTime)
		{
		}

		public void SetEnable(bool isEnabled)
		{
		}

		public void ResetMoveParameters()
		{
		}

		public void SetAnimatorEmoteClip(AnimationClip animationClip)
		{
		}
	}
}
