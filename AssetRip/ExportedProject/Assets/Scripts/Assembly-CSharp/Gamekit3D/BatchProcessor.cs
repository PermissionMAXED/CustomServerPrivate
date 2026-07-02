using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
	public class BatchProcessor : MonoBehaviour
	{
		public delegate void BatchProcessing();

		public static BatchProcessor s_Instance;

		public static List<BatchProcessing> s_ProcessList;

		static BatchProcessor()
		{
		}

		public static void RegisterBatchFunction(BatchProcessing function)
		{
		}

		public static void UnregisterBatchFunction(BatchProcessing function)
		{
		}

		public void Update()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		public static void Init()
		{
		}
	}
}
