using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[Serializable]
	public struct RiptidedEntityData
	{
		public EntityManager entityManager;

		public bool vfxInitialized;

		public ParticleSystem withCurrentVFX;

		public float withCurrentEmissionRate;

		public ParticleSystem againstCurrentVFX;

		public float againstCurrentEmissionRate;

		public RiptidedEntityData(EntityManager eM)
		{
			entityManager = null;
			vfxInitialized = false;
			withCurrentVFX = null;
			withCurrentEmissionRate = 0f;
			againstCurrentVFX = null;
			againstCurrentEmissionRate = 0f;
		}

		public void InitializeVfx(ParticleSystem withCurrentVFX, ParticleSystem againstCurrentVFX)
		{
		}
	}
}
