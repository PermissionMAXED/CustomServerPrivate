using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXParticleForceStart : MonoBehaviour
	{
		[SerializeField]
		public ParticleSystem ps;

		[SerializeField]
		public bool includeChildren;

		[NonSerialized]
		public float simTime;

		public void Awake()
		{
		}
	}
}
