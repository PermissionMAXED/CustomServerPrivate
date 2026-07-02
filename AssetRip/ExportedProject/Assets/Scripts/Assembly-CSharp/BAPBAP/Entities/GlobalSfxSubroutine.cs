using System;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class GlobalSfxSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public SfxEventAction sfxAction;

		[NonSerialized]
		public SfxTarget sfxTarget;

		[NonSerialized]
		public int sfxId;

		[NonSerialized]
		public float volume;

		[NonSerialized]
		public float randomPitch;

		[NonSerialized]
		public float distanceMultiplier;

		[NonSerialized]
		public float minDistAmount;

		[NonSerialized]
		public SfxTeamTarget teamTarget;

		public GlobalSfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float randomPitch, float distanceMultiplier, float minDistAmount, SfxTeamTarget teamTarget = SfxTeamTarget.All)
		{
		}

		public GlobalSfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClip clip, float volume, float randomPitch, float distanceMultiplier, float minDistAmount, SfxTeamTarget teamTarget = SfxTeamTarget.All)
		{
		}

		public GlobalSfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData, float distanceMultiplier, float minDistAmount, SfxTeamTarget teamTarget = SfxTeamTarget.All)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
