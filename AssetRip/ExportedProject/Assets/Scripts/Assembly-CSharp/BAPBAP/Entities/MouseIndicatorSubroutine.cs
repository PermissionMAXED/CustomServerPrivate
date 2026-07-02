using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MouseIndicatorSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public IndicatorMouse indMouse;

		[NonSerialized]
		public bool indicatorActive;

		public MouseIndicatorSubroutine(Ability ability, GameObject indicatorPrefab, Vector2 mouseHalfScale, Vector2 baseHalfScale, Vector2 offset, float maxDistance, float angleSpread, bool rotateWithDirection, bool collidesWithWall = false)
		{
		}

		public override void DeBuild()
		{
		}

		public void SpawnIndicator(GameObject indicatorPrefab, Vector2 mouseHalfScale, Vector2 baseHalfScale, Vector2 offset, float maxDistance, float angleSpread, bool rotateWithDirection, bool collidesWithWall = false)
		{
		}

		public void DestroyIndicator()
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public IndicatorMouse GetIndicatorObject()
		{
			return null;
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
