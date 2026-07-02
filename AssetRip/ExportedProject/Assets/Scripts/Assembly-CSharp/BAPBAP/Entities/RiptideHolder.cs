using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Game.Dimensions;
using BAPBAP.Local;
using BAPBAP.Utilities;
using Dreamteck.Splines;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class RiptideHolder : NetworkBehaviour
	{
		[NonSerialized]
		public VfxManager vfxManager;

		[Tooltip("The gameObject containing all colliders for interacting with entities")]
		[SerializeField]
		[Header("Refrences")]
		public EntityTriggerboxListener entityDetectCollidersHolder;

		[SerializeField]
		public SplineComputer spline;

		[SerializeField]
		public TubeGenerator splineMeshGenerator;

		[SerializeField]
		[Tooltip("The speed to apply to entities when they move towards the riptide current")]
		[Header("Config")]
		public float towardsSpeed;

		[SerializeField]
		[Tooltip("The speed to apply to entities when they move against the riptide current, or when they are just standing on it.")]
		public float againstSpeed;

		[Min(0f)]
		[Tooltip("The duration for the riptide to fade in and out")]
		[SerializeField]
		public float fadeDuration;

		[Header("Destroy Settings")]
		[Tooltip("Tick rate to check to destroy riptide in dimension")]
		[SerializeField]
		[Min(1f)]
		public int inDimensionUpdateTickRate;

		[SerializeField]
		[Tooltip("Add the given margin to the dimension edge. If the riptide surpassed this edge, proceed to destroy it")]
		public float destroyDzEdgeMargin;

		[Header("Path Raycast Settings")]
		[SerializeField]
		[Range(0f, 1f)]
		public float randomDeviationAmount;

		[Range(0f, 180f)]
		[SerializeField]
		public float raycastSearchRadius;

		[Min(0f)]
		[SerializeField]
		public float raycastLengthSafeOffset;

		[Min(1f)]
		[SerializeField]
		public int raycastNumber;

		[SerializeField]
		[Header("Path Generation Settings")]
		[Tooltip("Only allow generated paths above this length threshold")]
		public float minPathLength;

		[SerializeField]
		public float pathColliderWidth;

		[SerializeField]
		public IntRange pathPointNumRange;

		[SerializeField]
		public RangeFloat segmentLengthRange;

		[SerializeField]
		public int splineColliderSampleRate;

		[SerializeField]
		[Header("Rendering")]
		public Renderer tubeRenderer;

		[SerializeField]
		[Header("Client VFX")]
		public GameObject withCurrentVfxPrefab;

		[SerializeField]
		public GameObject againstCurrentVfxPrefab;

		[SerializeField]
		public GameObject entryExitVfxPrefab;

		[SerializeField]
		[Space(10f)]
		public bool showDebug;

		[NonSerialized]
		public Dimension dimension;

		[NonSerialized]
		public D_Obj_Riptide riptideObj;

		[NonSerialized]
		public MaterialPropertyBlock _propertyBlock;

		[NonSerialized]
		public List<RiptidedEntityData> currentEntities;

		[NonSerialized]
		public List<RiptideHolder> otherRiptides;

		[NonSerialized]
		public Vector3[] pathPoints;

		[NonSerialized]
		public Vector2 pathBoundsCenter;

		[NonSerialized]
		public float pathBoundsLengthSqr;

		[NonSerialized]
		public int defaultSplineSampleRate;

		[NonSerialized]
		public bool waitingToDestroy;

		[NonSerialized]
		public float densitySqrd;

		[NonSerialized]
		public float startAlpha;

		public static readonly int AlphaProperty;

		[NonSerialized]
		public readonly SyncList<Vector2> syncPathPoints;

		[SyncVar(hook = "OnListReadyChanged")]
		[NonSerialized]
		public bool listSyncReady;

		[SyncVar(hook = "OnFadeFactorChanged")]
		[NonSerialized]
		public float fadeFactor;

		[NonSerialized]
		public NavMeshHit hit;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_listSyncReady;

		public Action<float, float> _Mirror_SyncVarHookDelegate_fadeFactor;

		public MaterialPropertyBlock propertyBlock => null;

		public Vector3[] PathPoints => null;

		public bool NetworklistSyncReady
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

		public float NetworkfadeFactor
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

		public void Awake()
		{
		}

		public void Init(List<RiptideHolder> riptideHolders, float densitySqrd)
		{
		}

		public override void OnStartClient()
		{
		}

		public void SetCollidersEnabled(bool isEnabled)
		{
		}

		public void TryBuildPath()
		{
		}

		public void BuildSpline(Vector3 spawnPosition, ref bool failure)
		{
		}

		public void GenerateSplineFromPoints(Vector3[] pathPoints)
		{
		}

		public void BuildColliders()
		{
		}

		public void ClBuild(Vector3[] pathPoints)
		{
		}

		public void FixedUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void SvTick(float fixedDt)
		{
		}

		public void SvBeginDestroyRiptide()
		{
		}

		public void OnDisable()
		{
		}

		public void MovePassengerInPath(RiptidedEntityData riptidedChar, float fixedDt)
		{
		}

		public void TransformVFXInPath(RiptidedEntityData riptidedChar, float deltaTime)
		{
		}

		public Vector3 GetClosestPathNormalAtPos(Vector3 worldPos)
		{
			return default(Vector3);
		}

		public void OnEntityEnter(EntityManager entity)
		{
		}

		public void OnEntityExit(EntityManager entity)
		{
		}

		public void AddEntity(EntityManager entity)
		{
		}

		public void RemoveEntity(int i)
		{
		}

		public void ClSpawnSplashVfx(Transform entityTransform)
		{
		}

		public void SetRiptideAlpha(float alpha)
		{
		}

		public Vector3[] GetPathPositions(Vector3 dir, Vector3 startPos)
		{
			return null;
		}

		public Vector3 RandomPositionWithinRadius()
		{
			return default(Vector3);
		}

		public bool IsPositionValid(Vector3 position)
		{
			return false;
		}

		public bool IsCollidingWithRiptide(Vector3 position)
		{
			return false;
		}

		public void OnListReadyChanged(bool oldValue, bool newValue)
		{
		}

		public void OnFadeFactorChanged(float oldValue, float newValue)
		{
		}

		public void OnDrawGizmos()
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
