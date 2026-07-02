using UnityEngine;

namespace BAPBAP.Entities
{
	[ExecuteAlways]
	public class AudioSourceScale : MonoBehaviour
	{
		[SerializeField]
		public AudioSource audioSource;

		[SerializeField]
		public float minMaxFadeOut;

		public void Update()
		{
		}
	}
}
