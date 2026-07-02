using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GameModifierManager : MonoBehaviour
	{
		[SerializeField]
		public GameModifierSO[] gameModifiers;

		public void PreAwake()
		{
		}

		public GameModifier NewGameModifier(int gameModifierId)
		{
			return null;
		}

		public void Localise(Translator translator)
		{
		}

		public GameModifier.GameModifierConfiguration GetConfig(int gameModifierId)
		{
			return null;
		}
	}
}
