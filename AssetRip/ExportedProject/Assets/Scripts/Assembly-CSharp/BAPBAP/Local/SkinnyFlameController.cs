using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class SkinnyFlameController : MonoBehaviour
	{
		[SerializeField]
		public float maxDistance;

		[SerializeField]
		public float intensity;

		[SerializeField]
		public float lerpSpeed;

		[NonSerialized]
		public Vector3 newDirection;

		[NonSerialized]
		public Vector3 prevPos;

		[SerializeField]
		public Transform flameParent;

		[SerializeField]
		public Renderer flameMat;

		[SerializeField]
		public Renderer flameMatRed;

		public static readonly int DirectionX_ShaderProperty;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
