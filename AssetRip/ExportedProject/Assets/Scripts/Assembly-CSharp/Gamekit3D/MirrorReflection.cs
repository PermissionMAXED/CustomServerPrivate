using System;
using UnityEngine;

namespace Gamekit3D
{
	[ExecuteInEditMode]
	public class MirrorReflection : MonoBehaviour
	{
		public Texture lowQualityTexture;

		public static bool insideRendering;

		public Camera mainCamera;

		public Camera reflectionCamera;

		public int textureSize;

		public float clipPlaneOffset;

		[NonSerialized]
		public RenderTexture reflectionTexture;

		[NonSerialized]
		public int reflectionTexID;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnWillRenderObject()
		{
		}

		public Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
		{
			return default(Vector4);
		}

		public static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
		{
		}
	}
}
