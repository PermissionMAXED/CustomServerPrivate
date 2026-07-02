using System;
using BAPBAP.UI;
using UnityEngine;

namespace LevelEditor
{
	public class CharMovementCheck : MonoBehaviour
	{
		[Serializable]
		public class MovementAbilityInfo
		{
			public string name;

			public float maxDistance;

			public float navMeshCheckRadius;

			[NonSerialized]
			public IndicatorProgress indicatorProgress;

			[NonSerialized]
			public CircleShapeSprite abilityCircleShape;
		}

		public LayerMask mouseLayer;

		public LayerMask obstacleMask;

		public IndicatorProgress indicatorProgressPrefab;

		public MovementAbilityInfo[] abilities;

		public void Update()
		{
		}

		public void OnDisable()
		{
		}

		public void TryMovementAbility(MovementAbilityInfo ability)
		{
		}

		public void StopAbilityCheck(MovementAbilityInfo ability)
		{
		}
	}
}
