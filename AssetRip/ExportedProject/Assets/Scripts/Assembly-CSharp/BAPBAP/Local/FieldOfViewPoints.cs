using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FieldOfViewPoints : MonoBehaviour
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

		public List<Vector2> points;

		public float viewRadius;

		public LayerMask targetMask;

		public LayerMask obstacleMask;

		public float maskCutawayDst;

		public MeshFilter viewMeshFilter;

		[NonSerialized]
		public Mesh viewMesh;

		[NonSerialized]
		public BoxCollider boxCollider;

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnTriggerStay(Collider other)
		{
		}

		public void AddPoints(Collider collider)
		{
		}

		public void LateUpdate()
		{
		}

		public void DrawFieldOfView()
		{
		}

		public ViewCastInfo ViewCast(float angle)
		{
			return default(ViewCastInfo);
		}

		public float GetAngleFromDirection(Vector2 dir)
		{
			return 0f;
		}

		public Vector2 GetDirectionFromAngle(float angle)
		{
			return default(Vector2);
		}

		public int SortByAngle(ViewCastInfo p1, ViewCastInfo p2)
		{
			return 0;
		}
	}
}
