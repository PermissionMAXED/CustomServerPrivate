using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CatPolymorphAbility : Ability
	{
		public class CustomTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CatPolymorphAbility ability;

			public CustomTargetSubroutine(CatPolymorphAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("State-related")]
		[SerializeField]
		public float targetSelectorRadius;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float maxDistance;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float catDuration;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[SerializeField]
		[Header("Effects")]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public Vector3 targetPos;

		public override void PreAwake(EntityManager _charManager)
		{
		}

		public void Shoot(Vector3 landingPoint)
		{
		}

		[Server]
		public override void OnHitboxEnd(List<EntityManager> entityHits)
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
