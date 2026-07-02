using UnityEngine;

namespace FastScriptReload.Examples
{
	public class FunctionLibrary : MonoBehaviour
	{
		public delegate Vector3 Function(float u, float v, float t);

		public enum FunctionName
		{
			Wave = 0,
			MultiWave = 1,
			Ripple = 2,
			Sphere = 3,
			Torus = 4
		}

		public static readonly Function[] functions;

		public static Function GetFunction(FunctionName name)
		{
			return null;
		}

		public static Vector3 Wave(float u, float v, float t)
		{
			return default(Vector3);
		}

		public static Vector3 MultiWave(float u, float v, float t)
		{
			return default(Vector3);
		}

		public static Vector3 Ripple(float u, float v, float t)
		{
			return default(Vector3);
		}

		public static Vector3 Sphere(float u, float v, float t)
		{
			return default(Vector3);
		}

		public static Vector3 Torus(float u, float v, float t)
		{
			return default(Vector3);
		}
	}
}
