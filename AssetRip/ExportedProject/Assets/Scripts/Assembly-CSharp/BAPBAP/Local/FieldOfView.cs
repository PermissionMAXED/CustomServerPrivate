using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Local
{
	[ExecuteInEditMode]
	public class FieldOfView : MonoBehaviour
	{
		public struct ViewCastInfo
		{
			public bool hit;

			public Vector3 point;

			public float dst;

			public float angle;

			public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
			{
				hit = false;
				point = default(Vector3);
				dst = 0f;
				angle = 0f;
			}
		}

		public struct EdgeInfo
		{
			public Vector3 pointA;

			public Vector3 pointB;

			public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
			{
				pointA = default(Vector3);
				pointB = default(Vector3);
			}
		}

		[CompilerGenerated]
		public sealed class _003CFindTargetsWithDelay_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float delay;

			public FieldOfView _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFindTargetsWithDelay_003Ed__12(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public float viewRadius;

		[Range(0f, 360f)]
		public float viewAngle;

		public LayerMask targetMask;

		public LayerMask obstacleMask;

		[HideInInspector]
		public List<Transform> visibleTargets;

		public float meshResolution;

		public int edgeResolveIterations;

		public float edgeDstThreshold;

		public float maskCutawayDst;

		public MeshFilter viewMeshFilter;

		[NonSerialized]
		public Mesh viewMesh;

		public void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CFindTargetsWithDelay_003Ed__12))]
		public IEnumerator FindTargetsWithDelay(float delay)
		{
			return null;
		}

		public void LateUpdate()
		{
		}

		public void FindVisibleTargets()
		{
		}

		public void DrawFieldOfView()
		{
		}

		public EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
		{
			return default(EdgeInfo);
		}

		public ViewCastInfo ViewCast(float globalAngle)
		{
			return default(ViewCastInfo);
		}

		public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
		{
			return default(Vector3);
		}
	}
}
