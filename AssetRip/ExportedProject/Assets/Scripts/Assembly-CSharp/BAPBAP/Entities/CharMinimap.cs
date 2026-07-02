using System;
using BAPBAP.Maps;
using BAPBAP.Systems;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharMinimap : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public UIMinimap uiMinimap;

		[NonSerialized]
		public SystemManager systemManager;

		[Header("Settings")]
		[Tooltip("For this character, always appear as an npc icon, even if its a player")]
		[SerializeField]
		public bool appearAsNpc;

		[NonSerialized]
		public int currentBiomeCached;

		[NonSerialized]
		public int currentCeilingGroupCached;

		[NonSerialized]
		public LevelRuntimeManager levelManager;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void ClStart()
		{
		}

		public void OnDestroy()
		{
		}

		public void SetMinimapFollowTarget()
		{
		}

		public void SetTeam(bool isAlly)
		{
		}

		public void ManagedLateUpdate()
		{
		}
	}
}
