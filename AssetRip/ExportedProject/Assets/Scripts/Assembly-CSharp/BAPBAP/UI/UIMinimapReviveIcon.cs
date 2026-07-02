using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIMinimapReviveIcon : UIMinimapDirIcon
	{
		[NonSerialized]
		public bool isReviveActive;

		[SerializeField]
		public Color activeBaseColor;

		[SerializeField]
		public Color inactiveBaseColor;

		public override void Awake()
		{
		}

		public void SetReviveActive(bool isActive)
		{
		}
	}
}
