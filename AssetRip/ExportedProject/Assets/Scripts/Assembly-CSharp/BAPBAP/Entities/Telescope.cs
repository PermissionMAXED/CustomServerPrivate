using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Telescope : InteractableStation
	{
		[Header("References")]
		[SerializeField]
		public AudioSource resetAudioSource;

		[SerializeField]
		public GameObject areaIndicator;

		[Header("Properties")]
		[SerializeField]
		public float visibilityRadius;

		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
		public string interactTranslationKey;

		[SerializeField]
		public string usingTranslationKey;

		[NonSerialized]
		public FogOfWarController fowController;

		[NonSerialized]
		public CameraController camController;

		[NonSerialized]
		public string usingStr;

		[NonSerialized]
		public string interactStr;

		[NonSerialized]
		public readonly SyncList<int> playerIdsUsing;

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public void FixedUpdate()
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override void OnLocalAuthPlayerChanged(EntityManager entity, InteractableCollider slot)
		{
		}

		public void AddUsingChar(EntityManager entity)
		{
		}

		public void RemoveUsingChar(EntityManager entity)
		{
		}

		public void RemoveUsingChar(int index, EntityManager entity)
		{
		}

		public void ApplyAuth(int playerId, bool instant = false)
		{
		}

		public void StopAuth(int playerId, bool instant = false)
		{
		}

		public void OnCharsUsingChangedRefresh(EntityManager entity)
		{
		}

		public void OnCharsUsingChanged(SyncList<int>.Operation op, int index, int oldItem, int newItem)
		{
		}

		public void OnCharsUsingChangedHook(SyncList<int>.Operation op, int index, int oldItem, int newItem, bool instant = false)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
