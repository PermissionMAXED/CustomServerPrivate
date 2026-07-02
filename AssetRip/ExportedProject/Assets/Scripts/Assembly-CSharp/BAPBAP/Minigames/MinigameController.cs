using System;
using UnityEngine;

namespace BAPBAP.Minigames
{
	public class MinigameController : MonoBehaviour
	{
		[NonSerialized]
		public bool isPlaying;

		public Action<int> OnGameEnded;

		public void OnApplicationQuit()
		{
		}

		public void OnDisable()
		{
		}

		public virtual void OnGameStart()
		{
		}

		public virtual void OnGameEnd()
		{
		}
	}
}
