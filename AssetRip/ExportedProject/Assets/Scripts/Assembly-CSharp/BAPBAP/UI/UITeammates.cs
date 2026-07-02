using System;
using System.Collections.Generic;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UITeammates : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		public Dictionary<int, UITeammateElement> teammateElements;

		[NonSerialized]
		public int[] teammatesByPlayerId;

		[Header("References")]
		public Transform teammateParent;

		public GraphicRaycaster graphicRaycaster;

		[Header("Prefabs")]
		public GameObject teammateElementPrefab;

		public GameObject teammatePingUIIconPrefab;

		public GameObject teammateDownedPingUIIconPrefab;

		public GameObject teammateKilledPingUIIconPrefab;

		public GameObject teammateAlertPingUIIconPrefab;

		[Header("Settings")]
		public Color defaultSquadMemberColor;

		public Color[] teammateColors;

		public SFXData teammateAttackedSfx;

		public float teammateAttackedPlayCooldown;

		public SFXData teammateKilledSfx;

		[NonSerialized]
		public string defaultSquadMemberColorHex;

		[NonSerialized]
		public string[] teammateColorsHex;

		public Dictionary<int, UIPingCharacterElement> teammateDirIconByInstId;

		[NonSerialized]
		public float teammateAttackedPlayTimer;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public UITeammateElement AddTeammate(int playerId)
		{
			return null;
		}

		public void RemoveTeammate(int playerId)
		{
		}

		public int GetTeammateIdByPlayerId(int playerId)
		{
			return 0;
		}

		public bool TryGetTeammateElement(int playerId, out UITeammateElement teammateElement)
		{
			teammateElement = null;
			return false;
		}

		public void RemoveAllTeammates()
		{
		}

		public Color GetTeammateColor(int teammateId)
		{
			return default(Color);
		}

		public string GetTeammateColorHex(int teammateId)
		{
			return null;
		}

		public void OnMuteTeammate(UITeammateElement uiTeammateElement, bool isMuted)
		{
		}

		public void TryPlayTeammateAttackedSfx(Vector2 iconPos, Color teammateColor)
		{
		}

		public void PlayTeammateAttackedSfx()
		{
		}

		public void PlayTeammateKilledSfx()
		{
		}

		public void CreateTeammateDownedPing(Vector2 iconPos, Color teammateColor)
		{
		}

		public void CreateTeammateKilledPing(Vector2 iconPos, Color teammateColor)
		{
		}

		public void CreateTeammateAttackedPing(Vector2 iconPos, Color teammateColor)
		{
		}

		public void CreateTeammateAlertPing(GameObject pingPrefab, Vector2 iconPos, Color teammateColor, float duration)
		{
		}
	}
}
