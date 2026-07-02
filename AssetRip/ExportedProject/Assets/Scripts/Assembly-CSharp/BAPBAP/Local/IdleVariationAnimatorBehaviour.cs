using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class IdleVariationAnimatorBehaviour : StateMachineBehaviour
	{
		[Header("Settings")]
		[Tooltip("Name of the state for the idle variation")]
		[SerializeField]
		public string idleVarTriggerName;

		[SerializeField]
		[Tooltip("The min amount of time to wait to trigger the next idle variation")]
		public float randomMinDuration;

		[Tooltip("The max amount of time to wait to trigger the next idle variation")]
		[SerializeField]
		public float randomMaxDuration;

		[NonSerialized]
		public float currentIdleDuration;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public float GetRandomDuration()
		{
			return 0f;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}
	}
}
