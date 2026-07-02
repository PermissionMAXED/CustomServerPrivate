using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public abstract class Dimensionable : MonoBehaviour
	{
		public class DimensionInfo
		{
			public DimensionBehaviourSO dimension;
		}

		public abstract void SvOnDimensionEnter(int dimensionId);

		public abstract void SvOnDimensionExit(int dimensionId);

		public abstract void ClOnDimensionEnter(int dimensionId);

		public abstract void ClOnDimensionExit(int dimensionId);

		public Dimensionable()
		{
		}
	}
}
