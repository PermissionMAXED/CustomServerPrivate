using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "Voiceline", menuName = "BAPBAP/Content/Emotes/Voiceline", order = 1)]
	public class VoicelineSO : EmoteSO
	{
		public Voiceline voiceline;

		public override Content content => null;

		public override Emote emote => null;
	}
}
