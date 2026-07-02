using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class LiquidScript : MonoBehaviour
	{
		[NonSerialized]
		public Renderer rend;

		[NonSerialized]
		public Vector3 lastPos;

		[NonSerialized]
		public Vector3 velocity;

		[NonSerialized]
		public Vector3 lastRot;

		[NonSerialized]
		public Vector3 angularVelocity;

		public float MaxWobble;

		public float WobbleSpeed;

		public float Recovery;

		[NonSerialized]
		public float wobbleAmountX;

		[NonSerialized]
		public float wobbleAmountZ;

		[NonSerialized]
		public float wobbleAmountToAddX;

		[NonSerialized]
		public float wobbleAmountToAddZ;

		[NonSerialized]
		public float pulse;

		[NonSerialized]
		public float time;

		public static readonly int WobbleX_ShaderProperty;

		public static readonly int WobbleZ_ShaderProperty;

		public void Start()
		{
		}

		public void Update()
		{
		}
	}
}
