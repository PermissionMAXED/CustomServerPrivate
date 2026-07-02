using UnityEngine;

namespace BAPBAP.UI
{
	public static class SDF
	{
		public enum Type
		{
			Polygon = 0,
			Parallelogram = 1,
			BlobbyCross = 2,
			Rhombus = 3,
			Segment = 4,
			RoundedBox = 5,
			Circle = 6,
			RoundedCross = 7,
			EquilateralTriangle = 8,
			Polygon10 = 9
		}

		public enum Operation
		{
			Union = 0,
			Intersection = 1,
			Subtraction = 2
		}

		public static readonly int OutlineSize;

		public static readonly int OutlineColor;

		public static readonly int OutlineKnockout;

		public static readonly int SDFDataCount;

		public static readonly int SDFData0;

		public static readonly int Polygons0;

		public static readonly int PolygonCount0;

		public static readonly int SDFData1;

		public static readonly int Polygons1;

		public static readonly int PolygonCount1;

		public static readonly int SDFData2;

		public static readonly int Polygons2;

		public static readonly int PolygonCount2;

		public static readonly int SDFData3;

		public static readonly int Polygons3;

		public static readonly int PolygonCount3;

		public static readonly int SampleSDFSoft;

		public static readonly int Softness;

		public static readonly int SampleOutlineSoft;

		public static readonly int OutlineSoftness;

		public static Matrix4x4 ConvertToMatrixArray(this UberSDF sdf)
		{
			return default(Matrix4x4);
		}

		public static Matrix4x4 ConvertToMatrixArray(this UberSDFSO sdfso)
		{
			return default(Matrix4x4);
		}

		public static void CopyTo(this UberSDF source, UberSDF target)
		{
		}

		public static void CopyTo(this UberSDFSO source, UberSDF target)
		{
		}

		public static void BlendToSO(this UberSDF target, UberSDFSO source, float blend)
		{
		}
	}
}
