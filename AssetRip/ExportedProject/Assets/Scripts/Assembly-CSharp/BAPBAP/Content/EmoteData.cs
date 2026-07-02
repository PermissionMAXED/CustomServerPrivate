using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "EmoteData", menuName = "BAPBAP/Content/Emotes/EmoteData", order = 1)]
	public class EmoteData : ScriptableObject
	{
		[Serializable]
		public class TierConfig
		{
			public Material stickerMaterial;
		}

		[Header("Config")]
		[SerializeField]
		public float defaultStickerDisplayScale;

		[NamedArray(typeof(TierType), 0)]
		public TierConfig[] tierConfigs;

		[InspectorButton("OnTriggerRebuild")]
		[SerializeField]
		[Space(10f)]
		public bool TriggerRebuild;

		[BeginReadOnlyGroup]
		[FormerlySerializedAs("stickerEmotes")]
		[SerializeField]
		public EmoteSO[] emotes;

		[BeginReadOnlyGroup]
		[FormerlySerializedAs("stickerGroups")]
		[SerializeField]
		public ContentManager.ContentGroup[] emoteGroups;

		public const int assetEmoteOffset = 400000;

		public Emote GetEmoteByEmoteId(int emoteId)
		{
			return null;
		}

		public int GetEmoteIdByEmote(Emote emote)
		{
			return 0;
		}

		public Emote GetEmoteByAssetId(int assetId)
		{
			return null;
		}

		public static int GetEmoteAssetIdByEmote(Emote emote)
		{
			return 0;
		}

		public int GetEmoteGroupIdByEmote(Emote emote)
		{
			return 0;
		}

		public Emote GetPreviousEmoteTierEmoteOnContentGroup(Emote emote)
		{
			return null;
		}

		public static int GetAssetIdOffsetByEmoteType(Emote emote)
		{
			return 0;
		}
	}
}
