using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraDriver : MonoBehaviour
	{
		[NonSerialized]
		public CameraController controller;

		[NonSerialized]
		public Collider[] colliderBuffer;

		public Transform target => null;

		public Camera cam => null;

		public Vector3 collisionOffset => default(Vector3);

		public virtual void Initialize(CameraController _controller)
		{
		}

		public virtual void OnDriverEnable()
		{
		}

		public virtual void OnDriverDisable()
		{
		}

		public virtual void OnCamLockInputPressed()
		{
		}

		public virtual void OnLateUpdate()
		{
		}

		public virtual void Snap()
		{
		}

		public virtual void Zoom(float _zoomMultiplier)
		{
		}

		public virtual void ResetZoom()
		{
		}

		public virtual void SetFoVMultiplier(float fovMultiplier)
		{
		}

		public virtual Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}

		public bool GetViewIsObscured()
		{
			return false;
		}
	}
}
