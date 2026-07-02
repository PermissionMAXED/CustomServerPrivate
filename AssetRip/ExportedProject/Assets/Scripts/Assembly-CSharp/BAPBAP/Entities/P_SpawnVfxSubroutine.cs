using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SpawnVfxSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Passive passive;

		[NonSerialized]
		public GameObject vfxPrefab;

		[NonSerialized]
		public Transform vfxParent;

		public P_SpawnVfxSubroutine(Passive passive, GameObject vfxPrefab, Transform attachTransform)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
