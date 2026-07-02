using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DirectionalIndicatorSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public IndicatorDirectional indDirectional;

		[NonSerialized]
		public bool indicatorActive;

		public DirectionalIndicatorSubroutine(Ability ability, GameObject indicatorPrefab, Vector2 halfScale, Vector2 offset, bool doCollision, bool isExpanding, bool clampToMouse, bool followMouse)
		{
		}

		public void SpawnIndicator(GameObject indicatorPrefab, Vector2 halfScale, Vector2 offset, bool doCollision, bool isExpanding, bool clampToMouse, bool followMouse)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void ClSetIndicatorState(bool isEnabled)
		{
		}

		public void OnIndicatorChanged()
		{
		}

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
		{
		}
	}
}
