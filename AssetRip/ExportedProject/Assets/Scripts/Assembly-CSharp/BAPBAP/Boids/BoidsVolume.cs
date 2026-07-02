using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace BAPBAP.Boids
{
	public class BoidsVolume : MonoBehaviour
	{
		[BurstCompile]
		public struct BoidsJob : IJobParallelFor
		{
			public NativeArray<Vector3> Positions;

			public NativeArray<Vector3> Velocities;

			public NativeArray<Vector3>.ReadOnly ReadOnlyPositions;

			public NativeArray<Vector3>.ReadOnly ReadOnlyVelocities;

			public NativeArray<Bounds>.ReadOnly BoundsBuffer;

			public int ColliderCount;

			public float DeltaTime;

			public Vector3 Centre;

			public Vector3 Target;

			public float Radius;

			public float MaxSpeed;

			public float Acceleration;

			public float SeparationRadius;

			public float SeparationWeight;

			public float CohesionRadius;

			public float CohesionWeight;

			public float AlignmentRadius;

			public float AlignmentWeight;

			public float RepulsionRadius;

			public float RepulsionWeight;

			public float TargetWeight;

			public float HorizontalWeight;

			public float RadiusWeight;

			public float ReluctanceWeight;

			public float CollisionRadius;

			public float CollisionWeight;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		public struct PreviousVelocityJob : IJobParallelFor
		{
			public NativeArray<Vector3> PreviousVelocities;

			public NativeArray<Vector3>.ReadOnly ReadOnlyPreviousVelocities;

			public NativeArray<Vector3>.ReadOnly ReadOnlyCurrentVelocities;

			public float Delay;

			public void Execute(int index)
			{
			}
		}

		[SerializeField]
		[Min(0.1f)]
		public float _radius;

		[SerializeField]
		public Vector3 _targetOffset;

		[SerializeField]
		public Vector3 _spawnOffset;

		[Min(1f)]
		[SerializeField]
		public int _count;

		[SerializeField]
		public Mesh _mesh;

		[SerializeField]
		public Material _material;

		[SerializeField]
		public Gradient _colorGradient;

		[Min(1f)]
		[SerializeField]
		public int _minGrouping;

		[SerializeField]
		[Min(1f)]
		public int _maxGrouping;

		[SerializeField]
		[Range(0.1f, 5f)]
		public float _groupingRadius;

		[SerializeField]
		[Min(0f)]
		public float _minScale;

		[Min(0f)]
		[SerializeField]
		public float _maxScale;

		[Min(0f)]
		[SerializeField]
		public float _spawnDuration;

		[Min(1f)]
		[SerializeField]
		public int _spawnRate;

		[Min(0f)]
		[SerializeField]
		public float _maxSpeed;

		[SerializeField]
		[Min(0f)]
		public float _acceleration;

		[SerializeField]
		[Min(0f)]
		public float _previousVelocityDelay;

		[SerializeField]
		[Range(0f, 5f)]
		public float _separationRadius;

		[Range(0f, 5f)]
		[SerializeField]
		public float _separationWeight;

		[Range(0f, 5f)]
		[SerializeField]
		public float _cohesionRadius;

		[Range(0f, 5f)]
		[SerializeField]
		public float _cohesionWeight;

		[Range(0f, 5f)]
		[SerializeField]
		public float _alignmentRadius;

		[Range(0f, 5f)]
		[SerializeField]
		public float _alignmentWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float _repulsionRadius;

		[Range(0f, 5f)]
		[SerializeField]
		public float _repulsionWeight;

		[Range(0f, 1f)]
		[SerializeField]
		public float _targetWeight;

		[Range(0f, 5f)]
		[SerializeField]
		public float _horizontalWeight;

		[Range(0f, 1f)]
		[SerializeField]
		public float _radiusWeight;

		[Range(0f, 10f)]
		[SerializeField]
		public float _reluctanceWeight;

		[SerializeField]
		[Range(0f, 5f)]
		public float _collisionRadius;

		[Range(0f, 10f)]
		[SerializeField]
		public float _collisionWeight;

		[SerializeField]
		public LayerMask _colliderMask;

		[SerializeField]
		[Range(10f, 100f)]
		public int _colliderBufferSize;

		[SerializeField]
		public bool _warnColliderBufferOverflow;

		[NonSerialized]
		public int _cachedCount;

		[NonSerialized]
		public NativeArray<Vector3> _positions;

		[NonSerialized]
		public NativeArray<Vector3> _velocities;

		[NonSerialized]
		public NativeArray<Vector3> _previousVelocities;

		[NonSerialized]
		public NativeArray<Vector3> _readOnlyPositions;

		[NonSerialized]
		public NativeArray<Vector3> _readOnlyVelocities;

		[NonSerialized]
		public NativeArray<Vector3> _readOnlyPreviousVelocities;

		[NonSerialized]
		public NativeArray<Bounds> _boundsBuffer;

		[NonSerialized]
		public Matrix4x4[] _matrices;

		[NonSerialized]
		public Vector3[] _scales;

		[NonSerialized]
		public float[] _spawns;

		[NonSerialized]
		public MaterialPropertyBlock _propertyBlock;

		[NonSerialized]
		public Vector4[] _colorPropertyBuffer;

		[NonSerialized]
		public Vector4[] _velocityCurrentPropertyBuffer;

		[NonSerialized]
		public Vector4[] _velocityPreviousPropertyBuffer;

		[NonSerialized]
		public int _instanceColorPropertyId;

		[NonSerialized]
		public int _instanceCountPropertyId;

		[NonSerialized]
		public int _velocityCurrentPropertyId;

		[NonSerialized]
		public int _velocityPreviousPropertyId;

		[NonSerialized]
		public Collider[] _colliderBuffer;

		[NonSerialized]
		public int _colliderCount;

		public void SetCount(int count)
		{
		}

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
