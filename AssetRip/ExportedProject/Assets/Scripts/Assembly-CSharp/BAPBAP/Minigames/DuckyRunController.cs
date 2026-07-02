using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Minigames
{
	public class DuckyRunController : MinigameController
	{
		[NonSerialized]
		public AudioManager audioManager;

		[SerializeField]
		[Header("References")]
		public GameObject[] obstacleTemplates;

		[SerializeField]
		public Transform player;

		[SerializeField]
		public OnTriggerEnterEvent playerTrigger;

		[SerializeField]
		public Image playerImage;

		[SerializeField]
		public Sprite[] duckySprites;

		[SerializeField]
		public AudioSource duckyAudioSource;

		[SerializeField]
		public TMP_Text scoreText;

		[SerializeField]
		public TMP_Text highscoreText;

		[SerializeField]
		public GameObject gameOver;

		[SerializeField]
		public GameObject newHighscore;

		[SerializeField]
		public Image fillImg;

		[SerializeField]
		public RectTransform floorImg;

		[SerializeField]
		public RectTransform backgroundImg;

		[SerializeField]
		[Header("General")]
		public float floorHeight;

		[SerializeField]
		public float screenWidth;

		[SerializeField]
		[Header("Sequence Settings")]
		public float startAnimDuration;

		[SerializeField]
		public float gameOverAnimDuration;

		[Header("Duck Parameters")]
		[SerializeField]
		public float duckyGravity;

		[SerializeField]
		public float duckyHoldJumpGravity;

		[SerializeField]
		public float duckyJumpForce;

		[Header("Game Parameters")]
		[SerializeField]
		public float baseScrollSpeed;

		[Tooltip("Multiplier on spawn rate increase by speed. 1 = spawn rate scales proportionally with speed, 0 = no spawn rate scale with speed")]
		[SerializeField]
		public float spawnSpeedMult;

		[SerializeField]
		public float maxSpeed;

		[SerializeField]
		public RangeFloat obstacleSpawnRateRange;

		[Header("Score Parameters")]
		[SerializeField]
		public float scorePerSecond;

		[SerializeField]
		public int scorePerMilestone;

		[SerializeField]
		public float speedIncreasePerMilsestone;

		[SerializeField]
		public float speedIncreasePerSecond;

		[Header("Misc Settings")]
		[SerializeField]
		public float bgScrollSpeedFactor;

		[SerializeField]
		public float spriteAnimFramesPerSecond;

		[SerializeField]
		public float milestoneAnimDuration;

		[SerializeField]
		public float milestoneAnimFlickerRate;

		[SerializeField]
		public Color scoreColor;

		[SerializeField]
		public Color scoreMilestoneColor;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData duckyJumpSfx;

		[SerializeField]
		public AudioClipData gameOverSfx;

		[SerializeField]
		public AudioClipData scoreMilestoneSfx;

		[NonSerialized]
		public bool waitingToStart;

		[NonSerialized]
		public bool jumpHold;

		[NonSerialized]
		public float obstacleSpawnTimer;

		[NonSerialized]
		public List<Transform> spawnedObstacles;

		[NonSerialized]
		public List<Transform> obstaclePool;

		[NonSerialized]
		public float currentSpeed;

		[NonSerialized]
		public float spawnSpeedFactor;

		[NonSerialized]
		public float duckyVel;

		[NonSerialized]
		public bool duckyIsGrounded;

		[NonSerialized]
		public float score;

		[NonSerialized]
		public int intTimeScore;

		[NonSerialized]
		public int highscore;

		[NonSerialized]
		public float startAnimTime;

		[NonSerialized]
		public float gameOverAnimTime;

		[NonSerialized]
		public float milestoneAnimTime;

		[NonSerialized]
		public float halfScreenWidth;

		[NonSerialized]
		public float bgLoopSize;

		[NonSerialized]
		public float floorLoopSize;

		public const string HighscoreKey = "DuckyRunHighscore";

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Update()
		{
		}

		public void FixedUpdate()
		{
		}

		public void GameLoopTick()
		{
		}

		public void ScoreTick()
		{
		}

		public void DuckyTick()
		{
		}

		public void ObstaclesTick()
		{
		}

		public void EnvTick()
		{
		}

		public void SpawnObstacle()
		{
		}

		public void MilestoneReached()
		{
		}

		public void SetCurrentSpeed(float newSpeed)
		{
		}

		public void OnDuckyJump()
		{
		}

		public void OnDuckyCollision(Collider col)
		{
		}

		public void UpdateHighScoreText(int highscore)
		{
		}

		public void UpdateScoreText(int score)
		{
		}

		public override void OnGameStart()
		{
		}

		public override void OnGameEnd()
		{
		}
	}
}
