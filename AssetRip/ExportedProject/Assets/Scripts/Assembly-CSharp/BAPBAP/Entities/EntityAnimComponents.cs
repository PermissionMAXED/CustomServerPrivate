using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityAnimComponents : MonoBehaviour
	{
		[SerializeField]
		public MonoBehaviour[] animatedComponents;

		[SerializeField]
		public Animator[] animators;

		public void EnableAnimationComponents()
		{
		}

		public void DisableAnimationComponents()
		{
		}
	}
}
