using System;
using UnityEngine;

namespace Gamekit3D
{
	public class EllenSpawn : MonoBehaviour
	{
		[HideInInspector]
		public float effectTime;

		public Material[] EllenRespawnMaterials;

		public GameObject respawnParticles;

		[NonSerialized]
		public Material[] EllenMaterials;

		[NonSerialized]
		public MaterialPropertyBlock m_PropertyBlock;

		[NonSerialized]
		public Renderer m_Renderer;

		[NonSerialized]
		public Vector4 pos;

		[NonSerialized]
		public Vector3 renderBounds;

		public const string k_BoundsName = "_bounds";

		public const string k_CutoffName = "_Cutoff";

		[NonSerialized]
		public float m_Timer;

		[NonSerialized]
		public float m_EndTime;

		[NonSerialized]
		public bool m_Started;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void StartEffect()
		{
		}

		public void Update()
		{
		}

		public void Set(float cutoff)
		{
		}
	}
}
