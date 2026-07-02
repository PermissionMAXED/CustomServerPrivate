using System;
using BAPBAP.Entities;
using BAPBAP.Game.Dimensions;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_DimensionFollow : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public GameObject dimension;

			public float castTime;

			public float lerpSpeed;

			public float[] radius;
		}

		public class CustomDimensionRadiusSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_DimensionFollow behaviour;

			[NonSerialized]
			public int index;

			public CustomDimensionRadiusSubroutine(AB_DimensionFollow behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomSpawnDimensionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_DimensionFollow behaviour;

			public CustomSpawnDimensionSubroutine(AB_DimensionFollow behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public DimensionZone dZone;

		public AB_DimensionFollow(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void SpawnDimension(EntityManager cM)
		{
		}
	}
}
