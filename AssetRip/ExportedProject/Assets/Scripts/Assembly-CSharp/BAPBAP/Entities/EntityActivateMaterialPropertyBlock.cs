using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateMaterialPropertyBlock : EntityActivateBase
	{
		[InspectorNote]
		[SerializeField]
		public string _note;

		[SerializeField]
		public Renderer _renderer;

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
		public readonly SyncList<bool> _lerpActivations;

		[NonSerialized]
		public readonly SyncList<int> _lerpFinishes;

		[NonSerialized]
		public float[] _lerpElapsedTimes;

		[SerializeField]
		[InspectorButton("ValidateKeywords")]
		public bool _validateKeywords;

		public MaterialPropertyBlock propertyBlock => null;

		public override void Awake()
		{
		}

		public override void OnValidate()
		{
		}

		public void ValidateKeywords()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		[Server]
		public override void Activate()
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnLerpActivationsChanged(SyncList<bool>.Operation op, int index, bool oldActivate, bool newActivate)
		{
		}

		public void OnLerpFinishesChanged(SyncList<int>.Operation op, int index, int oldFinish, int newFinish)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
