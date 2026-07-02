using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class P_RemovePassive : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Passive passive;

		public P_RemovePassive(Passive passive)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
