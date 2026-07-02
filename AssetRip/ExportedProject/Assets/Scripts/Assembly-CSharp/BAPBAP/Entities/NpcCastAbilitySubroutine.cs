using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class NpcCastAbilitySubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public bool firstFrame;

		[NonSerialized]
		public float aimRotationSpeed;

		[NonSerialized]
		public float extraCd;

		[NonSerialized]
		public CastFlags castFlag;

		public NpcCastAbilitySubroutine(NpcBehaviour _npcBehaviour, AbilityTriggerData abilityData, byte _trigger, float _aimRotationSpeed = -2f)
		{
		}

		public NpcCastAbilitySubroutine(NpcBehaviour _npcBehaviour, Ability _ability, byte _trigger, float _extraCd = 0f, float _aimRotationSpeed = -2f)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
