using System;
using UnityEngine;

namespace BAPBAP.UI
{
	[ExecuteAlways]
	[RequireComponent(typeof(Animator))]
	public class UberSDFAnimator : MonoBehaviour
	{
		[NonSerialized]
		public Animator animator;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnValidate()
		{
		}

		public void CheckWriteDefaults()
		{
		}
	}
}
