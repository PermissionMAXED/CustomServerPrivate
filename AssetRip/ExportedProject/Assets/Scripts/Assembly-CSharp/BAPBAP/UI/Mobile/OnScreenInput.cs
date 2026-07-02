using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI.Mobile
{
	public class OnScreenInput : OnScreenControl
	{
		[SerializeField]
		public InputTarget target;

		[NonSerialized]
		public string path;

		public override string controlPathInternal
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}
	}
}
