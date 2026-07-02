using System;
using BAPBAP.Local;

namespace BAPBAP.Entities
{
	public class WaitForInputOverrideSubroutine : WaitForInputSubroutine
	{
		[NonSerialized]
		public bool checkForSilenced;

		public WaitForInputOverrideSubroutine(Ability ability, byte trigger, InputType inputType, CastFlags blockedCastFlags = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4, InputSource inputSource = InputSource.Any, byte buttonUpTrigger = 0, bool checkForSilenced = true)
			: base(null, 0, default(InputType), default(CastFlags), default(InputSource), 0)
		{
		}

		public override bool IsAbleToCast(CastFlags blockedCastFlags)
		{
			return false;
		}
	}
}
