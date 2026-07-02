using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SellStation : InteractableStation
	{
		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public ItemCurrencyManager itemCurrencyManager;

		[Header("View References")]
		[SerializeField]
		public GameObject npcRootGameObject;

		[SerializeField]
		public SimpleTargetDetectionCl targetDetectionCl;

		[SerializeField]
		public LookAtTargetConstraint followLookAtTarget;

		[SerializeField]
		public RotateTransformYCurve npcFailAnimation;

		[SerializeField]
		[Header("Config")]
		public float itemSpawnRadius;

		[NonSerialized]
		public string sellingStr;

		[NonSerialized]
		public string sellForStr;

		[NonSerialized]
		public string noItemsStr;

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public void UIShowValidWindow(InteractableCollider slot, Item currentItem, int price)
		{
		}

		public override void ClOnForceUpdate(EntityManager entity, InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public void SellItemCurrency(Vector3 spawnPos, int id, int amount)
		{
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
