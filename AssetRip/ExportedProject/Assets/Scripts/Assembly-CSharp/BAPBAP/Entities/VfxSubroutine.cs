using System;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class VfxSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public VfxTarget vfxTarget;

		[NonSerialized]
		public VfxEventAction vfxAction;

		[NonSerialized]
		public int vfxId;

		[NonSerialized]
		public Vector3 position;

		[NonSerialized]
		public Quaternion rotation;

		[NonSerialized]
		public byte attachableId;

		[NonSerialized]
		public float rotateDelay;

		public VfxSubroutine(Ability ability, VfxEventAction vfxAction, VfxTarget vfxTarget, int vfxId, Vector3 position, Quaternion rotation, byte attachableId = 0, float rotateDelay = 0f)
		{
		}

		public VfxSubroutine(Ability ability, VfxEventAction vfxAction, VfxTarget vfxTarget, GameObject vfxPrefab, Vector3 position, Quaternion rotation, byte attachableId = 0, float rotateDelay = 0f)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
