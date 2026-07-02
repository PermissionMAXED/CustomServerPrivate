using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class SfxRandomSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SfxTarget sfxTarget;

		[NonSerialized]
		public RandomAudioClipPool clipPool;

		[NonSerialized]
		public int poolLength;

		[NonSerialized]
		public int[] sfxIdByIndex;

		[NonSerialized]
		public int lastIndex;

		[NonSerialized]
		public bool anyCooldownActive;

		[NonSerialized]
		public double lastFixedTime;

		public SfxRandomSubroutine(EntityManager entityManager, SfxTarget sfxTarget, RandomAudioClipPool clipPool)
		{
		}

		public SfxRandomSubroutine(Ability ability, SfxTarget sfxTarget, RandomAudioClipPool randomClipPool)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void TickCd(float fixedDt)
		{
		}

		public int GetClipDataIndex(int predTickNum)
		{
			return 0;
		}

		public int GetRandomIndex(int predTickNum)
		{
			return 0;
		}

		public int GetCurrentSfxId()
		{
			return 0;
		}
	}
}
