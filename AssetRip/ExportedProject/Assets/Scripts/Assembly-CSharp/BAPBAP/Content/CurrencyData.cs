using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "CurrencyData", menuName = "BAPBAP/Content/Currency/CurrencyData", order = 1)]
	public class CurrencyData : ScriptableObject
	{
		[SerializeField]
		[Header("Config")]
		public float defaultDisplayScale;

		[Header("3D Visualizer Settings")]
		public ContentVisualizer3D.VisualizerSettings vis3DSettings;

		[SerializeField]
		[Header("Content")]
		public CurrencySO gold;

		[SerializeField]
		public CurrencySO fractals;

		[SerializeField]
		public CurrencySO charTokens;

		[SerializeField]
		public CurrencySO challengeLive;

		public Content GetCurrencyContentByAssetId(int assetId)
		{
			return null;
		}

		public Content GetChallengeContentByAssetId(int assetId)
		{
			return null;
		}
	}
}
