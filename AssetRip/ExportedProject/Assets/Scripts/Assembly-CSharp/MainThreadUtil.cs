using System.Collections;
using System.Threading;
using UnityEngine;

public class MainThreadUtil : MonoBehaviour
{
	public static MainThreadUtil Instance { get; set; }

	public static SynchronizationContext synchronizationContext { get; set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Setup()
	{
	}

	public static void Run(IEnumerator waitForUpdate)
	{
	}

	public void Awake()
	{
	}
}
