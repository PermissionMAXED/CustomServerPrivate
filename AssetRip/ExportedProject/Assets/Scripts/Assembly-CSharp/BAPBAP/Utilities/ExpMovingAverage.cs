using System;

namespace BAPBAP.Utilities
{
	public class ExpMovingAverage
	{
		[NonSerialized]
		public readonly float alpha;

		[NonSerialized]
		public bool initialized;

		public float Value { get; set; }

		public float Var { get; set; }

		public ExpMovingAverage(int n)
		{
		}

		public void Add(float newValue)
		{
		}
	}
}
