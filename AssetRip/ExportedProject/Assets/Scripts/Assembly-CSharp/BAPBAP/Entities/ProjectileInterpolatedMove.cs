using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ProjectileInterpolatedMove : NetworkBehaviour
	{
		[NonSerialized]
		public HitboxBase hitbox;

		[SerializeField]
		public AnimationCurve speedCurve;

		[NonSerialized]
		public AnimationCurve heightCurve;

		[NonSerialized]
		public Vector3 startPos;

		[NonSerialized]
		public Vector3 endPos;

		[NonSerialized]
		public float interpolationDuration;

		[NonSerialized]
		public float yHeightAmount;

		[NonSerialized]
		public bool ignoreHeightCurve;

		[NonSerialized]
		public float time;

		public void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
