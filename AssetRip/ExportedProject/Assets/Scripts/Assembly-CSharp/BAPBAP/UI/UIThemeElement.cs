using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIThemeElement : MonoBehaviour
	{
		[NonSerialized]
		public float fadeTime;

		public virtual void Start()
		{
		}

		public virtual void SetThemeMode(ThemeMode mode, bool doFade)
		{
		}
	}
}
