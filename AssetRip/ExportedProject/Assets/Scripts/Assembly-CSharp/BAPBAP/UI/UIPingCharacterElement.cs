using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIPingCharacterElement : UIPingElement
	{
		[Header("UI References")]
		[SerializeField]
		public Image dirAccentColorImage;

		[SerializeField]
		public Image accentColorImage;

		[Header("References")]
		[SerializeField]
		public Material downMaterial;

		[SerializeField]
		[Header("Distance Text")]
		public TMP_Text distText;

		[Min(0.1f)]
		[SerializeField]
		public float updateRate;

		[SerializeField]
		public UIManager.InfoStatus[] distStatus;

		[NonSerialized]
		public Vector2 distWorldPos;

		[NonSerialized]
		public float prevDist;

		[NonSerialized]
		public float updateRateTime;

		public void Update()
		{
		}

		public void SetUpCharacterPing(Color accentColor, Sprite icon)
		{
		}

		public void SetDowned(bool isDowned)
		{
		}

		public void UpdateDistanceWorldPos(Vector2 worldPos)
		{
		}
	}
}
