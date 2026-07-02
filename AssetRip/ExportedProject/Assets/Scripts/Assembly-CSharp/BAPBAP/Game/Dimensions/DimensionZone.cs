using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Entities;
using BAPBAP.Entities.View;
using BAPBAP.Local;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class DimensionZone : NetworkBehaviour
	{
		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public UIMinimap uiMinimap;

		[SerializeField]
		public Dimension dimension;

		[NonSerialized]
		public EntityInterpolator _entityInterp;

		[NonSerialized]
		public float _timer;

		[NonSerialized]
		public float _duration;

		[NonSerialized]
		public float _initialRadius;

		[NonSerialized]
		public float _targetRadius;

		[NonSerialized]
		public Vector2 _initialPos;

		[NonSerialized]
		public Vector2 _targetPos;

		[NonSerialized]
		public float _transitionDelayTime;

		[NonSerialized]
		public int _transitionCount;

		[NonSerialized]
		public int _maxTransitionCount;

		[NonSerialized]
		public bool _doSync;

		[NonSerialized]
		public FollowPosition _followPos;

		[NonSerialized]
		public float _followRadius;

		[NonSerialized]
		public List<EntityManager> currentEntities;

		[SyncVar(hook = "OnRadiusChanged")]
		[NonSerialized]
		public float radius;

		[SyncVar(hook = "OnPositionChanged")]
		[NonSerialized]
		public Vector2 position;

		[NonSerialized]
		public List<D_Obj> dobjs;

		public Action<float, float> _Mirror_SyncVarHookDelegate_radius;

		public Action<Vector2, Vector2> _Mirror_SyncVarHookDelegate_position;

		public GameManager _gameManager => null;

		public Dimension Dimension => null;

		public float Networkradius
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public Vector2 Networkposition
		{
			get
			{
				return default(Vector2);
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public virtual void Start()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		public override void OnStartServer()
		{
		}

		public virtual void OnEntityEnter(EntityManager entity)
		{
		}

		public virtual void OnEntityExit(EntityManager entity)
		{
		}

		public void FixedUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void InitZoneBehaviour()
		{
		}

		public void TickZoneBehaviour(float fixedDt)
		{
		}

		[Server]
		public void SvSetFollowBehaviour(Transform target, float radius)
		{
		}

		[Server]
		public void SvSetTargetValues(Vector2 targetPos, float targetRadius)
		{
		}

		[Server]
		public void SvSetDimensionRadiusAndPos(Vector2 pos, float radius, bool sync = true)
		{
		}

		[Server]
		public void SvInitializeDimensionTargetPos()
		{
		}

		public void ClOnDimensionableEnter(Dimensionable dimensionable)
		{
		}

		public void ClOnDimensionableExit(Dimensionable dimensionable)
		{
		}

		public void ClUpdateMusic()
		{
		}

		[ClientRpc]
		public void RpcSetNewPosition(int svTickNum, Vector3 scale, Vector3 position)
		{
		}

		public void OnRadiusChanged(float oldValue, float newValue)
		{
		}

		public void OnPositionChanged(Vector2 oldValue, Vector2 newValue)
		{
		}

		[Server]
		public void SvSetDimensionClosingFinished()
		{
		}

		public void OnDrawGizmos()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSetNewPosition__Int32__Vector3__Vector3(int svTickNum, Vector3 scale, Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSetNewPosition__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static DimensionZone()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
