using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class WeaponRack_Pages : WeaponRack
	{
		[SerializeField]
		public int pagesCount;

		[SerializeField]
		public GameObject regularObj;

		[SerializeField]
		public GameObject pageEnable;

		[NonSerialized]
		public int currentPassivecount;

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		[Client]
		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
