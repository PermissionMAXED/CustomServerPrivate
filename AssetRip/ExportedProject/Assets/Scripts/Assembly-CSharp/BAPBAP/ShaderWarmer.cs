using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace BAPBAP
{
	public class ShaderWarmer : MonoBehaviour
	{
		public class ShaderWarmerPass : ScriptableRenderPass
		{
			public Material[] Materials { get; set; }

			public Mesh Mesh { get; set; }

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}
		}

		[SerializeField]
		public Material[] _mats;

		[SerializeField]
		public Mesh _mesh;

		[NonSerialized]
		public ShaderWarmerPass pass;

		public void OnEnable()
		{
		}

		public void RenderMaterials(ScriptableRenderContext context, Camera cam)
		{
		}

		public void DidRender()
		{
		}
	}
}
