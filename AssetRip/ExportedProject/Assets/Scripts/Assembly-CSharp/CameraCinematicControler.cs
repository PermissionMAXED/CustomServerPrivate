using System;
using System.Collections.Generic;
using BAPBAP.Debugging;
using BAPBAP.Local;
using Dreamteck.Splines;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCinematicControler : MonoBehaviour
{
	[NonSerialized]
	public InputSystem inputSystem;

	[SerializeField]
	public float moveSpeed;

	[SerializeField]
	public float accSlowMultiplier;

	[SerializeField]
	public float accSprintMultiplier;

	[SerializeField]
	public float lookSensitivity;

	[SerializeField]
	public float fowSpeed;

	[SerializeField]
	public float fovFactorIncreaseMultiplier;

	[SerializeField]
	public float thirdPersonAimMultiplier;

	[SerializeField]
	public float moveSmoothFactor;

	[SerializeField]
	public float followSmoothFactor;

	[SerializeField]
	public float rotationSmoothFactor;

	[SerializeField]
	public float snapshotLerpSpeed;

	[Tooltip("Once first entering cinematic mode, should start focused on the camera by default?")]
	[SerializeField]
	public bool focusOnEnable;

	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public Transform currentFollowTarget;

	[NonSerialized]
	public Vector3 offsetTargetPos;

	[NonSerialized]
	public float originalFov;

	[NonSerialized]
	public float targetFov;

	[NonSerialized]
	public Vector2 lookRot;

	[NonSerialized]
	public Quaternion targetRotation;

	[NonSerialized]
	public Vector3 velocity;

	[NonSerialized]
	public bool followRail;

	[NonSerialized]
	public bool horizontalLock;

	[NonSerialized]
	public bool thirdPersonFollow;

	[NonSerialized]
	public bool focused;

	[NonSerialized]
	public bool playingSnapshot;

	[NonSerialized]
	public bool reversePlayback;

	[NonSerialized]
	public bool snapshotLerpApplyPos;

	[NonSerialized]
	public bool snapshotLerpApplyRot;

	[NonSerialized]
	public float snapshotProgress;

	[NonSerialized]
	public bool snapshotSplineEnabled;

	[NonSerialized]
	public Spline snapshotSplinePath;

	[NonSerialized]
	public CameraRail currentRail;

	[NonSerialized]
	public float currentRailTime;

	public List<DebugCinematicManager.CameraSnapshot> snapshots => null;

	public float MoveSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float FollowSmoothFactor
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float MoveSmoothFactor
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float LookSensitivity
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float RotationSmoothFactor
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float FowLerpSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool HorizontalLock
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ThirdPersonFollow
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Quaternion TargetRotation
	{
		get
		{
			return default(Quaternion);
		}
		set
		{
		}
	}

	public bool Focused => false;

	public bool PlayingSnapshot => false;

	public bool ReversePlayback
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool SnapshotSplineEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float SnapshotLerpSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool SnapshotLerpApplyPos
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool SnapshotLerpApplyRot
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float SnapshotProgress => 0f;

	public float SnapshotPlaybackNorm => 0f;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void LateUpdate()
	{
	}

	public void SnapshotPlayback(float dt)
	{
	}

	public void UpdateSnapshotSplinePath()
	{
	}

	public void GetClosestCameraRail()
	{
	}

	public Vector3 GetAimInput()
	{
		return default(Vector3);
	}

	public Vector3 GetMoveAccelVector()
	{
		return default(Vector3);
	}

	public void SetFocus(bool focus)
	{
	}

	public void SetFollowPlayer()
	{
	}

	public void SetFollowRail(bool isFollowing)
	{
	}

	public void PlaySnapshots()
	{
	}

	public void StopSnapshots()
	{
	}

	public void SnapToSnapshotPlaybackProgress(float progressNorm)
	{
	}

	public void SnapToSnapshot(DebugCinematicManager.CameraSnapshot snapshot)
	{
	}

	public void SetSpeed(float speed)
	{
	}

	public void IncreaseFov(float amount)
	{
	}

	public void DecreaseFov(float amount)
	{
	}

	public void ResetFov()
	{
	}

	public void SetFov(float fow)
	{
	}
}
