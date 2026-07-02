using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class WaitForInputSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public byte buttonUpTrigger;

		[NonSerialized]
		public InputType inputType;

		[NonSerialized]
		public CastFlags blockedCastFlags;

		[NonSerialized]
		public InputSource inputSource;

		public WaitForInputSubroutine(Ability ability, byte trigger, InputType inputType, CastFlags blockedCastFlags = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4, InputSource inputSource = InputSource.Any, byte buttonUpTrigger = 0)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual bool IsAbleToCast(CastFlags blockedCastFlags)
		{
			return false;
		}
	}
}
