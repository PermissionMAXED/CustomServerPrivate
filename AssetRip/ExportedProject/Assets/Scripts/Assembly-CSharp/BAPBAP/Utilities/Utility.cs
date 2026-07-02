using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Utilities
{
	public static class Utility
	{
		public static char[] separatorChars;

		public static Vector3 GetDirection(Vector3 from, Vector3 to)
		{
			return default(Vector3);
		}

		public static Vector3 GetDirectionNormalized(Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}

		public static Vector3 GetPerpendicularNormalized(Vector3 direction)
		{
			return default(Vector3);
		}

		public static float GetRandomAngle(float spread, float seededRandom)
		{
			return 0f;
		}

		public static int GetRandomIndex(float[] probabilityPerIndex)
		{
			return 0;
		}

		public static int GetRandomIndex<T>(T[] array, Func<T, float> func)
		{
			return 0;
		}

		public static int GetRandomIndex<T>(List<T> list, Func<T, float> func)
		{
			return 0;
		}

		public static float TripleRaycastMinDistance(Vector3 center, Vector3 side1, Vector3 side2, Vector3 direction, float centerMaxDistance, float sideMaxDistance, LayerMask layerMask)
		{
			return 0f;
		}

		public static Vector3 FindRaycastObstaclePoint(Transform charTransform, Vector3 targetPos, LayerMask obstacleMask, float maxDistance, float radiusCheck)
		{
			return default(Vector3);
		}

		public static bool IsPositionOnNavMesh(Vector3 position)
		{
			return false;
		}

		public static bool IsPositionOnNavMesh(Vector3 position, float radius = 2f)
		{
			return false;
		}

		public static Vector3 FindPointNavMesh(Vector3 point, float radius)
		{
			return default(Vector3);
		}

		public static Vector3 FindPointNavMeshExpandingSphere(Vector3 dest)
		{
			return default(Vector3);
		}

		public static Vector3 FindPointNavMeshSphereCast(Vector3 src, Vector3 dest, float radius)
		{
			return default(Vector3);
		}

		public static Vector3 FindAdjustedNavMeshSphereCast(Vector3 src, Vector3 dest, float radius, float maxRange, LayerMask obstacleMask)
		{
			return default(Vector3);
		}

		public static Mesh GenerateCurrentNavMeshMesh()
		{
			return null;
		}

		public static void Shift<T>(this List<T> list, int index, int newIndex)
		{
		}

		public static void ShuffleArray<T>(T[] array)
		{
		}

		public static void ShuffleList<T>(this IList<T> ts, int seed = int.MaxValue)
		{
		}

		public static T[,] ResizeArray<T>(T[,] original, int x, int y)
		{
			return null;
		}

		public static T[] Array2DTo1D<T>(T[,] source)
		{
			return null;
		}

		public static T[,] Array1DTo2D<T>(T[] source, Vector2Int size)
		{
			return null;
		}

		public static byte[] ColorToByteArray(Color[] colors)
		{
			return null;
		}

		public static Color[] ByteToColorArray(byte[] bytes)
		{
			return null;
		}

		public static T[][] NewJaggedArray<T>(int width, int height)
		{
			return null;
		}

		public static Vector2Int GetJaggedArraySize<T>(T[][] jaggedArray)
		{
			return default(Vector2Int);
		}

		public static bool CompareLists<T>(List<T> a, List<T> b)
		{
			return false;
		}

		public static float SamplePerlinNoise(float x, float y)
		{
			return 0f;
		}

		public static Texture2D GetImageFromColorArray(Color[] pixelColors, int textureResolution, FilterMode filterMode = FilterMode.Bilinear)
		{
			return null;
		}

		public static void ClearRenderTexture(RenderTexture renderTexture)
		{
		}

		public static void ResizeRenderTexture(RenderTexture renderTexture, int width, int height)
		{
		}

		public static float Remap(this float aValue, float aIn1, float aIn2, float aOut1, float aOut2)
		{
			return 0f;
		}

		public static bool IsBetween<T>(this T value, T minValue, T maxValue) where T : IComparable<T>
		{
			return false;
		}

		public static bool TryCast<T>(this object obj, out T result)
		{
			result = default(T);
			return false;
		}

		public static Vector2 xz(this Vector3 v)
		{
			return default(Vector2);
		}

		public static Vector2 xy(this Vector3 v)
		{
			return default(Vector2);
		}

		public static Vector3 v3(this Vector2 v)
		{
			return default(Vector3);
		}

		public static Vector2 x(this Vector2 v, float x)
		{
			return default(Vector2);
		}

		public static Vector2 y(this Vector2 v, float y)
		{
			return default(Vector2);
		}

		public static Vector3 x(this Vector3 v, float x)
		{
			return default(Vector3);
		}

		public static Vector3 y(this Vector3 v, float y)
		{
			return default(Vector3);
		}

		public static Vector3 z(this Vector3 v, float z)
		{
			return default(Vector3);
		}

		public static Vector3 VectorFromYAngle(float yAngle)
		{
			return default(Vector3);
		}

		public static Vector3 Abs(this Vector3 v)
		{
			return default(Vector3);
		}

		public static Color alpha(this Color c, float a)
		{
			return default(Color);
		}

		public static bool MaskContainsLayer(this LayerMask mask, int layer)
		{
			return false;
		}

		public static string TryFormat(string formatStr, string str)
		{
			return null;
		}

		public static bool TryFormat(string formatStr, string str, out string result)
		{
			result = null;
			return false;
		}

		public static bool TryFormat(string formatStr, string[] strs, out string result)
		{
			result = null;
			return false;
		}

		public static string TryFormatFallback(ref string formatStr, string str, string formatTranslationKey)
		{
			return null;
		}

		public static string TryFormatCustom(string formatStr, string[] strs)
		{
			return null;
		}

		public static string GetPlusOrMinus(bool positive)
		{
			return null;
		}

		public static string GetIntPlusSign(int value)
		{
			return null;
		}

		public static string GetOrdNumStr(int number)
		{
			return null;
		}

		public static string GetTimeFormatted(TimeSpan timeSpan)
		{
			return null;
		}

		public static string GetTimeDifferenceFromNowHumanized(DateTime time)
		{
			return null;
		}

		public static void LogLastPressedKey()
		{
		}

		public static Transform RecursiveFindChild(Transform parent, string childName)
		{
			return null;
		}

		public static Texture2D TintTexture(Texture2D texture, Color color)
		{
			return null;
		}
	}
}
