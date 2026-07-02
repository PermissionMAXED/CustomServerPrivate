using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharSimulation : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharInterpolator charInterpolator;

		[SerializeField]
		[Header("Debug")]
		public bool logSimOrder;

		[NonSerialized]
		public INetworkPredicted[] netComps;

		[NonSerialized]
		public Collider[] physResimCastResults;

		[NonSerialized]
		public List<IPhysicsResimulated> physResimStay;

		[NonSerialized]
		public List<IPhysicsResimulated> newPhysTemp;

		[NonSerialized]
		public Command currentCmd;

		[NonSerialized]
		public int predTickNum;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void Tick(float fixedDt, Command cmd, bool isResim = false)
		{
		}

		public void PhysSimulation(float fixedDt)
		{
		}

		public void OnNetDeserialize(NetworkReader netReader, int remoteTickNum)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(byte[] state)
		{
			return false;
		}

		public string OnNetDebugLog()
		{
			return null;
		}
	}
}
