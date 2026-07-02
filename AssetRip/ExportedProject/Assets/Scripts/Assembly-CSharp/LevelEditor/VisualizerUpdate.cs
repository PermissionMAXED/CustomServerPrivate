using System;
using UnityEngine;

namespace LevelEditor
{
	public class VisualizerUpdate : MonoBehaviour
	{
		[NonSerialized]
		public MeshRenderer visualizerRenderer;

		[NonSerialized]
		public Color visualizerBaseColor;

		public void Awake()
		{
		}

		public void Update()
		{
		}
	}
}
