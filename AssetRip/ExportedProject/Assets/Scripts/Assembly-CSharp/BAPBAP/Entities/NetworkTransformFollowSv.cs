using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NetworkTransformFollowSv : NetworkBehaviour
	{
		public bool isFollowForward;

		public Transform followTarget;

		public Vector3 localOffset;

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		[ServerCallback]
		public void OnEnable()
		{
		}

		public void UpdateTransform()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
