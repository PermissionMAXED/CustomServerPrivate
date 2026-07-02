using System;

namespace BAPBAP.Network.EventData
{
	public struct WarpEventData : IEquatable<WarpEventData>
	{
		public int predTickNum;

		public override string ToString()
		{
			return null;
		}

		public bool Equals(WarpEventData eventData)
		{
			return false;
		}
	}
}
