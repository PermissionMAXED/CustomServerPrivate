using System;

namespace BAPBAP.Utilities
{
	[Serializable]
	public struct ByteRange
	{
		public byte min;

		public byte max;

		public ByteRange(byte min = 0, byte max = 1)
		{
			this.min = 0;
			this.max = 0;
		}
	}
}
