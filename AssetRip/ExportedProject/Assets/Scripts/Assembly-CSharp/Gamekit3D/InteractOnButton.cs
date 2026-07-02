using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
	public class InteractOnButton : InteractOnTrigger
	{
		public string buttonName;

		public UnityEvent OnButtonPress;

		[NonSerialized]
		public bool canExecuteButtons;

		public override void ExecuteOnEnter(Collider other)
		{
		}

		public override void ExecuteOnExit(Collider other)
		{
		}

		public void Update()
		{
		}
	}
}
