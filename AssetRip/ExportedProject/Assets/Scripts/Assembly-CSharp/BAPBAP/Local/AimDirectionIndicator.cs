using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AimDirectionIndicator : MonoBehaviour
	{
		[SerializeField]
		public LineRenderer lineRenderer;

		[SerializeField]
		public GameObject aoeIndicator;

		[SerializeField]
		public float startOffset;

		[SerializeField]
		public float elevationOffset;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public HashSet<int> chars;

		[NonSerialized]
		public float range;

		[NonSerialized]
		public bool projectile;

		public void Enable(int charId, float range, bool projectile)
		{
		}

		public void Awake()
		{
		}

		public void FixedUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public bool TryGetPlayerCharacter(out EntityManager character)
		{
			character = null;
			return false;
		}

		public bool EnabledForCharacter(EntityManager character)
		{
			return false;
		}

		public bool NotCastingExceptBasic(EntityManager character)
		{
			return false;
		}
	}
}
