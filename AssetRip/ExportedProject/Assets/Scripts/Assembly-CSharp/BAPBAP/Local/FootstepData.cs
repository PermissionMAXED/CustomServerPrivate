using System;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(fileName = "FootstepData", menuName = "BAPBAP/Other/FootstepData", order = 1)]
	public class FootstepData : ScriptableObject
	{
		[Serializable]
		public class FootstepType
		{
			public AudioClip[] audioClips;

			public GameObject vfxPrefab;

			public float volumeMultiplier;
		}

		[SerializeField]
		public FootstepType defaultFootstep;

		[SerializeField]
		public GameObject defaultSlipperyVfx;

		[SerializeField]
		public FootstepType grassFootstep;

		[SerializeField]
		public FootstepType sandFootstep;

		[SerializeField]
		public FootstepType snowFootstep;

		[SerializeField]
		public FootstepType concreteFootstep;

		[SerializeField]
		public FootstepType woodFootstep;

		[SerializeField]
		public FootstepType bushFootstep;

		[SerializeField]
		public FootstepType bushDesertFootstep;

		[SerializeField]
		public FootstepType polishedTileFootstep;

		[SerializeField]
		public FootstepType slipperyIceFootstep;

		[SerializeField]
		public FootstepType freshCementFootstep;

		[SerializeField]
		public FootstepType metalFootstep;

		[SerializeField]
		public FootstepType dirtFootstep;

		[SerializeField]
		public FootstepType rockFootstep;

		[SerializeField]
		public FootstepType bloodFootstep;

		public FootstepType GetFootstepTypeFromSurfaceId(int surfaceId)
		{
			return null;
		}

		public FootstepType DefaultFootstep()
		{
			return null;
		}
	}
}
