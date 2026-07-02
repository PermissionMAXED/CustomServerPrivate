using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class EntityActivateFling : EntityActivateBase, IEntityDataProperty
	{
		[NonSerialized]
		public NavMeshLink navMeshLink;

		[NonSerialized]
		public AudioManager audioManager;

		[Header("Audio/Vfx References")]
		[SerializeField]
		public AudioClipData playerLaunchAudio;

		[SerializeField]
		[ExHeader("\ud83d\udee0 [PROPERTIES] \ud83d\udee0", 0f, 1f, 1f)]
		public float jumpDistance;

		[SerializeField]
		[Header("Jump Settings")]
		public float jumpDuration;

		[SerializeField]
		public float jumpHeight;

		[SerializeField]
		public CharVoicelineConfig voiceline;

		[Header("Physics Prop References")]
		[SerializeField]
		public GameObject physForceTrigger;

		[NonSerialized]
		public List<EntityManager> tempCopy;

		public override void Awake()
		{
		}

		[ServerCallback]
		public override void Activate()
		{
		}

		[Server]
		public bool TryApplyAirborne(EntityManager entity)
		{
			return false;
		}

		[Server]
		public void ApplyAirborne(EntityManager entity)
		{
		}

		[ClientRpc]
		public void RpcTriggerSpringJumpLaunchSfx()
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public void OnDrawGizmos()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcTriggerSpringJumpLaunchSfx()
		{
		}

		public static void InvokeUserCode_RpcTriggerSpringJumpLaunchSfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateFling()
		{
		}
	}
}
