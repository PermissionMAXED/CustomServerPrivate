using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcSetCmdAimWorldPosSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public float futureTime;

		[NonSerialized]
		public float randomSpreadAmount;

		[NonSerialized]
		public bool flipDirection;

		[NonSerialized]
		public float predictMultiplier;

		[NonSerialized]
		public float predictUnaccuracy;

		[NonSerialized]
		public bool doOnTick;

		public NpcSetCmdAimWorldPosSubroutine(NpcBehaviour _behaviour, AbilityTriggerData abilityTriggerData, float _predictMultiplier = 1f, float _predictUnaccuracy = 0f)
		{
		}

		public NpcSetCmdAimWorldPosSubroutine(NpcBehaviour _behaviour, float _futureTime, float _randomSpreadAmount, bool _flipDirection, float _predictMultiplier = 1f, float _predictUnaccuracy = 0f, bool _doOnTick = false)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public Vector3 GetCmdAimWorldPos()
		{
			return default(Vector3);
		}

		public Vector3 GetPredictedFuturePosition(Vector3 targetPos, Vector3 targetCurrentVelocity, float futureTime, float predictMultiplier = 1f, float predictUnaccuracy = 0f)
		{
			return default(Vector3);
		}

		public Vector3 GetRandomSpread(float randomSpreadAmount)
		{
			return default(Vector3);
		}
	}
}
