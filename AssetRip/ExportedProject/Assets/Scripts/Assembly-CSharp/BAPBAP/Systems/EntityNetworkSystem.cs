using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class EntityNetworkSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<CharNetwork> components;

		[NonSerialized]
		public Stack<NetworkWriter> stateWriters;

		[NonSerialized]
		public Stack<NetworkWriter> eventWriters;

		[NonSerialized]
		public Dictionary<int, NetworkWriter> stateWritersByConnection;

		[NonSerialized]
		public Dictionary<int, NetworkWriter> eventWritersByConnection;

		[NonSerialized]
		public NetworkWriter zrleWriter;

		[NonSerialized]
		public Dictionary<uint, CharNetwork> charNetCache;

		public void Awake()
		{
		}

		public void Register(CharNetwork charNetwork)
		{
		}

		public void Unregister(CharNetwork charNetwork)
		{
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void OnClientConnect()
		{
		}

		public void OnClientDisconnect()
		{
		}

		public void OnStartServer()
		{
		}

		public void OnStopServer()
		{
		}

		public void OnTargetStateSync(StateSyncMessage msg)
		{
		}

		public void NetworkEarlyUpdate()
		{
		}
	}
}
