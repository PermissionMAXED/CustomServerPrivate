using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class SinCityLivesTracker : MonoBehaviour
	{
		public struct SinLives
		{
			public int playerId;

			public int lives;

			public SinLives(int playerId, int lives)
			{
				this.playerId = 0;
				this.lives = 0;
			}
		}

		[SerializeField]
		public P_SinCity_RespawnTracker_SO P_RespawnTracker_SO;

		[NonSerialized]
		public List<SinLives> players;

		public int GetLives(int playerId)
		{
			return 0;
		}

		public void RemoveLife(int playerId)
		{
		}
	}
}
