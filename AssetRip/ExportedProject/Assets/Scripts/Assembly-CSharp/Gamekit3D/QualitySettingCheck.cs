using System;
using UnityEngine;

namespace Gamekit3D
{
	[ExecuteInEditMode]
	public class QualitySettingCheck : MonoBehaviour
	{
		public MonoBehaviour[] targets;

		[HideInInspector]
		public int minimumQualitySettings;

		[NonSerialized]
		public int m_PreviousQualitySetting;

		public void OnEnable()
		{
		}

		public void Update()
		{
		}

		public void Toggle(bool qualitySettingMet)
		{
		}
	}
}
