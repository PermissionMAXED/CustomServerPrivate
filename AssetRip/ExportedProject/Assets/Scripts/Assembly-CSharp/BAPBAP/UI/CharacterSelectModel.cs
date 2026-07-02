using System;
using System.Collections.Generic;

namespace BAPBAP.UI
{
	[Serializable]
	public class CharacterSelectModel : Model
	{
		public PlayerModel player;

		public List<PlayerModel> mmTeammates;

		public int preMatchSeconds;

		public double startTime;

		public bool timerIsCounting;

		public int[] availableCharacters;

		public int[] gameModifierIDs;

		public int charSelectTime;

		public int spawnSelectTime;
	}
}
