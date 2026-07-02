using System;
using BAPBAP.Entities;

namespace BAPBAP.Network.EventData
{
	public struct AnimEventData : IEquatable<AnimEventData>
	{
		public int predTickNum;

		public AnimLayerIndices layerIndex;

		public int stateHash;

		public float time;

		public override string ToString()
		{
			return null;
		}

		public bool Equals(AnimEventData eventData)
		{
			return false;
		}
	}
}
