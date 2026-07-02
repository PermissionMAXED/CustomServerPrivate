using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public abstract class UILobbyTabPage : MonoBehaviour
	{
		[SerializeField]
		public EventReference _snapshotEvent;

		[NonSerialized]
		public Selectable lastFocusedSelectable;

		public abstract CanvasGroup CanvasGroup { get; }

		public abstract Selectable CanvasGroupSelectable { get; }

		public abstract UIPosLerpFade UILerpFade { get; }

		public abstract UIAlphaFade UIAlphaFade { get; }

		public abstract UIAlphaFade backgroundUIFade { get; }

		public EventReference SnapshotEvent => default(EventReference);

		public abstract void Localise(Translator translator);

		public virtual void OnPageOpen()
		{
		}

		public virtual void OnPageClose()
		{
		}

		public virtual void OnInputModeChanged(InputMode inputMode)
		{
		}

		public void FocusSelectable(Selectable selectable)
		{
		}

		public UILobbyTabPage()
		{
		}
	}
}
