using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(menuName = "BAPBAP/Selectable/SelectableResponseMaterialPropertyBlock")]
	public class SelectableResponseMaterialPropertyBlock : SelectableResponse
	{
		public class SelectableMPBInfo
		{
			public MeshRenderer meshRenderer;

			public MaterialPropertyBlock mpb;

			public LerpProperty[] lerpProperties;

			public float time;

			public bool animating;
		}

		public LerpProperty[] lerpProperties;

		[NonSerialized]
		public Dictionary<ISelectable, SelectableMPBInfo> activeTransforms;

		public override void Initialize(ISelectable selectable)
		{
		}

		public override void OnSelect(ISelectable selectable)
		{
		}

		public override void GeneralUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public override void OnDeselect(ISelectable selectable)
		{
		}
	}
}
