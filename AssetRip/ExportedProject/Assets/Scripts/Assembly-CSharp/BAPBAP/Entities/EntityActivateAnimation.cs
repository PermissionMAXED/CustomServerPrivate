using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateAnimation : EntityActivateBase
	{
		[SerializeField]
		public Animator animator;

		[SerializeField]
		public string activateString;

		[SerializeField]
		public string triggerString;

		[SerializeField]
		public float crossFadeDuration;

		[SerializeField]
		public bool loop;

		[ConditionalHide("loop", true)]
		[SerializeField]
		public float loopAnimTime;

		[NonSerialized]
		public int triggerId;

		[NonSerialized]
		public int activateStateHash;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool done;

		public void Start()
		{
		}

		[ServerCallback]
		public override void Activate()
		{
		}

		[ClientCallback]
		public void FixedUpdate()
		{
		}

		public void ClLockedChanged()
		{
		}

		[ClientRpc]
		public void RpcActivate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcActivate()
		{
		}

		public static void InvokeUserCode_RpcActivate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateAnimation()
		{
		}
	}
}
