using System.Text;
using Mirror;

namespace BAPBAP.Network
{
	public interface INetworkSimulated
	{
		void Tick(float fixedDt);

		void OnNetDeserialize(NetworkReader netReader);

		void OnNetSerialize(NetworkWriter networkWriter);

		void OnNetDebugLog(StringBuilder sb);
	}
}
