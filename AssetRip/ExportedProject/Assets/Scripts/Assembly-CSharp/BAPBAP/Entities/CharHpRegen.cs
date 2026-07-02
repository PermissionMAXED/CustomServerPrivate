using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	public class CharHpRegen : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[Header("Stats")]
		[SerializeField]
		public float hpRegenStartAfterHit;

		[SerializeField]
		public float hpRegenInterval;

		[SerializeField]
		public int baseHpRegen;

		[SerializeField]
		[FormerlySerializedAs("baseHpRegen")]
		public int baseHpRegenOutOfCombat;

		[SerializeField]
		public int bonusHpRegen;

		[SerializeField]
		public float additiveHpRegenMultiplier;

		[SerializeField]
		public float bonusHpRegenSpeed;

		[NonSerialized]
		public int additiveHpRegen;

		[NonSerialized]
		public int additiveHpRegenOutOfCombat;

		[NonSerialized]
		public float hpRegenTimer;

		[NonSerialized]
		public float hpRegenTimerOutOfCombat;

		public void PreAwake(EntityManager e)
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void TickInCombat(float fixedDt)
		{
		}

		public void TickOutOfCombat(float fixedDt)
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
