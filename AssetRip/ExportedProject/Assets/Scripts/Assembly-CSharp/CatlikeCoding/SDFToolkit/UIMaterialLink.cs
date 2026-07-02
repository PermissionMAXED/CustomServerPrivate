using System;
using UnityEngine;

namespace CatlikeCoding.SDFToolkit
{
	[Obsolete("UIMaterialLink is no longer needed to make keyword materials work at run time. It will be removed in a future release.")]
	[ExecuteInEditMode]
	public class UIMaterialLink : MonoBehaviour
	{
		[SerializeField]
		public Material sourceMaterial;

		[NonSerialized]
		[NonSerialized]
		public string[] shaderKeywords;

		public Material SourceMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}
	}
}
