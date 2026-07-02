using BAPBAP.Local;

namespace BAPBAP.Network
{
	public class SimulationSubroutine
	{
		public virtual void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public virtual void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void DeBuild()
		{
		}
	}
}
