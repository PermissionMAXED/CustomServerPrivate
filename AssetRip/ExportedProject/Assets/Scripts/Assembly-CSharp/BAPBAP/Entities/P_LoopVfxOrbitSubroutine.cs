using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_LoopVfxOrbitSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Passive passive;

		[NonSerialized]
		public VFXPassiveOrbit vfxPassiveOrbit;

		[NonSerialized]
		public GameObject loopVfxObj;

		[NonSerialized]
		public float vfxDestroyDelay;

		[NonSerialized]
		public bool showOnlyIfHasAuth;

		[NonSerialized]
		public bool isActive;

		[NonSerialized]
		public int count;

		[NonSerialized]
		public bool success;

		public P_LoopVfxOrbitSubroutine(Passive passive, GameObject loopVfxPrefab, Transform attachTransform, bool showOnlyIfHasAuth = false)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void OnActiveChanged()
		{
		}

		public void SetActive(bool a)
		{
		}

		public void OnDeactivate()
		{
		}

		public void SetOrbitAmount(int _amount, bool _success)
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
