using UnityEngine;

namespace BAPBAP.Local
{
	public class PistolModelHolder : MonoBehaviour
	{
		public FollowRotation followOrientation;

		public Animator gunAnimator;

		public ParticleSystem gunShootVfx;

		public PlayTrailEmitter gunShootTrail;

		public ParticleSystem gunReloadVfx;

		public GameObject shootDeactivateObj;
	}
}
