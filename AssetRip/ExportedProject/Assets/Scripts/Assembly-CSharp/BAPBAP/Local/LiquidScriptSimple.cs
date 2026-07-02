using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class LiquidScriptSimple : MonoBehaviour
	{
		[NonSerialized]
		public Renderer rend;

		public EntityMovement charMove;

		public float fillAmount;

		[NonSerialized]
		public float prevFillAmount;

		public float speed;

		[NonSerialized]
		public float amountX;

		[NonSerialized]
		public float amountZ;

		public static readonly int FillAmount_ShaderProperty;

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
