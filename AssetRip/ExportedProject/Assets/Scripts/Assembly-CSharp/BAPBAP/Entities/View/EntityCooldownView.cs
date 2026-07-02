using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	[RequireComponent(typeof(EntityBehaviour))]
	[RequireComponent(typeof(CharMaterial))]
	public abstract class EntityCooldownView : NetworkBehaviour
	{
		[SerializeField]
		public EntityBehaviour entityBehaviour;

		[SerializeField]
		public CharMaterial charMaterial;

		[NonSerialized]
		public RendererVisibilityEvents rendererVisibility;

		[NonSerialized]
		public float cooldownDuration;

		[NonSerialized]
		public float timeToFullActivate;

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public abstract void OnSubscribed();

		public bool SubscribeToClientActions()
		{
			return false;
		}

		public abstract void SetCooldown(float cd);

		public abstract void PreFullActivateTick(float normValue);

		public abstract void OnActivate();

		public abstract void OnReset();

		public abstract void OnIsActivated(bool activated);

		public abstract void OnRendererVisibilityChanged(bool visible);

		public void OnDestroy()
		{
		}

		public abstract void OnEntityDestroyed();

		public EntityCooldownView()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
