using BAPBAP.Local;
using RuntimeGizmos;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelEditor
{
	[ExecuteAlways]
	public class LevelEditorMonoController : MonoBehaviour
	{
		[Header("References")]
		public Configuration config;

		[Header("Components")]
		public CameraManager cameraManager;

		public TransformGizmo transformGizmo;

		public PlaceAnimController placeAnimController;

		public PlayerInput playerInput;

		public Transform visualizerRotation;

		public GameObject envElements;

		[Header("FX")]
		public AudioSource sfxAudioSource;

		public ParticleSystem placeParticleSystem;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void Initialize(Configuration config)
		{
		}

		public void PlaySelectSfx(float volumeMultiplier = 1f)
		{
		}

		public void PlayPlaceSfx(float volumeMultiplier = 1f)
		{
		}

		public void PlayEraseSfx(float volumeMultiplier = 1f)
		{
		}
	}
}
