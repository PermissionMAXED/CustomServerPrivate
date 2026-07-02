using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIEffectIconStack : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		public Color maxStackColor;

		[SerializeField]
		public Color normalStackColor;

		[SerializeField]
		[Header("References")]
		public Image[] iconImages;

		public void Awake()
		{
		}

		public void SetEffectStack(int stackNumber, bool isMaxStack = false)
		{
		}

		public void DisableEffectStack()
		{
		}
	}
}
