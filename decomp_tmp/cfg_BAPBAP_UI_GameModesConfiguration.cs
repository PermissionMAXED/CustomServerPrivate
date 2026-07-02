using System;
using UnityEngine;

namespace BAPBAP.UI;

[CreateAssetMenu(fileName = "GameModesConfiguration", menuName = "BAPBAP/Configuration/GameModes")]
public class GameModesConfiguration : ScriptableObject
{
	public enum Rank
	{
		Unranked,
		Bronze,
		Silver,
		Gold,
		Platinum,
		Diamond,
		Royal,
		Divine
	}

	[Serializable]
	public class GameModeConfiguration
	{
		public string Name;

		public string NameTranslationKey;

		public string Type;

		public string TypeTranslationKey;

		public string highlightBannerSymbol;

		public Sprite illustration;

		public Sprite illustrationBg;

		public Sprite illustrationSmall;

		public int Id;

		public int TeamSize;

		public bool IsRanked;

		public bool CanAutoSelect;
	}

	[Serializable]
	public class RankConfiguration
	{
		[Serializable]
		public class RankTier
		{
			public int rankLow;

			public int rankHigh;

			public string Name;
		}

		public string Name;

		public string TranslationKey;

		public Sprite IconSmall;

		public Sprite IconWhiteSmall;

		public Sprite IconLarge;

		public Color Color;

		public RankTier[] tiers;
	}

	[SerializeField]
	public GameModeConfiguration[] _gameModes;

	[SerializeField]
	public int _openBetaChallengeGmId;

	[SerializeField]
	public int _customGamesGmId;

	[NamedArray(typeof(Rank), 0)]
	[SerializeField]
	public RankConfiguration[] _ranks;

	public GameModeConfiguration[] GameModes => null;

	public int OpenBetaChallengeGmId => 0;

	public int CustomGamesGmId => 0;

	public RankConfiguration[] Ranks => null;
}
