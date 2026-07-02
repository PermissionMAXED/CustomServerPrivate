using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateLocalSfx : EntityActivateBase
	{
		[SerializeField]
		public AudioSource aS;

		[SerializeField]
		public float distanceToPlay;

		[SerializeField]
		public bool onlyPlayOnce;

		[NonSerialized]
		public bool hasPlayedOnce;

		public override void Activate()
		{
		}

		[ClientCallback]
		public void ClPlayAudio()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
