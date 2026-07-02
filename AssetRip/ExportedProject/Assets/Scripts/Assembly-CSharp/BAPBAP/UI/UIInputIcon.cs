using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIInputIcon : MonoBehaviour
	{
		[SerializeField]
		public GameObject keyObj;

		[SerializeField]
		public TMP_Text keyText;

		[SerializeField]
		public GameObject buttonObj;

		[SerializeField]
		public Image buttonIcon;

		public void SetInput(InputBinding inputBinding, bool isGamepad)
		{
		}

		public void SetKey(string str)
		{
		}

		public void SetButton(Sprite icon)
		{
		}
	}
}
