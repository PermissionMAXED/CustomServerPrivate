using System;
using System.Collections.Generic;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class HpBarSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<UIHpBar> components;

		public void Register(UIHpBar hpBarManager)
		{
		}

		public void Unregister(UIHpBar hpBarManager)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
