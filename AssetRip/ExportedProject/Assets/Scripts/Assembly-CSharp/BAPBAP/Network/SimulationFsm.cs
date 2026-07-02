using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using Mirror;

namespace BAPBAP.Network
{
	public class SimulationFsm
	{
		public class Builder
		{
			[NonSerialized]
			public SimulationFsm _fsm;

			[NonSerialized]
			public byte currentBuilderState;

			public Builder State(byte state)
			{
				return null;
			}

			public Builder AddSubroutine(SimulationSubroutine subroutine)
			{
				return null;
			}

			public Builder AddTransition(byte trigger, byte state)
			{
				return null;
			}

			public Builder Start(byte startState)
			{
				return null;
			}

			public SimulationFsm Build()
			{
				return null;
			}
		}

		[NonSerialized]
		public Dictionary<byte, List<SimulationSubroutine>> subroutinesByState;

		[NonSerialized]
		public Dictionary<byte, Dictionary<byte, byte>> transitionsByState;

		[NonSerialized]
		public List<SimulationSubroutine> allSubroutines;

		[NonSerialized]
		public List<NetworkedSimulationSubroutine> networkedSubroutines;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public float remainderFixedDt;

		[NonSerialized]
		public byte externalTrigger;

		public byte currentState;

		public void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void OnTick(Command cmd, bool isResim)
		{
		}

		public void OnEnter(Command cmd, bool isResim)
		{
		}

		public void OnExit(Command cmd, bool isResim)
		{
		}

		public void Fire(byte trigger, Command cmd, bool isResim)
		{
		}

		public void FireExternal(byte trigger)
		{
		}

		public void FireExternalImmediate(byte trigger)
		{
		}

		public void ChangeState(byte stateId)
		{
		}

		public void SetNewRemainderFixedDt(float _remainderFixedDt)
		{
		}

		public void DeBuild()
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}
	}
}
