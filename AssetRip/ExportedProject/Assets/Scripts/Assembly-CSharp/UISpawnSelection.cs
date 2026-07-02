using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using BAPBAP.UI;
using UnityEngine;
using UnityEngine.UI;

public class UISpawnSelection : MonoBehaviour
{
	[Serializable]
	public class Configuration
	{
		public float PlayerPinLerpTime;

		public float EnemyPinLerpTime;

		public float FinalizePinsLerpTime;
	}

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
	[Space(10f)]
	public UISpawnSelectPin _playerPinPrefab;

	[SerializeField]
	public UISpawnSelectPin _enemyPinPrefab;

	[SerializeField]
	public GameObject _spawnPointPrefab;

	[Space(10f)]
	[SerializeField]
	public float _alphaHitThreshold;

	[NonSerialized]
	public Configuration _configuration;

	[NonSerialized]
	public Action<Vector2> _onSpawnSelectAction;

	[NonSerialized]
	public float _mapSizeFactor;

	[NonSerialized]
	public int _currentMapSize;

	[NonSerialized]
	public float _suggestionCooldown;

	public const float PING_COOLDOWN_TIME = 0.33f;

	[NonSerialized]
	public readonly Dictionary<UISpawnSelectPin, PlayerModel> _playerPins;

	[NonSerialized]
	public readonly Dictionary<string, UISpawnSelectPin> _enemyPins;

	[NonSerialized]
	public readonly List<RectTransform> _spawnPointTransforms;

	[NonSerialized]
	public Dictionary<int, UIMinimapDimension> _spawnedDimensions;

	public void InitializeMap(Configuration config, Sprite mapScreenshot, LevelMMCache levelMMCache, Action<Vector2> onSpawnSelectedAction)
	{
	}

	public void CreatePlayerPin(PlayerModel player, Color identityColor, UILobbyMatchCharacterSelectPage.Configuration matchCharConfig)
	{
	}

	public void UpdatePlayerPinsCharacters()
	{
	}

	public void SetPlayerPin(PlayerModel player, Vector2 worldPosition)
	{
	}

	public void SetEnemyPin(string accountID, Vector2 worldPosition)
	{
	}

	public void MoveAllPinsToSpawnPoints(string[] accountIds, int[] spawnPositions)
	{
	}

	public void UpdateElementSize(Transform targetTransform)
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
