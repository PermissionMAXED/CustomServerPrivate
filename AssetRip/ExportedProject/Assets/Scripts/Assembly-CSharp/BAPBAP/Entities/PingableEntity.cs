using System;
using BAPBAP.Maps;
using BAPBAP.Player;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class PingableEntity : MonoBehaviour
	{
		[NonSerialized]
		public NetworkIdentity netIdentity;

		[NonSerialized]
		public PrefabConfig prefabConfig;

		[SerializeField]
		[Header("References")]
		public Collider pingCollider;

		[SerializeField]
		public bool useCustomTransform;

		[ConditionalHide("useCustomTransform", true)]
		[SerializeField]
		public Transform pingCustomTransform;

		[SerializeField]
		[Header("Settings")]
		public PlayerPing.PingTarget pingTarget;

		[SerializeField]
		public bool needsForLineOfSight;

		[SerializeField]
		public bool customEntity;

		[ConditionalHide("customEntity", true)]
		[SerializeField]
		public PrefabConfig customEntityConfig;

		[SerializeField]
		public CharVoicelineConfig voiceline;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public int GetEntityPrefabId()
		{
			return 0;
		}
	}
}
