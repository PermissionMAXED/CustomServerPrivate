using UnityEngine;

namespace BAPBAP.Local
{
	public class FollowTransform : MonoBehaviour
	{
		[SerializeField]
		public Transform _target;

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
