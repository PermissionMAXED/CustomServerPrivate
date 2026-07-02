using System;
using BAPBAP.Entities;
using BAPBAP.Player;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GameModifier
	{
		[Serializable]
		public class GameModifierConfiguration
		{
			[Header("Properties")]
			public bool onlyOneInstance;

			[Header("UI Config")]
			public Sprite icon;

			public string titleTranslationKey;

			public string descTranslationKey;

			[NonSerialized]
			public string titleStr;

			[NonSerialized]
			public string descStr;
		}

		public int id;

		public virtual GameModifierConfiguration gmconfig => null;

		public GameModifier(GameModifierConfiguration _config = null)
		{
		}

		public virtual void Activate()
		{
		}

		public virtual void Deactivate()
		{
		}

		public virtual void OnTick(float dt)
		{
		}

		public virtual void ClActivate()
		{
		}

		public virtual void ClDeactivate()
		{
		}

		public virtual void OnPlayerCharSpawned(EntityManager entityManager)
		{
		}

		public virtual void OnPlayerKilled(PlayerManager killedPlayer, PlayerManager killerPlayer)
		{
		}

		public void InvokeForEachPlayer(Action<EntityManager> action)
		{
		}
	}
}
