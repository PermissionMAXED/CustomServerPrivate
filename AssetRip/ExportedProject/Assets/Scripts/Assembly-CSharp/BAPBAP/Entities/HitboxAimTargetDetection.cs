using System;
using System.Runtime.InteropServices;
using BAPBAP.Entities.TargetDetection;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxAimTargetDetection : BAPBAP.Entities.TargetDetection.TargetDetection
	{
		[NonSerialized]
		public HitboxBase hitbox;

		[NonSerialized]
		public ProjectileMove projectileMove;

		[SerializeField]
		[Header("Hitbox Aim References")]
		public SpriteRenderer indicatorArea;

		[SerializeField]
		public AudioSource audioSource;

		[Header("Settings")]
		[SerializeField]
		public float turningSpeed;

		[SerializeField]
		public bool gainSpeedWhenFoundTarget;

		[SerializeField]
		public float speedWhenFound;

		[SerializeField]
		public bool aimTowardsWhenTargetFound;

		[SerializeField]
		public Color targetFoundIndicatorColor;

		[SyncVar(hook = "OnIsDestroyedChanged")]
		[NonSerialized]
		public bool isDestroyed;

		[NonSerialized]
		public Transform positionIfNoTarget;

		[NonSerialized]
		public bool goToPositionIfNoTarget;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isDestroyed;

		public bool NetworkisDestroyed
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

		public override void OnStartClient()
		{
		}

		public override void OnStartServer()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		public override void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void TickOnTargetFound()
		{
		}

		public void TickGoToPosition()
		{
		}

		public void DisableSearchArea()
		{
		}

		public override void OnIsSearchingChanged(bool newValue)
		{
		}

		public void OnIsDestroyedChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
