using System;
using BAPBAP.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]
public class LookAtTargetConstraint : MonoBehaviour
{
	[Space(10f)]
	[SerializeField]
	public Transform currentTarget;

	[SerializeField]
	[Tooltip("The bone to apply the look transform to, usually the character's head bone.")]
	[Header("References")]
	public Transform lookTransform;

	[Tooltip("Adds a local rotation offset to the look transform. Use this to fine tune the look end result if needed, for example for head bones where the z axis is not aligned correctly to the front of the face.")]
	[SerializeField]
	public Vector3 lookTrLocalOffset;

	[Header("Settings")]
	[Tooltip("Range for blending the look constraint. 0 = no look rotation, 1 = full look rotation.")]
	[SerializeField]
	[Range(0f, 1f)]
	[FormerlySerializedAs("blendFactor")]
	public float weight;

	[Tooltip("The lerp speed to look towards the target. The higher the value is, the snappier the lerp will be.")]
	[SerializeField]
	[Min(0f)]
	public float lookSmoothFactor;

	[Tooltip("The lerp speed to increase or decrease the constraint weight, based on if the target exists. The higher the value is, the snappier the lerp will be.")]
	[SerializeField]
	[Min(0f)]
	public float targetWeightSpeed;

	[Range(0f, 360f)]
	[SerializeField]
	[Tooltip("The limit in radius angle from the original orientation to follow the target. Setting this to 0 or 360 will ignore this setting.")]
	public float angleFollowLimit;

	[Tooltip("When reaching the angle limit, keep the clamped rotation applied. If disabled, returns to the original orientation.")]
	[SerializeField]
	public bool clampAngleLimit;

	[SerializeField]
	[Tooltip("If the base transform turns, should the current rotation should inherit that velocity?")]
	public bool inheritTurnVelocity;

	[Tooltip("Make the applied constraint additive to the current rotation of the look transform.")]
	[SerializeField]
	public bool additiveBlending;

	[SerializeField]
	[Header("AI Behaviour")]
	[Tooltip("If enabled, randomly stop looking at the target temporarely. Intended for use with ai to appear less robotic.")]
	public bool doRandomTempTargetDisable;

	[SerializeField]
	public RangeFloat randomTempDisableTimeRange;

	[NonSerialized]
	public float targetWeight;

	[NonSerialized]
	public bool useAngleLimit;

	[NonSerialized]
	public float halfFollowLimitDeg;

	[NonSerialized]
	public Quaternion prevRotation;

	[NonSerialized]
	public Quaternion currentRotation;

	[NonSerialized]
	public float randomTempTargetDisableNextTime;

	[NonSerialized]
	public bool randomTempTargetDisabled;

	public void OnValidate()
	{
	}

	public void Start()
	{
	}

	public void InitializeValues()
	{
	}

	public void SetTarget(Transform target)
	{
	}

	public void SetAngleFollowLimit(float angleLimit)
	{
	}

	public void LateUpdate()
	{
	}

	public void ProcessRotation()
	{
	}

	public void ApplyConstraint()
	{
	}

	public bool GetAngleLimitEnabled()
	{
		return false;
	}
}
