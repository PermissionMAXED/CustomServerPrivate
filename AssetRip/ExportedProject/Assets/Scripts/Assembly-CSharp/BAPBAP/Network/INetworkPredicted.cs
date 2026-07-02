using System.Text;
using BAPBAP.Local;
using Mirror;

namespace BAPBAP.Network
{
	public interface INetworkPredicted
	{
		void OnTick(float fixedDt, Command cmd, bool isResim);

		void OnNetDeserialize(NetworkReader netReader);

		void OnNetSerialize(NetworkWriter netWriter);

		bool OnNetDebugCompare(NetworkReader netReader);

		void OnNetDebugLog(StringBuilder sb);
	}
}
