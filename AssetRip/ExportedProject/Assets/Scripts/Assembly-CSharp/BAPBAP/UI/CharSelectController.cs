using System;
using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class CharSelectController : ControllerBase
	{
		[Serializable]
		public class Config
		{
			public int DefaultCharacterId;
		}

		[NonSerialized]
		public readonly Config _config;

		public const string CHAR_ID_KEY = "CHAR_ID";

		public int CharacterId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public CharSelectController(Config config, ControllerManager controllerManager)
			: base(null)
		{
		}

		public void SwitchCharacter(int id)
		{
		}

		public void LockCharacter()
		{
		}

		public void SendSwitchCharacterMessage(int id)
		{
		}

		public void SendLockCharacterMessage()
		{
		}

		public void HandleSwitchCharacterSuccessMessage(SwitchCharacterSuccessMessage message)
		{
		}

		public void HandleSwitchCharacterFailMessage(SwitchCharacterFailMessage message)
		{
		}

		public void HandleCharacterUpdatedMessage(CharacterUpdatedMessage message)
		{
		}

		public void HandleCharacterUpdatedMatchmakingMessage(CharacterUpdatedMatchmakingMessage message)
		{
		}

		public void HandleLockedCharacterSuccessMessage(LockedCharacterSuccessMatchmakingMessage message)
		{
		}

		public void HandleLockedCharUpdatedMatchmakingMessage(LockedCharacterUpdatedMatchmakingMessage message)
		{
		}

		public void HandleUpdateAvailableCharacterList(int[] availableCharacters, bool forceUpdate)
		{
		}
	}
}
