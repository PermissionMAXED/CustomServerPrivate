using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Debugging
{
	public class DebugGraph : MonoBehaviour
	{
		public struct Dataset
		{
			public float[] rawData;

			public float[] shaderData;
		}

		[Header("Graph Components")]
		[SerializeField]
		public Image imageGraph;

		[SerializeField]
		public RectTransform graphRectTransform;

		[SerializeField]
		public Shader shader;

		[SerializeField]
		public GameObject highlightPopup;

		[SerializeField]
		public RectTransform highlightPopupRect;

		[SerializeField]
		public Text maxText;

		[SerializeField]
		public Text minText;

		[SerializeField]
		public Text[] highlightTexts;

		[Header("Graph Visuals")]
		[SerializeField]
		public Color[] datasetColors;

		[SerializeField]
		public float highlightPopupOffsetY;

		[Tooltip("Number of datasets (max 2 supported by shader)")]
		[Header("Graph Settings")]
		[SerializeField]
		public int numDatasets;

		[SerializeField]
		[Tooltip("The size of the dataset shown in the graph (max 128)")]
		public int datasetSize;

		[Tooltip("Decimal precision of all numbers shown on the graph")]
		[SerializeField]
		public int decimalPrecision;

		[Tooltip("Set the graph's upper bound to a constant")]
		[SerializeField]
		public bool hasMaxBound;

		[SerializeField]
		public float maxBound;

		[Tooltip("Set the graph's lower bound to a constant")]
		[SerializeField]
		public bool hasMinBound;

		[SerializeField]
		public float minBound;

		[SerializeField]
		[Tooltip("Set the graph's upper and lower bounds to a constant while following the dataset's average")]
		public bool hasAvgBound;

		[SerializeField]
		public float avgHalfBounds;

		[NonSerialized]
		public Dataset[] datasets;

		[NonSerialized]
		public Vector2 windowDims;

		[NonSerialized]
		public float graphXMin;

		[NonSerialized]
		public float graphXMax;

		[NonSerialized]
		public float graphYMin;

		[NonSerialized]
		public float graphYMax;

		[NonSerialized]
		public float graphHeight;

		[NonSerialized]
		public float graphWidth;

		[NonSerialized]
		public string[] shaderGraphValues;

		[NonSerialized]
		public float maxData;

		[NonSerialized]
		public float minData;

		[NonSerialized]
		public float avgData;

		[NonSerialized]
		public bool paused;

		[NonSerialized]
		public string decimalPrecisionString;

		[NonSerialized]
		public string highlightValueString;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void AddData(params float[] data)
		{
		}

		public void UpdateGraph()
		{
		}

		public void UpdateGraphBoundTexts()
		{
		}

		public void UpdateGraphHighlight()
		{
		}

		public void RecomputeRectWorldBounds()
		{
		}
	}
}
