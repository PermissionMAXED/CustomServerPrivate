using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class RngManager : MonoBehaviour
	{
		[Tooltip("How many ticks until we wrap around and re-use these pre-generated rngs? (use a prime number ideally)")]
		[SerializeField]
		public int rngSampleSize;

		[Tooltip("How many different rngs do we support in a single tick?")]
		[SerializeField]
		public int rngsPerTick;

		[SerializeField]
		[Tooltip("Seed used for RNG")]
		public int seed;

		[NonSerialized]
		public float[,] rngFloats;

		public void Awake()
		{
		}

		public float GetRandom(int tickNum, int nonce)
		{
			return 0f;
		}
	}
}
