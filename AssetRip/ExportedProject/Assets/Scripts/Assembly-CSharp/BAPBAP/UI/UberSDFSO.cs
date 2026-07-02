using UnityEngine;

namespace BAPBAP.UI
{
	[CreateAssetMenu(fileName = "UberSDFScriptableObject", menuName = "BAPBAP/UI/UberGraphic/SDF/UberSDFSO")]
	public class UberSDFSO : ScriptableObject
	{
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
		[HideInInspector]
		public int PolygonPointCount;

		[SerializeField]
		[HideInInspector]
		public Vector4 Point0;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point1;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point2;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point3;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point4;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point5;

		[SerializeField]
		[HideInInspector]
		public Vector4 Point6;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point7;

		[SerializeField]
		[HideInInspector]
		public Vector4 Point8;

		[HideInInspector]
		[SerializeField]
		public Vector4 Point9;
	}
}
