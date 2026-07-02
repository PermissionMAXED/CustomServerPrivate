using BAPBAP.Local;

namespace BAPBAP.Entities
{
	public static class CastFlagsHelper
	{
		public const CastFlags castFlagsAll = CastFlags.Ability8 | CastFlags.Ability1 | CastFlags.Ability2;

		public const CastFlags castFlagsAllNoConsumable = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4;

		public static CastFlags GetCastFlagByAbility(CommandId cmdId)
		{
			return default(CastFlags);
		}

		public static bool IsAnyActive(CastFlags flags, CastFlags flagMask)
		{
			return false;
		}
	}
}
