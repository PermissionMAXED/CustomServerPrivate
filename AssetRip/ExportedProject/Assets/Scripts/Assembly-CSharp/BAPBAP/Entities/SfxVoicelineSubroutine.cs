using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class SfxVoicelineSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public readonly Ability _ability;

		[NonSerialized]
		public readonly CharVoicelineConfig _config;

		[NonSerialized]
		public readonly bool _localOnly;

		public SfxVoicelineSubroutine(Ability ability, CharVoicelineConfig config, bool localOnly = false)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
