using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AnimAlternationSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public int stateHash1;

		[NonSerialized]
		public int stateHash2;

		[NonSerialized]
		public int currentAnimId;

		public AnimAlternationSubroutine(Ability ability, AnimAction action, string animState, AnimLayerIndices animLayer)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
