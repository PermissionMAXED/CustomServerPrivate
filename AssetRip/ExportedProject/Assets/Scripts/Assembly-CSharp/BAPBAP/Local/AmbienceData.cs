using System;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(fileName = "AmbienceData", menuName = "BAPBAP/Other/AmbienceData", order = 1)]
	public class AmbienceData : ScriptableObject
	{
		[Serializable]
		public class AmbienceType
		{
			public AudioClip audioClip;

			public float volumeMultiplier;

			public Color debugVisualizeColor;
		}

		[NamedArray(typeof(AmbienceId), 0)]
		[SerializeField]
		public AmbienceType[] ambiences;

		public AmbienceType[] Ambiences => null;

		public AmbienceType GetAmbienceTypeById(AmbienceId ambienceId)
		{
			return null;
		}
	}
}
