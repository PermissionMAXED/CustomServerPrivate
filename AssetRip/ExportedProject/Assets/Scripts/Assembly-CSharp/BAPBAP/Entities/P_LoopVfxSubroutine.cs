using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_LoopVfxSubroutine : LoopVfxSubroutine
	{
		[NonSerialized]
		public bool showOnlyIfHasAuth;

		[NonSerialized]
		public float vfxDestroyDelay;

		public P_LoopVfxSubroutine(Passive passive, GameObject loopVfxPrefab, Transform attachTransform, bool showOnlyIfHasAuth = false)
			: base((Ability)null, (GameObject)null, (Transform)null)
		{
		}

		public override void DestroyVfx()
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnActiveChanged()
		{
		}
	}
}
