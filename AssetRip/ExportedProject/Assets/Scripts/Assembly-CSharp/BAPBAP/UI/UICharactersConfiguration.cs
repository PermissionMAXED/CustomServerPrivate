using System;
using BAPBAP.Content;
using SaintsField;
using UnityEngine;

namespace BAPBAP.UI
{
	[CreateAssetMenu(fileName = "UICharactersConfiguration", menuName = "BAPBAP/Configuration/UI/CharactersConfiguration")]
	public class UICharactersConfiguration : ScriptableObject
	{
		[Serializable]
		public struct CharIdWrapper
		{
			public int charId;

			public DropdownList<int> GetCharsDropdown()
			{
				return null;
			}
		}

		[Serializable]
		public class CharacterConfiguration
		{
			[Serializable]
			public struct AbilityData
			{
				[SpriteVisualizer]
				public Sprite icon;

				[Header("Localization Keys")]
				public string titleKey;

				public string shortDescriptionKey;

				public string descriptionKey;
			}

			public const int mainAbilityNum = 4;

			[TextArea(1, 1)]
			public string name;

			[TextArea(1, 1)]
			public string descriptionTranslationKey;

			public int charId;

			[Tooltip("Is this character displayed in the game lobby?")]
			public bool enabledInLobby;

			[Tooltip("Is this character displayed in the developer lobby?")]
			public bool enabledInDevLobby;

			[Header("Sprites")]
			public Color Color;

			public Color UIAccentColor;

			public Sprite smallSprite;

			public Sprite IconSprite;

			public Sprite LobbyBackground;

			public Sprite FullSprite;

			public Sprite StandingSprite;

			public Sprite CircleIcon;

			public Sprite SquareIcon;

			public Sprite SquareSmallIcon;

			public SpriteTransformModifier gameStatsLobbySpriteModifier;

			public SkinSO DefaultSkin;

			[Header("Abilities Color")]
			public Color abilityIconColor;

			public Color abilityBGColor;

			public Color titleTextColor;

			[Header("Abilities Data")]
			public AbilityData ability1;

			public AbilityData ability2;

			public AbilityData ability3;

			public AbilityData ability4;

			public AbilityData GetAbilityData(int abilityIndex)
			{
				return default(AbilityData);
			}
		}

		[Serializable]
		public class SpriteTransformModifier
		{
			public Vector2 anchoredPos;

			public float scale;
		}

		[SerializeField]
		public CharacterConfiguration[] _characters;

		[NonSerialized]
		public CharacterConfiguration[] _lobbyCharacters;

		[HideInInspector]
		[SerializeField]
		public int[] _lobbyAvailableCharacterIds;

		public CharacterConfiguration[] Characters => null;

		public CharacterConfiguration[] LobbyCharacters => null;

		public int[] AvailableCharacterIds => null;

		public bool TryGetCharConfigByCharId(int charId, out CharacterConfiguration config)
		{
			config = null;
			return false;
		}

		public bool TryGetLobbyCharConfigByIndex(int charIndex, out CharacterConfiguration config)
		{
			config = null;
			return false;
		}

		public void UpdateAvailableCharacterList(int[] newCharacters)
		{
		}

		public void Validate()
		{
		}

		public static string CharArrayDrawer(int charId)
		{
			return null;
		}

		public static DropdownList<int> GetCharsDropdown()
		{
			return null;
		}
	}
}
