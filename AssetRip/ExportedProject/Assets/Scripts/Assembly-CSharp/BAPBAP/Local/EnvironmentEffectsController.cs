using UnityEngine;

namespace BAPBAP.Local
{
	public class EnvironmentEffectsController : MonoBehaviour
	{
		[SerializeField]
		public bool isLevelEditor;

		[SerializeField]
		public ReflectionsController reflections;

		[SerializeField]
		public PlaneEffectsController planeEffects;

		[InspectorButton("EnableAllEffects")]
		[SerializeField]
		public bool enableEffects;

		[InspectorButton("DisableAllEffects")]
		[SerializeField]
		public bool disableEffects;

		public void Start()
		{
		}

		public void EnableAllEffects()
		{
		}

		public void DisableAllEffects()
		{
		}
	}
}
