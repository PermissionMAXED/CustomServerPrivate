using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPlayRandomReference : MonoBehaviour
	{
		[SerializeField]
		public AudioPlayRandom playRandom1;

		[SerializeField]
		public AudioPlayRandom playRandom2;

		[SerializeField]
		public bool useRef;

		[NonSerialized]
		public bool playSecondary;

		public void PlayReference1()
		{
		}

		public void PlayReference2()
		{
		}

		public void CheckPlayReference2()
		{
		}
	}
}
