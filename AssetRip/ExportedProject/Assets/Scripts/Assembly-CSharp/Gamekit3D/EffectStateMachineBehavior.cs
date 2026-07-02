using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
	public class EffectStateMachineBehavior : SceneLinkedSMB<EffectEvents>
	{
		public enum EventType
		{
			ENTER = 0,
			EXIT = 1
		}

		[Serializable]
		public class EventInstance
		{
			public string eventName;

			public bool invert;

			public EventType eventType;
		}

		public EventInstance[] events;

		[NonSerialized]
		public List<EventInstance> m_EnterEvents;

		[NonSerialized]
		public List<EventInstance> m_ExitEvents;

		public void OnEnable()
		{
		}

		public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}
	}
}
