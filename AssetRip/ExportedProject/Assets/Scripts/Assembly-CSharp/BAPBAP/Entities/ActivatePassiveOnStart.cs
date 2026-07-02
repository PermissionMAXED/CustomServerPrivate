using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ActivatePassiveOnStart : NetworkBehaviour
	{
		[SerializeField]
		public List<PassiveSO> passives;

		[NonSerialized]
		public CharPassives charPassives;

		public void Start()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
