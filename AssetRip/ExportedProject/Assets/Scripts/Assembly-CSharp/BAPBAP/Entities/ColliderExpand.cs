using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ColliderExpand : NetworkBehaviour
	{
		[SerializeField]
		public BoxCollider col;

		[SerializeField]
		public AnimationCurve speedCurve;

		[SyncVar]
		public float expandDuration;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public Vector3 startScale;

		[SyncVar]
		public Vector3 targetScale;

		[NonSerialized]
		public bool stop;

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

		public Vector3 NetworktargetScale
		{
			get
			{
				return default(Vector3);
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void StartFromZero()
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
