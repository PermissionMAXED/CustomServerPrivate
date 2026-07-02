using UnityEngine;

namespace BAPBAP.Local
{
	public class FollowPosition : MonoBehaviour
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
