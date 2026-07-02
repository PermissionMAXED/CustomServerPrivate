using System;
using UnityEngine;

namespace Gamekit3D
{
	public class RandomStateSMB : StateMachineBehaviour
	{
		public int numberOfStates;

		public float minNormTime;

		public float maxNormTime;

		[NonSerialized]
		public float m_RandomNormTime;

		[NonSerialized]
		public readonly int m_HashRandomIdle;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}
	}
}
