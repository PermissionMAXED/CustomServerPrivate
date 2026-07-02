using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Entities.HideArea;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharHideArea : NetworkBehaviour, INetworkPredicted, IEntityTriggerboxListener
	{
		public struct CachedBush
		{
			public int id;

			public BAPBAP.Entities.HideArea.HideArea bush;

			public int colliderCount;
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharHidden charHidden;

		[NonSerialized]
		public BushManager bushManager;

		[NonSerialized]
		public List<CachedBush> bushCollidersEntered;

		[NonSerialized]
		public List<BAPBAP.Entities.HideArea.HideArea> bushesEntered;

		[NonSerialized]
		public int bushId;

		public void PreAwake(EntityManager e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SetHiddenState(bool isHidden)
		{
		}

		public bool IsCharVisibleInBush()
		{
			return false;
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		public void OnBushEnter(BAPBAP.Entities.HideArea.HideArea bush)
		{
		}

		public void OnBushExit(BAPBAP.Entities.HideArea.HideArea bush)
		{
		}

		public void OnBushIdChanged(int oldBushId, int newBushId)
		{
		}

		public void OnHookEnterBush(int bushId)
		{
		}

		public void OnHookExitBush(int bushId)
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
