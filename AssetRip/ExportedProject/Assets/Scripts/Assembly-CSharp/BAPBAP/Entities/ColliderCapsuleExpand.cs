using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ColliderCapsuleExpand : NetworkBehaviour
	{
		[SerializeField]
		public CapsuleCollider col;

		[SerializeField]
		public AnimationCurve speedCurve;

		[NonSerialized]
		[SyncVar]
		public float expandDuration;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public float startScale;

		[NonSerialized]
		[SyncVar]
		public float targetRadius;

		public float NetworkexpandDuration
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

		public float NetworktargetRadius
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

		public void Start()
		{
		}

		public void OnEnable()
		{
		}

		public void FixedUpdate()
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
