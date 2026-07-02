using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UICustomLobbyPlayer : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public RawImage _avatarImage;

		[SerializeField]
		public AspectRatioFitter _avatarAspectRatio;

		[SerializeField]
		public TextMeshProUGUI _playerNameText;

		[SerializeField]
		public TextMeshProUGUI _readyText;

		[SerializeField]
		public OnPointerListener _hoverButtonPointer;

		public void Build(string accountId)
		{
		}

		public void SetPlayerAvatar(int avatarId)
		{
		}

		public void SetPlayerNameText(string playerString)
		{
		}

		public void SetReadyText(string readyString)
		{
		}
	}
}
