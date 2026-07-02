namespace BAPBAP.Entities.View
{
	public struct SnapLerpData
	{
		public int tickNum;

		public bool snapped;

		public SnapLerpData(int tickNum, bool snapped)
		{
			this.tickNum = 0;
			this.snapped = false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
