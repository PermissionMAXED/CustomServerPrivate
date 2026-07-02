using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SetCharMaterialBaseColor : MonoBehaviour
	{
		[NonSerialized]
		public CharMaterial charMaterial;

		[SerializeField]
		public Color color;

		public void Awake()
		{
		}

		public void SetColor()
		{
		}
	}
}
