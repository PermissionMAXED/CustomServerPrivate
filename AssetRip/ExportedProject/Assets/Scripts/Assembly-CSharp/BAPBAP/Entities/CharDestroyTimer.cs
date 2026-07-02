using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharDestroyTimer : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public float ttl;

		[SerializeField]
		public float ttlOverride;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool isAbleToDestroy;

		public void PreAwake(EntityManager e)
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void DoDestroy()
		{
		}

		public void SetAbleToDestroy(bool isEnabled)
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
