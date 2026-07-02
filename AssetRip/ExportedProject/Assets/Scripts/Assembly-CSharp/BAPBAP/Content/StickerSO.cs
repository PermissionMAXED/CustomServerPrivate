using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "Sticker", menuName = "BAPBAP/Content/Emotes/Sticker", order = 1)]
	public class StickerSO : EmoteSO
	{
		[FormerlySerializedAs("sticker")]
		public Sticker sticker;

		public override Content content => null;

		public override Emote emote => null;
	}
}
