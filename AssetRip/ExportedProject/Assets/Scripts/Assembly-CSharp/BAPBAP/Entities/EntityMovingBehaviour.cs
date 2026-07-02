using System;
using BAPBAP.Local;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class EntityMovingBehaviour : NetworkBehaviour, IEntityDataProperty
	{
		[NonSerialized]
		public EntityBehaviour entityBehav;

		[ExHeader("\ud83d\udee0 [PROPERTIES] \ud83d\udee0", 0f, 1f, 1f)]
		[SerializeField]
		public float distanceForward;

		[SerializeField]
		public float timeToTransit;

		[SerializeField]
		[Header("Settings")]
		public float transitCooldown;

		[SerializeField]
		public AnimationCurve transitCurve;

		[SerializeField]
		public float startDelay;

		[Header("FX")]
		[SerializeField]
		public AudioSource audioSource;

		[SerializeField]
		public AudioClipData startClip;

		[SerializeField]
		public AudioClipData stopClip;

		[NonSerialized]
		public Vector3 targetPosition;

		[NonSerialized]
		public Vector3 originPosition;

		[NonSerialized]
		public Vector3 currentStartingPosition;

		[NonSerialized]
		public Vector3 currentTargetPosition;

		[NonSerialized]
		public bool coolingDown;

		[NonSerialized]
		public bool inTransit;

		[NonSerialized]
		public bool inReverse;

		[NonSerialized]
		public bool usingStartDelay;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool editor;

		public static bool Debug;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void FixedUpdate()
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

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
