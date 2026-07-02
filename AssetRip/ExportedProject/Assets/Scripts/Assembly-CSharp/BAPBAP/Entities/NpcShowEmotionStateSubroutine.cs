using System;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;

namespace BAPBAP.Entities
{
	public class NpcShowEmotionStateSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public bool onEnter;

		[NonSerialized]
		public UIManager.EmotionState state;

		public NpcShowEmotionStateSubroutine(NpcBehaviour _behaviour, bool _onEnter, UIManager.EmotionState _state)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
