using System;
using System.Collections.Generic;
using BAPBAP.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class View_PreMatch_SpawnSelect : View
	{
		[Serializable]
		public class Configuration
		{
			public float PlayerPinLerpTime;

			public float EnemyPinLerpTime;

			public float FinalizePinsLerpTime;
		}

		[SerializeField]
		public UIAlphaFade _uiAlphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundAlphaFade;

		[SerializeField]
		public Image _mapImage;

		[SerializeField]
		public RawImage _mapDimensionMaskImage;

		[SerializeField]
		public RectTransform _displayedMapRect;

		[SerializeField]
		public RectTransform _worldElementsHolder;

		[SerializeField]
		public RectTransform _spawnButtonContainer;

		[SerializeField]
		public RectTransform _dimensionParent;

		[SerializeField]
		public TMP_Text _mapNameText;

		[SerializeField]
		public TMP_Text _subtitleText;

		[SerializeField]
		public Animator _animator;

		[SerializeField]
		public AnimationClip _spawnLockAnim;

		[SerializeField]
		[Space(10f)]
		public UISpawnSelectPin _playerPinPrefab;

		[SerializeField]
		public UISpawnSelectPin _enemyPinPrefab;

		[SerializeField]
		public GameObject _spawnPointPrefab;

		[SerializeField]
		[Space(10f)]
		public float _alphaHitThreshold;

		[NonSerialized]
		public UILobbyMatchCharacterSelectPage.Configuration _configuration;

		[NonSerialized]
		public Action<PlayerManager, Vector2> _onSpawnSelectAction;

		[NonSerialized]
		public float _mapSizeFactor;

		[NonSerialized]
		public int _currentMapSize;

		[NonSerialized]
		public float _suggestionCooldown;

		public const float PING_COOLDOWN_TIME = 0.33f;

		[NonSerialized]
		public readonly Dictionary<UISpawnSelectPin, PlayerManager> _playerPins;

		[NonSerialized]
		public readonly Dictionary<UISpawnSelectPin, PlayerManager> _enemyPins;

		[NonSerialized]
		public readonly List<RectTransform> _spawnPointTransforms;

		[NonSerialized]
		public Dictionary<int, UIMinimapDimension> _spawnedDimensions;

		public void Initialize(UILobbyMatchCharacterSelectPage.Configuration config)
		{
		}

		public void InitMap()
		{
		}

		public void Open(bool instant = false)
		{
		}

		public void Close(bool instant = false)
		{
		}

		public void CreateAllPlayerPins()
		{
		}

		public void CreatePlayerPin(PlayerManager player, Color identityColor, UILobbyMatchCharacterSelectPage.Configuration matchCharConfig)
		{
		}

		public void UpdatePlayerPinsCharacters()
		{
		}

		public void SetPlayerPinLocation(PlayerManager player, Vector2 worldPosition, bool isLocked)
		{
		}

		public void SetEnemyPinLocation(PlayerManager player, Vector2 worldPosition)
		{
		}

		public void AddDimension(int dimensionId, Vector2 spawnPos, int radius)
		{
		}

		public void ClearAllDimensions()
		{
		}

		public void RevealDimensions()
		{
		}

		public UIMinimapDimension CreateUIDimension(int dimensionId)
		{
			return null;
		}

		public void UpdateDimensionVisual(int dimensionId, Vector2 worldPos, float size)
		{
		}

		public Vector2 GetMapPosFromScreenPos(Vector2 screenPos)
		{
			return default(Vector2);
		}

		public Vector2 GetScreenPosFromMapPos(Vector2 mapPos)
		{
			return default(Vector2);
		}

		public void UpdateElementSize(Transform targetTransform)
		{
		}

		public void DestroyAllPlayerPins()
		{
		}

		public void DestroyAllEnemyPins()
		{
		}

		public void OnSpawnLocationSelected()
		{
		}

		public void Update()
		{
		}
	}
}
