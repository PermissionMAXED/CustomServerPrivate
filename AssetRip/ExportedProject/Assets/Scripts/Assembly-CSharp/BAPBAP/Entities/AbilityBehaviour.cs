using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AbilityBehaviour
	{
		[Serializable]
		public class AbilityBehaviourConfig
		{
			[Header("Ability Config")]
			public InputType inputType;

			public bool silenceable;

			public bool cancelable;

			public bool usableWhileDowned;
		}

		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public AbilityBehaviourConfig abilityConfig;

		public SimulationFsm fsm;

		[NonSerialized]
		public byte stateId;

		[NonSerialized]
		public byte triggerId;

		[NonSerialized]
		public byte TRIGGER_FORCEINTERRUPT_EXT;

		[NonSerialized]
		public int itemId;

		[NonSerialized]
		public CastFlags consumableCastFlags;

		[NonSerialized]
		public CastFlags otherConsumableCastFlags;

		public virtual void Build(Ability ability, int itemId)
		{
		}

		public virtual void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnStart()
		{
		}

		public virtual void OnDeactivate()
		{
		}

		public virtual void ClStartAuth()
		{
		}

		public virtual void ClStopAuth()
		{
		}

		public float GetCooldownTimeElapsed()
		{
			return 0f;
		}

		public float GetCooldownTime()
		{
			return 0f;
		}

		public virtual bool OnStopItemRemove()
		{
			return false;
		}

		public virtual void ClSpawnVisibleIndicator(Vector3 worldPos)
		{
		}

		public virtual void ClDestroyVisibleIndicator()
		{
		}

		public virtual void OnTargetHit(EntityManager otherCharManager, HitboxBase hitbox)
		{
		}

		public virtual void OnHitboxDestroy(HitboxBase hitboxBase)
		{
		}

		public virtual void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public virtual void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public virtual bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public virtual void OnNetDebugLog(StringBuilder sb)
		{
		}
	}
}
