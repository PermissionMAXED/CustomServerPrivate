using System;

namespace BAPBAP.Utilities
{
	[Serializable]
	public struct IntRange
	{
		public int min;

		public int max;

		public IntRange(int min = 0, int max = 1)
		{
			this.min = 0;
			this.max = 0;
		}
	}
}
