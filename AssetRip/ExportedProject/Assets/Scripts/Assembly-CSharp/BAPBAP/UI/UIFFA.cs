using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIFFA : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CLiveCounterCoroutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLiveCounterCoroutine_003Ed__22(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Header("References")]
		public GameObject ffaUIHolder;

		[SerializeField]
		public TMP_Text currentLivesText;

		[Header("Scoreboard")]
		[SerializeField]
		public TMP_Text roundTimeText;

		[SerializeField]
		public GameObject scoreboardObj;

		[SerializeField]
		public UIFFAScoreboardEntry[] scores;

		[SerializeField]
		[Header("Buy Buttons")]
		public Button buyLivesButton;

		[SerializeField]
		public Button buyPassiveButton;

		[SerializeField]
		public Button buyConsumableButton;

		[Header("Lives Counter")]
		[SerializeField]
		public UIDigitAnimator livesCounterAnimator;

		[SerializeField]
		public UIAlphaFade livesCounterAnimatorFade;

		[NonSerialized]
		public List<ScoreEntry> scoreEntries;

		[NonSerialized]
		public int authViewCharGold;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnGameStart(int startingLives)
		{
		}

		public void ResetUI()
		{
		}

		public void SortScores()
		{
		}

		public void ResetScores()
		{
		}

		public void UpdateScore(int playerId, int teamId, string name, int score, int lives)
		{
		}

		public void UpdateTimer(float matchRemainingTime)
		{
		}

		public void ShowLivesCounter(int newLives)
		{
		}

		[IteratorStateMachine(typeof(_003CLiveCounterCoroutine_003Ed__22))]
		public IEnumerator LiveCounterCoroutine(int newLives)
		{
			return null;
		}
	}
}
