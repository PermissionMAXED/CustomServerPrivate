using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIHpBarCulling : MonoBehaviour
	{
		[SerializeField]
		public GameObject barRoot;

		[NonSerialized]
		public bool isHidden;

		public const float margin = 88f;

		public const float marginHalf = 44f;

		public void ManagedLateUpdate()
		{
		}

		public void UpdateBarCulling()
		{
		}

		public void SetHiddenState(bool isHidden)
		{
		}
	}
}
