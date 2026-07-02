using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFFAScoreboardEntry : MonoBehaviour
{
	[SerializeField]
	public TMP_Text nameText;

	[SerializeField]
	public TMP_Text scoreText;

	[SerializeField]
	public Image scoreIcon;

	[SerializeField]
	public TMP_Text livesText;

	[SerializeField]
	public Image livesIcon;

	public void SetInfo(string playerName, int score, int lives)
	{
	}

	public void Clear()
	{
	}
}
