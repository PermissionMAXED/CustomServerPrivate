using System;
using System.Collections;
using BAPBAP.Localisation;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.UI
{
	public abstract class ControllerBase
	{
		[NonSerialized]
		public readonly ControllerManager _controllerManager;

		public ControllerManager Controller => null;

		public ModelManager Model => null;

		public UILobby View => null;

		public HttpClient Http => null;

		public WebSocketClient WS => null;

		public NetworkConfig NetworkConfig => null;

		public ControllerBase(ControllerManager controllerManager)
		{
		}

		public virtual void OnLocalise(Translator translator)
		{
		}

		public virtual void OnLoginComplete(LoadResponse response)
		{
		}

		public virtual void Dispose()
		{
		}

		public Coroutine StartCoroutine(IEnumerator routine)
		{
			return null;
		}

		public void StopCoroutine(IEnumerator routine)
		{
		}
	}
}
