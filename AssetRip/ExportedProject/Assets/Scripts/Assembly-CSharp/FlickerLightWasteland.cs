using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlickerLightWasteland : MonoBehaviour
{
	[CompilerGenerated]
	public sealed class _003CambientLight_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public FlickerLightWasteland _003C_003E4__this;

		[NonSerialized]
		public float _003CelapsedTime_003E5__2;

		[NonSerialized]
		public float _003CstartIntensity_003E5__3;

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
		public _003CambientLight_003Ed__8(int _003C_003E1__state)
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

	public Light lightAsset;

	public float minIntensity;

	public float maxIntensity;

	public float flickerSpeed;

	public float smoothingFactor;

	[NonSerialized]
	public Coroutine flickerCoroutine;

	[NonSerialized]
	public float targetIntensity;

	public void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CambientLight_003Ed__8))]
	public IEnumerator ambientLight()
	{
		return null;
	}

	public void OnDisable()
	{
	}
}
