using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class AtlantisDimensionZone : DimensionZone
	{
		[Space]
		[Min(0f)]
		[Header("Atlantis Custom Config")]
		public float animMoveSpeedAmount;

		public GameObject moveBubbleVfxPrefab;

		public override void Start()
		{
		}

		public void ClOnEntityEnter(EntityManager entity)
		{
		}

		public void ClOnEntityExit(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
