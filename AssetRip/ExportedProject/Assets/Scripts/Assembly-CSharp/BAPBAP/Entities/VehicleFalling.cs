using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(Vehicle))]
	public class VehicleFalling : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public Vehicle vehicle;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public Rigidbody rb;

		[Header("Config")]
		[SerializeField]
		public float fallDuration;

		[SerializeField]
		public float fallDirectionForce;

		[SerializeField]
		public float fallRotationForce;

		[SerializeField]
		public float navSampleRadius;

		[NonSerialized]
		public bool falling;

		[NonSerialized]
		public Vector3 fallDirection;

		[NonSerialized]
		public Vector3 fallRotationAxis;

		[NonSerialized]
		public float fallTime;

		public void Awake()
		{
		}

		public virtual void OnTick(float fixedDt, Command cmd, bool isResim)
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
