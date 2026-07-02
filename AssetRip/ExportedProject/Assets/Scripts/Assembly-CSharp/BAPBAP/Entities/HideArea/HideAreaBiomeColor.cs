using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Entities.HideArea
{
	[DefaultExecutionOrder(1)]
	public class HideAreaBiomeColor : MonoBehaviour
	{
		[NonSerialized]
		public HideArea hideArea;

		[NonSerialized]
		public Color areaColor;

		public static event Action OnBiomeColorUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void UpdateAreaMaterialColor()
		{
		}

		public void SetAreaMaterialColor(Color color)
		{
		}

		public static void TriggerBiomeColorUpdate()
		{
		}
	}
}
