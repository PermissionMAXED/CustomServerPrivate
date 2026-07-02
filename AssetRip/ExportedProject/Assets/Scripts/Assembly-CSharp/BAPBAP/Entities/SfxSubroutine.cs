using System;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SfxSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SfxEventAction sfxAction;

		[NonSerialized]
		public SfxTarget sfxTarget;

		[NonSerialized]
		public int sfxId;

		[NonSerialized]
		public float volume;

		[NonSerialized]
		public float pitchSpread;

		public SfxSubroutine(EntityManager entityManager, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float pitchSpread)
		{
		}

		public SfxSubroutine(EntityManager entityManager, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData)
		{
		}

		public SfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float pitchSpread)
		{
		}

		public SfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClip clip, float volume, float pitchSpread)
		{
		}

		public SfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SpawnAudio(int predTickNum, bool isResim)
		{
		}
	}
}
