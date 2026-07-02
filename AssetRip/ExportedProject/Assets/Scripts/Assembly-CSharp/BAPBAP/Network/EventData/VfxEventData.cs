using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Network.EventData
{
	public struct VfxEventData : IEquatable<VfxEventData>
	{
		public int predTickNum;

		public int vfxId;

		public VfxEventAction action;

		public VfxTarget target;

		public Vector3 position;

		public Quaternion rotation;

		public byte attachableId;

		public int instanceId;

		public float rotateFixDelay;

		public override string ToString()
		{
			return null;
		}

		public bool Equals(VfxEventData eventData)
		{
			return false;
		}
	}
}
