using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class CastingInterruptSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public bool interruptOnDamaged;

		[NonSerialized]
		public CastFlags castFlags;

		[NonSerialized]
		public bool interruptOnTeleportLocks;

		public CastingInterruptSubroutine(Ability _ability, byte _trigger, bool _interruptOnDamaged, CastFlags _castFlags, bool _interruptOnTeleportLocks = false)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
