using System;
using BAPBAP.Local;
using BAPBAP.Network.EventData;

namespace BAPBAP.Entities
{
	public class SfxDelayedSubroutine : SfxSubroutine
	{
		[NonSerialized]
		public float delay;

		[NonSerialized]
		public float elapsedTime;

		public SfxDelayedSubroutine(EntityManager entityManager, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData, float delay)
			: base((EntityManager)null, default(SfxEventAction), default(SfxTarget), 0, 0f, 0f)
		{
		}

		public SfxDelayedSubroutine(Ability abiltiy, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float randomPitch, float delay)
			: base((EntityManager)null, default(SfxEventAction), default(SfxTarget), 0, 0f, 0f)
		{
		}

		public SfxDelayedSubroutine(EntityManager entityManager, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float randomPitch, float delay)
			: base((EntityManager)null, default(SfxEventAction), default(SfxTarget), 0, 0f, 0f)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
