using System;
using System.Collections.Generic;
using BAPBAP.Player;
using UnityEngine;

namespace BAPBAP.Systems
{
	public class PlayerSystem : MonoBehaviour
	{
		[NonSerialized]
		public List<PlayerManager> components;

		public void Register(PlayerManager playerManager)
		{
		}

		public void Unregister(PlayerManager playerManager)
		{
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
