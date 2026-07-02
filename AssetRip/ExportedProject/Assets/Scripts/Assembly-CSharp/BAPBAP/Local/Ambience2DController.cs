using System;
using BAPBAP.Maps;
using UnityEngine;

namespace BAPBAP.Local
{
	public class Ambience2DController : MonoBehaviour
	{
		public class AmbiencePlayer
		{
			public bool active;

			public int ambienceId;

			public float influence;

			public float lerpedInfluence;

			public float volumeMultiplier;

			public AudioSource audioSource;
		}

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public LevelRuntimeManager levelRuntimeManager;

		[Header("References")]
		[SerializeField]
		public AmbienceData ambienceData;

		[SerializeField]
		public Transform targetPoint;

		[Header("Settings")]
		[SerializeField]
		public Vector2Int sampleAreaUnitSize;

		[Min(1f)]
		[SerializeField]
		public int sampleAreaSpacing;

		[SerializeField]
		public float influenceLerpSpeed;

		[SerializeField]
		public float updateRate;

		[SerializeField]
		public int maxAmbientPlayers;

		[SerializeField]
		[Header("Debug")]
		public bool showDebugGizmos;

		[NonSerialized]
		public Vector2Int sampleAreaUnitSizeHalf;

		[NonSerialized]
		public Vector2 spacingAreaOffset;

		[NonSerialized]
		public float updateTime;

		[NonSerialized]
		public int areaSampleNum;

		[NonSerialized]
		public int[] ambienceAverages;

		[NonSerialized]
		public AmbiencePlayer[] activeAmbiences;

		[NonSerialized]
		public Vector2Int[,] debuggingSamplePoints;

		public void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Enable(LevelRuntimeManager levelRuntimeManager)
		{
		}

		public void Disable()
		{
		}

		public void Update()
		{
		}

		public void UpdateAmbience()
		{
		}

		public void GetAverageAmbiences()
		{
		}

		public void SetCurrentAmbience()
		{
		}

		public void StartAmbience(AmbiencePlayer ambiencePlayer, int ambienceId, float influence)
		{
		}

		public void StopAmbience(AmbiencePlayer ambiencePlayer)
		{
		}
	}
}
