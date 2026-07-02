using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Maps;
using Mirror;
using PathCreation;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraRail : NetworkBehaviour, IEntityDataProperty
	{
		[SerializeField]
		public bool generateVisualMesh;

		[SerializeField]
		[Header("References")]
		public PathMeshGenerate pathMeshGenerator;

		[Header("Vertex Path")]
		[SerializeField]
		public float maxAngleError;

		[SerializeField]
		public float minVertexSpacing;

		[NonSerialized]
		public VertexPath vertexPath;

		[NonSerialized]
		public readonly SyncList<Vector3> cameraNodes;

		[SyncVar]
		[NonSerialized]
		public bool isLooping;

		[SyncVar]
		[NonSerialized]
		public bool bezierPathEnabled;

		[SyncVar(hook = "OnWorldPositionsSyncedChanged")]
		[NonSerialized]
		public bool worldPositionsSynced;

		public static List<CameraRail> CameraRails;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_worldPositionsSynced;

		public float GetPathLength => 0f;

		public bool NetworkisLooping
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkbezierPathEnabled
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkworldPositionsSynced
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void BuildCameraRail()
		{
		}

		public Vector3 GetWorldPosAtNormPathPos(float normTime)
		{
			return default(Vector3);
		}

		public Vector3 GetNormalAtNormPathPos(float normTime)
		{
			return default(Vector3);
		}

		public Vector3 GetClosestPointOnPath(Vector3 position)
		{
			return default(Vector3);
		}

		public float GetClosestTimeOnPath(Vector3 point)
		{
			return 0f;
		}

		public void OnWorldPositionsSyncedChanged(bool oldValue, bool newValue)
		{
		}

		public string PropertyName()
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

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
