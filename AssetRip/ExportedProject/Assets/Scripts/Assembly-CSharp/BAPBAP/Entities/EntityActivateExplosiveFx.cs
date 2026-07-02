using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateExplosiveFx : EntityActivateBase
	{
		[NonSerialized]
		public CharMaterial charMaterial;

		[SerializeField]
		[Header("Settings")]
		public Color tintColor;

		[SerializeField]
		public AnimationCurve colorIntensityCurve;

		[SerializeField]
		public AnimationCurve scaleCurve;

		[SerializeField]
		public Vector3 scaleMult;

		[Min(0f)]
		[SerializeField]
		public float duration;

		[NonSerialized]
		public bool isAnimating;

		[NonSerialized]
		public float animTimer;

		public override void Awake()
		{
		}

		public override void Activate()
		{
		}

		public void Update()
		{
		}

		public void Animate(float nt)
		{
		}

		public void ClOnLockedChanged()
		{
		}

		[ClientRpc]
		public void RpcPlay()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlay()
		{
		}

		public static void InvokeUserCode_RpcPlay(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateExplosiveFx()
		{
		}
	}
}
