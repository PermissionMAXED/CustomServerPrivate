using UnityEngine;

namespace Gamekit3D
{
	public abstract class SealedSMB : StateMachineBehaviour
	{
		public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public SealedSMB()
		{
		}
	}
}
