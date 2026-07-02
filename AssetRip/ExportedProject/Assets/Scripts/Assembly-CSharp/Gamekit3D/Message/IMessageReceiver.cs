namespace Gamekit3D.Message
{
	public interface IMessageReceiver
	{
		void OnReceiveMessage(MessageType type, object sender, object msg);
	}
}
