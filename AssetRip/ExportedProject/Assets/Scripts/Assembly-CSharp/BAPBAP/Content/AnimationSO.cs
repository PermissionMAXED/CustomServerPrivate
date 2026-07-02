using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "Animation", menuName = "BAPBAP/Content/Emotes/Animation", order = 1)]
	public class AnimationSO : EmoteSO
	{
		public Animation animation;

		public override Content content => null;

		public override Emote emote => null;
	}
}
