using System;

namespace BAPBAP.Utilities
{
	public class ExpMovingAverageDouble
	{
		[NonSerialized]
		public readonly float alpha;

		[NonSerialized]
		public bool initialized;

		public double Value { get; set; }

		public double Var { get; set; }

		public ExpMovingAverageDouble(int n)
		{
		}

		public void Add(double newValue)
		{
		}
	}
}
