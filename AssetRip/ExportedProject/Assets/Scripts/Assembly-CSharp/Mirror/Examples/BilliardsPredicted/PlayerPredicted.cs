using System;
using UnityEngine;

namespace Mirror.Examples.BilliardsPredicted
{
	public class PlayerPredicted : NetworkBehaviour
	{
		[NonSerialized]
		public WhiteBallPredicted whiteBall;

		public void Awake()
		{
		}

		public void ApplyForceToWhite(Vector3 force)
		{
		}

		public void OnDraggedBall(Vector3 force)
		{
		}

		public bool IsValidMove(Vector3 force)
		{
			return false;
		}

		[Command]
		public void CmdApplyForce(Vector3 force)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdApplyForce__Vector3(Vector3 force)
		{
		}

		public static void InvokeUserCode_CmdApplyForce__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerPredicted()
		{
		}
	}
}
