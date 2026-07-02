using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class SecretRock : NetworkBehaviour
	{
		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[SerializeField]
		[Header("Properties")]
		public AudioSource completeAudioSource;

		[SerializeField]
		public Transform speechBubblePivot;

		[SerializeField]
		[Header("References")]
		public GameObject completionVfxPrefab;

		[SerializeField]
		[Header("Config")]
		public int hpAmount;

		[Header("Strings")]
		[SerializeField]
		public string foundStr;

		[SyncVar]
		[NonSerialized]
		public bool found;

		[NonSerialized]
		public List<int> chars;

		public bool Networkfound
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

		public void OnEnter(EntityManager entityManager)
		{
		}

		public void OnExit(EntityManager entityManager)
		{
		}

		public void FoundRock(EntityManager entityManager)
		{
		}

		public void ClShowFoundWindow()
		{
		}

		[ClientRpc]
		public void RpcFound(EntityManager entityManager)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcFound__EntityManager(EntityManager entityManager)
		{
		}

		public static void InvokeUserCode_RpcFound__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SecretRock()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
