using System;
using UnityEngine;

public class CameraOrbitControls : MonoBehaviour
{
	[SerializeField]
	public float lookSpeedH;

	[SerializeField]
	public float lookSpeedV;

	[SerializeField]
	public float zoomSpeed;

	[SerializeField]
	public float dragSpeed;

	[SerializeField]
	public float moveSpeed;

	[SerializeField]
	public int moveSpeedMultiplier;

	[HideInInspector]
	public float yaw;

	[HideInInspector]
	public float pitch;

	[HideInInspector]
	public bool isOrthographic;

	[NonSerialized]
	public float orthoDistance;

	[NonSerialized]
	public bool justFocused;

	public Camera cam;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void OnApplicationFocus(bool focusStatus)
	{
	}

	public void Update()
	{
	}

	public void ToggleProjection(bool orthographic)
	{
	}

	public void SetToTopView()
	{
	}

	public void LookAtPosition(Vector3 targetPosition)
	{
	}

	public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
	{
	}

	public float FOVToOrthographicSize(float distance)
	{
		return 0f;
	}

	public (float, Vector3) GroundPlaneDistanceAndIntersection()
	{
		return default((float, Vector3));
	}
}
