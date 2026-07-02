using UnityEngine;

namespace BAPBAP.Local
{
	public class ModelSwapManager : MonoBehaviour
	{
		[SerializeField]
		public ModelSwaps[] modelSwaps;

		public int GetModelSwapSize()
		{
			return 0;
		}

		public ModelSwaps GetModel(int id)
		{
			return null;
		}

		public int GetRandomIdByChance(int excludeIndex = -1)
		{
			return 0;
		}
	}
}
