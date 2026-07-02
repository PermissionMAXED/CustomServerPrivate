using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class PostCameraMouse : MonoBehaviour
	{
		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public int groundMask;

		[NonSerialized]
		public Camera mainCamera;

		[NonSerialized]
		public RaycastHit[] mouseHits;

		[NonSerialized]
		public Ray mouseRay;

		[HideInInspector]
		public Vector3 worldMousePos;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
