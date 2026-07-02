using UnityEngine;

namespace BAPBAP.Local
{
	public class FollowRotation : MonoBehaviour
	{
		[SerializeField]
		public Transform _target;

		[SerializeField]
		public float lerpSpeed;

		public Transform Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void LateUpdate()
		{
		}
	}
}
