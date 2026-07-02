using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "Skin", menuName = "BAPBAP/Content/Skins/Skin", order = 1)]
	public class SkinSO : ContentSO
	{
		public Skin skin;

		public override Content content => null;
	}
}
