using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class BehaviourTimedEnable : MonoBehaviour
	{
		[SerializeField]
		public Behaviour[] behaviours;

		[SerializeField]
		public bool doSetEnabled;

		[SerializeField]
		public float ttl;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool isEnabled;

		public void OnEnable()
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
