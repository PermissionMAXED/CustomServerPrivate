using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

public class VFXMaterialPropertyBlock : MonoBehaviour
{
	[SerializeField]
	public bool _instanceMaterialOnActivate;

	[SerializeField]
	public bool _activeOnEnable;

	[SerializeField]
	public bool _passInBounds;

	[SerializeField]
	public Renderer _renderer;

	[SerializeField]
	[ConditionalHide("_passInBounds")]
	public Transform _boundsMatrixTransform;

	[SerializeField]
	public Material _targetMaterial;

	[ReadOnly]
	public bool HasValidIndex;

	[ReadOnly]
	public int TargetIndex;

	[SerializeField]
	public LerpProperty[] _properties;

	[NonSerialized]
	public MaterialPropertyBlock _propertyBlock;

	[NonSerialized]
	public List<bool> _lerpActivations;

	[NonSerialized]
	public List<int> _lerpFinishes;

	[NonSerialized]
	public float[] _lerpElapsedTimes;

	[NonSerialized]
	public Bounds _bounds;

	[NonSerialized]
	public Transform _boundsRoot;

	[NonSerialized]
	public BoxCollider _boxCollider;

	public static readonly int BoundsMin;

	public static readonly int BoundsMax;

	public static readonly int BoundsRoot;

	public static readonly int BoundsSize;

	[SerializeField]
	[InspectorButton("ApplyBounds")]
	public bool _applyBounds;

	public static readonly int BoundsMatrix;

	public MaterialPropertyBlock propertyBlock => null;

	public void OnValidate()
	{
	}

	public void ValidateKeywords()
	{
	}

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Activate()
	{
	}

	public void FixedUpdate()
	{
	}

	public void ApplyBounds()
	{
	}

	public bool HasProperty(string property)
	{
		return false;
	}

	public void SetActionOnTargetProperty(string property, Action action)
	{
	}
}
