using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Network.EventData
{
	public struct SfxEventData : IEquatable<SfxEventData>
	{
		public int predTickNum;

		public int sfxId;

		public SfxEventAction action;

		public SfxTarget target;

		public Vector3 position;

		public float pitchSpread;

		public float volume;

		public byte doLoop;

		public float sourceSizeMultiplier;

		public int instanceId;

		public override string ToString()
		{
			return null;
		}

		public bool Equals(SfxEventData eventData)
		{
			return false;
		}
	}
}
