using System;
using UnityEngine;

namespace FastScriptReload.Examples
{
	public class Graph : MonoBehaviour
	{
		[SerializeField]
		public Transform pointPrefab;

		[Range(10f, 100f)]
		[SerializeField]
		public int resolution;

		[SerializeField]
		public FunctionLibrary.FunctionName function;

		[NonSerialized]
		public Transform[] points;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnScriptHotReload()
		{
		}

		public static void OnScriptHotReloadNoInstance()
		{
		}
	}
}
