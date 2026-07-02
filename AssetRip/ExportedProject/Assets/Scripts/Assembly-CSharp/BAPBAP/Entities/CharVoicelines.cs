using System;
using Mirror;

namespace BAPBAP.Entities
{
	public class CharVoicelines : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager _entity;

		public void PreAwake(EntityManager entity)
		{
		}

		public static void CallbackServer(EntityManager entity, CharVoicelineConfig config)
		{
		}

		public static void CallbackClient(EntityManager entity, CharVoicelineConfig config)
		{
		}

		public void CallbackServer(CharVoicelineConfig config)
		{
		}

		public void CallbackClient(CharVoicelineConfig config)
		{
		}

		[ClientRpc]
		public void RpcPlayVoiceLine(int id)
		{
		}

		public void PlayVoiceLine(int id)
		{
		}

		public void PlayVoiceLine(CharVoicelineConfig config)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayVoiceLine__Int32(int id)
		{
		}

		public static void InvokeUserCode_RpcPlayVoiceLine__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharVoicelines()
		{
		}
	}
}
