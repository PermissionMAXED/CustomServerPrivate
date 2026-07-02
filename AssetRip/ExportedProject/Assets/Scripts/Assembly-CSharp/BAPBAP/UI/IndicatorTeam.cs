using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class IndicatorTeam : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public SpriteRenderer[] spriteRenderers;

		[NonSerialized]
		public int teamId;

		[NonSerialized]
		public bool showOnlyAllies;

		[NonSerialized]
		public bool isAlly;

		public void Start()
		{
		}

		public void Refresh()
		{
		}

		public void LateUpdate()
		{
		}

		public void DoUpdate()
		{
		}

		public void UpdateTeam(bool isAlly)
		{
		}
	}
}
