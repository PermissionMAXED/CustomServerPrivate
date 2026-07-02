using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace BAPBAP.Minigames
{
	public class BapManController : MinigameController
	{
		[Serializable]
		public class Ghost
		{
			public enum State
			{
				Scatter = 0,
				Chase = 1,
				Frightened = 2,
				Eaten = 3
			}

			public class GhostState
			{
				[NonSerialized]
				public Ghost ghost;

				public virtual void OnEnter()
				{
				}

				public virtual void OnTick()
				{
				}

				public virtual void OnExit()
				{
				}

				public virtual void OnEnterPortal(Collider2D col)
				{
				}
			}

			public class StateScatter : GhostState
			{
				public StateScatter(Ghost _ghost)
				{
				}

				public override void OnEnter()
				{
				}

				public override void OnTick()
				{
				}
			}

			public class StateChase : GhostState
			{
				public StateChase(Ghost _ghost)
				{
				}

				public override void OnEnter()
				{
				}

				public override void OnTick()
				{
				}
			}

			public class StateFrightened : GhostState
			{
				public StateFrightened(Ghost _ghost)
				{
				}

				public override void OnEnter()
				{
				}

				public override void OnTick()
				{
				}

				public override void OnExit()
				{
				}
			}

			public class StateEaten : GhostState
			{
				[NonSerialized]
				public bool reachedPortal;

				public StateEaten(Ghost _ghost)
				{
				}

				public override void OnEnter()
				{
				}

				public override void OnTick()
				{
				}

				public override void OnExit()
				{
				}

				public override void OnEnterPortal(Collider2D col)
				{
				}
			}

			[SerializeField]
			public GameObject gameObject;

			[SerializeField]
			public Transform transform;

			[SerializeField]
			public OnTriggerEnter2DEvent triggerEnterEvent;

			[SerializeField]
			public Collider2D collider;

			[SerializeField]
			public Image normalSprite;

			[SerializeField]
			public Image frightenedSprite;

			[SerializeField]
			public Image eatenSprite;

			[SerializeField]
			public Vector2Int scatterTarget;

			[SerializeField]
			public Vector2Int homeTarget;

			[SerializeField]
			public int homePortalId;

			[SerializeField]
			public RangeFloat scatterDuration;

			[SerializeField]
			public RangeFloat chaseDuration;

			[NonSerialized]
			public BapManController controller;

			[NonSerialized]
			public Vector2Int targetTile;

			[NonSerialized]
			public Vector2Int dir;

			[NonSerialized]
			public bool spawned;

			[NonSerialized]
			public bool enteredTile;

			[NonSerialized]
			public Vector2Int currentTile;

			[NonSerialized]
			public List<Vector2Int> availableDirections;

			[NonSerialized]
			public int portalInId;

			[NonSerialized]
			public int portalOutId;

			[NonSerialized]
			public StateScatter stateScatter;

			[NonSerialized]
			public GhostState stateChase;

			[NonSerialized]
			public StateFrightened stateFrightened;

			[NonSerialized]
			public StateEaten stateEaten;

			[NonSerialized]
			public GhostState[] states;

			[NonSerialized]
			public float stateTimer;

			[NonSerialized]
			public float portalMoveTime;

			[NonSerialized]
			public int currentState;

			public Vector2 pos
			{
				get
				{
					return default(Vector2);
				}
				set
				{
				}
			}

			public virtual void Initialize(BapManController _controller)
			{
			}

			public void Start()
			{
			}

			public void Spawn()
			{
			}

			public void SetState(State newState)
			{
			}

			public void Move()
			{
			}

			public void Tick()
			{
			}

			public void MovePortal()
			{
			}

			public void SetNormalSprite()
			{
			}

			public void SetFrightenedSprite()
			{
			}

			public void SetEatenSprite()
			{
			}

			public void OnPortalCollision(Collider2D col)
			{
			}
		}

		[Serializable]
		public class Blinky : Ghost
		{
			public class BlinkyChaseState : StateChase
			{
				public BlinkyChaseState(Ghost _ghost)
				{
				}

				public override void OnEnter()
				{
				}

				public override void OnTick()
				{
				}
			}

			public override void Initialize(BapManController _controller)
			{
			}
		}

		[Serializable]
		public class Pinky : Ghost
		{
			public class PinkyChaseState : StateChase
			{
				[NonSerialized]
				public int targetForwardOffset;

				public PinkyChaseState(Ghost _ghost)
				{
				}

				public override void OnTick()
				{
				}
			}

			public override void Initialize(BapManController _controller)
			{
			}
		}

		[Serializable]
		public class Inky : Ghost
		{
			public class InkyChaseState : StateChase
			{
				[NonSerialized]
				public IntRange targetForwardOffsetRange;

				public InkyChaseState(Ghost _ghost)
				{
				}

				public override void OnTick()
				{
				}
			}

			public override void Initialize(BapManController _controller)
			{
			}
		}

		[Serializable]
		public class Clyde : Ghost
		{
			public class ClydeChaseState : StateChase
			{
				[NonSerialized]
				public float distSwitchSqr;

				public ClydeChaseState(Ghost _ghost)
				{
				}

				public override void OnTick()
				{
				}
			}

			public override void Initialize(BapManController _controller)
			{
			}
		}

		[NonSerialized]
		public AudioManager audioManager;

		[Header("References")]
		[SerializeField]
		public Transform levelParent;

		[SerializeField]
		public Transform scalePivot;

		[SerializeField]
		public Image fillImage;

		[SerializeField]
		public Tilemap levelTilemap;

		[SerializeField]
		public GameObject tileImageTemplate;

		[SerializeField]
		public Transform tilemapUIRenderHolder;

		[SerializeField]
		public Transform pelletsHolder;

		[SerializeField]
		public Blinky ghostBlinky;

		[SerializeField]
		public Pinky ghostPinky;

		[SerializeField]
		public Inky ghostInky;

		[SerializeField]
		public Clyde ghostClyde;

		[SerializeField]
		public Collider2D portalL;

		[SerializeField]
		public Collider2D portalR;

		[SerializeField]
		public Transform player;

		[SerializeField]
		public OnTriggerEnter2DEvent playerTrigger;

		[SerializeField]
		public Image playerImage;

		[SerializeField]
		public Rigidbody2D playerRb;

		[SerializeField]
		public Sprite[] playerSprites;

		[SerializeField]
		public AudioSource ghostLoopSfx;

		[SerializeField]
		public TMP_Text levelText;

		[SerializeField]
		public TMP_Text livesText;

		[SerializeField]
		public TMP_Text scoreText;

		[SerializeField]
		public TMP_Text highscoreText;

		[SerializeField]
		public TMP_Text scorePopupText;

		[SerializeField]
		public GameObject gameOver;

		[SerializeField]
		public GameObject levelWin;

		[SerializeField]
		public GameObject newHighscore;

		[SerializeField]
		public GameObject readyText;

		[SerializeField]
		public Vector2Int playerStartPos;

		[SerializeField]
		public float ghostFrightenedEndFlickerDuration;

		[SerializeField]
		public Color ghostFrightenedAnimColor;

		[SerializeField]
		public Color ghostFrightenedAnimColorFlicker;

		[SerializeField]
		public float ghostFrightenedSpriteAnimFps;

		[SerializeField]
		public float ghostPortalMoveDuration;

		[SerializeField]
		public float ghostSpawnRate;

		[SerializeField]
		public float ghostFrightenedDuration;

		[SerializeField]
		public float ghostEatenCdDuration;

		[SerializeField]
		public AnimationCurve playerDieScaleCurve;

		[Header("External References")]
		[SerializeField]
		public TileBase pelletTile;

		[SerializeField]
		public TileBase powerPelletTile;

		[SerializeField]
		public GameObject pelletPrefab;

		[SerializeField]
		public GameObject powerPelletPrefab;

		[Header("Player Parameters")]
		[SerializeField]
		public float moveSpeed;

		[SerializeField]
		public float ghostMoveSpeed;

		[SerializeField]
		public float ghostMoveSpeedFrightened;

		[SerializeField]
		public float turnDistSensibility;

		[SerializeField]
		public int scorePerPelletEaten;

		[SerializeField]
		public int scorePerGhostEaten;

		[SerializeField]
		public int lives;

		[SerializeField]
		public float speedIncreasePerLvl;

		[SerializeField]
		public float scatterReductionPerLvl;

		[Header("Game Parameters")]
		[SerializeField]
		public float gameStartAnimDuration;

		[SerializeField]
		public float levelWinAnimDuration;

		[SerializeField]
		public float levelLoseAnimDuration;

		[SerializeField]
		public float gameOverAnimDuration;

		[SerializeField]
		public float ghostEatAnimDuration;

		[SerializeField]
		public float screenWidth;

		[Header("Misc")]
		[SerializeField]
		public float spriteAnimFramesPerSecond;

		[SerializeField]
		public Color scoreColor;

		[SerializeField]
		public Color scoreMilestoneColor;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData[] pelletSfx;

		[SerializeField]
		public AudioClipData gameStartSfx;

		[SerializeField]
		public AudioClipData hitSfx;

		[SerializeField]
		public AudioClipData gameOverSfx;

		[SerializeField]
		public AudioClipData levelWinSfx;

		[SerializeField]
		public AudioClipData ghostEatSfx;

		[SerializeField]
		public AudioClipData powerPelletSfx;

		[SerializeField]
		public AudioClip ghostLoop;

		[SerializeField]
		public AudioClip ghostFrightenedLoop;

		[NonSerialized]
		public Vector2Int levelSize;

		[NonSerialized]
		public bool[,] levelCollisionTilemap;

		[NonSerialized]
		public GameObject[] pellets;

		[NonSerialized]
		public int totalPelletCount;

		[NonSerialized]
		public int currentEatComboMult;

		[NonSerialized]
		public int currentLives;

		[NonSerialized]
		public int pelletSfxIndex;

		[NonSerialized]
		public Ghost[] ghosts;

		[NonSerialized]
		public bool waitingToStart;

		[NonSerialized]
		public Vector2Int dirInput;

		[NonSerialized]
		public Vector2Int playerDir;

		[NonSerialized]
		public Vector2Int playerTile;

		[NonSerialized]
		public bool remainingSpawnGhosts;

		[NonSerialized]
		public float ghostSpawnTimer;

		[NonSerialized]
		public int currentLevel;

		[NonSerialized]
		public int obtainedPellets;

		[NonSerialized]
		public int score;

		[NonSerialized]
		public int highscore;

		[NonSerialized]
		public float gameStartAnimTime;

		[NonSerialized]
		public float levelLoseAnimTime;

		[NonSerialized]
		public float levelWinAnimTime;

		[NonSerialized]
		public float gameOverAnimTime;

		[NonSerialized]
		public float ghostEatAnimTime;

		[NonSerialized]
		public float halfScreenWidth;

		[NonSerialized]
		public Vector2Int halfLevelSize;

		[NonSerialized]
		public float tileSize;

		public const string HighscoreKey = "BapManHighscore";

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

		public void PlayerTick()
		{
		}

		public void GhostsTick()
		{
		}

		public bool IsColliding(Vector2Int gridPos)
		{
			return false;
		}

		public void GetAvailableDirections(List<Vector2Int> directions, Vector2Int pos, Vector2Int currDir)
		{
		}

		public static int GetShortestPosDir(Vector2Int targetPos, List<Vector2Int> dirList, Vector2Int pos)
		{
			return 0;
		}

		public void OnPlayerCollision(Collider2D col)
		{
		}

		public void OnGhostCollision(GameObject ghostGameObject)
		{
		}

		public void OnPelletCollision(GameObject pellet)
		{
		}

		public void OnPowerPelletCollision(GameObject powerPellet)
		{
		}

		public void OnPlayerPortalEnter(Collider2D portal)
		{
		}

		public void OnPelletObtained()
		{
		}

		public void ActivatePowerPellet()
		{
		}

		public void OnGhostEaten(Ghost ghost)
		{
		}

		public void UpdateScoreText(int score)
		{
		}

		public void UpdateHighScoreText(int highscore)
		{
		}

		public void UpdateScorePopupText(int score)
		{
		}

		public void UpdateLevelText(int level)
		{
		}

		public void UpdateLives(int lives)
		{
		}

		public void OnLevelWin()
		{
		}

		public void OnLevelLose()
		{
		}

		public void StartLevel()
		{
		}

		public void RestartLevel()
		{
		}

		public override void OnGameStart()
		{
		}

		public override void OnGameEnd()
		{
		}

		public void OnDrawGizmosSelected()
		{
		}
	}
}
