using System.Text;
using Mirror;

namespace BAPBAP.Network
{
	public class NetworkedSimulationSubroutine : SimulationSubroutine
	{
		public virtual void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public virtual void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public virtual bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public virtual void OnNetDebugLog(StringBuilder sb)
		{
		}
	}
}
