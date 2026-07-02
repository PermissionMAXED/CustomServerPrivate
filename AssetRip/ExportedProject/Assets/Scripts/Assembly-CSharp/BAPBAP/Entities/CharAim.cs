using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharAim : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAnimator charAnim;

		[SerializeField]
		[Header("Stats")]
		public float baseRotationSlerpValue;

		[SerializeField]
		public float baseSlowRotationSlerpValue;

		[NonSerialized]
		public byte rotationLocks;

		[NonSerialized]
		public byte rotationSlowLocks;

		[NonSerialized]
		public float additiveRotationSlerpValue;

		[NonSerialized]
		public float deltaRotY;

		[NonSerialized]
		public Vector3 lookDir;

		public void PreAwake(EntityManager e)
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void Aim(float fixedDt)
		{
		}

		public void LookAtTarget(float fixedDt, Transform target)
		{
		}

		public void LookAtPos(float fixedDt, Vector3 worldPos)
		{
		}

		public void LookAtDirection(float fixedDt, Vector3 dir)
		{
		}

		public void ForceLookAtWorldPos(Vector3 worldPos)
		{
		}

		public void ForceLookAtDirection(Vector3 dir)
		{
		}

		public void OnDeltaRotChanged(float _deltaRotY)
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
