using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharTriggerbox : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[Tooltip("Allow this entity to be detected on other listeners. If false, this entity will be ignored by other listeners, and it will only be able to listen.")]
		[SerializeField]
		[Header("Config")]
		public bool isListeneable;

		[NonSerialized]
		public List<IEntityTriggerboxListener> triggerBoxListeners;

		[NonSerialized]
		public List<IEntityTriggerboxListener> tempCopy;

		[NonSerialized]
		public byte triggerLocks;

		public List<IEntityTriggerboxListener> TriggerBoxListeners => null;

		public byte TriggerLocks => 0;

		public bool IsTriggerLocked => false;

		public void PreAwake(EntityManager _entity)
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void OnDisable()
		{
		}

		public void AddTriggerLocks()
		{
		}

		public void RemoveTriggerLocks()
		{
		}

		public void NotifyListeners()
		{
		}

		public void AddColStateListener(IEntityTriggerboxListener listener)
		{
		}

		public void RemoveColStateListener(IEntityTriggerboxListener listener)
		{
		}

		public void OnTriggerLocksChanged()
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
