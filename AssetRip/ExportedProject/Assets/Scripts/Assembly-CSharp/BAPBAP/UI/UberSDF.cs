using System;
using UnityEngine;

namespace BAPBAP.UI
{
	[ExecuteAlways]
	[DefaultExecutionOrder(-100)]
	public class UberSDF : MonoBehaviour
	{
		[SerializeField]
		public UberSDFEventHandler eventHandler;

		[SerializeField]
		[Min(0f)]
		public float transitionDuration;

		[SerializeField]
		public AnimationCurve transitionCurve;

		[SerializeField]
		public SDF.Type Type;

		[SerializeField]
		public SDF.Operation OpType;

		[SerializeField]
		public float Roundness;

		[SerializeField]
		public float ShapeInfo1;

		[SerializeField]
		public float ShapeInfo2;

		[SerializeField]
		public float ShapeInfo3;

		[SerializeField]
		public float ShapeInfo4;

		[SerializeField]
		public float OffsetX;

		[SerializeField]
		public float OffsetY;

		[SerializeField]
		public float Rotation;

		[SerializeField]
		public float Scale;

		[SerializeField]
		public int PolygonPointCount;

		public Action OnDescriptorChanged;

		[NonSerialized]
		public Vector4[] PolygonPoints;

		[SerializeField]
		public Vector4 Point0;

		[SerializeField]
		public Vector4 Point1;

		[SerializeField]
		public Vector4 Point2;

		[SerializeField]
		public Vector4 Point3;

		[SerializeField]
		public Vector4 Point4;

		[SerializeField]
		public Vector4 Point5;

		[SerializeField]
		public Vector4 Point6;

		[SerializeField]
		public Vector4 Point7;

		[SerializeField]
		public Vector4 Point8;

		[SerializeField]
		public Vector4 Point9;

		[NonSerialized]
		public UberSDFSO targetSO;

		[NonSerialized]
		public float transitionTime;

		public Vector4[] GetPolygonPoints()
		{
			return null;
		}

		public void SetPolygonPoint(int index, Vector4 point)
		{
		}

		public void SetPolygonPoints(Vector4[] points)
		{
		}

		public void SetFromSO(UberSDFSO sdfso)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void Update()
		{
		}

		public void OnDidApplyAnimationProperties()
		{
		}

		public void OnValidate()
		{
		}

		public void HandlerRefresh()
		{
		}
	}
}
