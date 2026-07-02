using System;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Utilities;

namespace BAPBAP.Entities
{
	public class NpcAbilityTriggerSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public float updateRate;

		[NonSerialized]
		public RangeFloat triggerDistRangeSqr;

		[NonSerialized]
		public float minAngleDifference;

		[NonSerialized]
		public bool needsLineOfSight;

		[NonSerialized]
		public float randomChanceNorm;

		[NonSerialized]
		public float randomChanceRate;

		[NonSerialized]
		public float updateTimer;

		[NonSerialized]
		public float randomChanceTimer;

		public NpcAbilityTriggerSubroutine(NpcBehaviour _npcBehaviour, byte _trigger, AbilityTriggerData abData, float updateRateAdded = 0f)
		{
		}

		public NpcAbilityTriggerSubroutine(NpcBehaviour _npcBehaviour, Ability _ability, byte _trigger, RangeFloat _triggerDistRange, float _minAngleDifference, bool _needsLineOfSight = true, float _randomChanceNorm = 0f, float _randomChanceRate = 0f, float _updateRate = 0f)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
