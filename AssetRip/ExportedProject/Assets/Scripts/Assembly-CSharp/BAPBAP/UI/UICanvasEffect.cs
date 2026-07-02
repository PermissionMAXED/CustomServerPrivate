using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Game.Dimensions;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.UI
{
	public class UICanvasEffect : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CApplySpeedEffectCoroutine_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UICanvasEffect _003C_003E4__this;

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
			public _003CApplySpeedEffectCoroutine_003Ed__54(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CRevealCanvasCoroutine_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Canvas canvas;

			public UICanvasEffect _003C_003E4__this;

			public float duration;

			public CanvasGroup canvasGroup;

			[NonSerialized]
			public float _003Ctime_003E5__2;

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
			public _003CRevealCanvasCoroutine_003Ed__58(int _003C_003E1__state)
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

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public AudioManager audioManager;

		[Header("Settings")]
		public AnimationCurve revealCurve;

		[Header("References")]
		public Canvas parentCanvas;

		[Header("Canvas Effects")]
		public CanvasGroup blindEffectCanvasGroup;

		public CanvasGroup skinnyHiddenEffectCanvasGroup;

		public CanvasGroup dangerEffectCanvasGroup;

		public CanvasGroup telescopeEffectCanvasGroup;

		public CanvasGroup teleportEffectCanvasGroup;

		public CanvasGroup downedEffectCanvasGroup;

		public UIAlphaLoop telescopeEffectLoop;

		public CanvasGroup killEffectCanvasGroup;

		public CanvasGroup damageEffectCanvasGroup;

		public CanvasGroup lowHpEffectCanvasGroup;

		public UIAlphaLoop lowHpEffectLoop;

		public CanvasGroup killedEffectCanvasGroup;

		public CanvasGroup speedEffectCanvasGroup;

		public CanvasGroup sinCityEffectCanvasGroup;

		public CanvasGroup sinCityPassiveCanvasGroup;

		public CanvasGroup bloodDiveCanvasGroup;

		public CanvasGroup remoteControlCanvasGroup;

		[SerializeField]
		[Header("Other Effects")]
		public AudioSource skinnyHiddenEffectAudioSource;

		[SerializeField]
		public AudioSource downedEffectAudioSource;

		[SerializeField]
		public float zoneFxOverlaySpeed;

		[NonSerialized]
		public Vignette downedVignetteComponent;

		[NonSerialized]
		public ColorCurves downedColorCurvesComponent;

		[NonSerialized]
		public float skinnyHiddenEffectVolume;

		[NonSerialized]
		public bool animateSkinnyFx;

		[NonSerialized]
		public float zoneLerpDir;

		[NonSerialized]
		public bool zoneIsActive;

		[NonSerialized]
		public bool animateZoneFx;

		[NonSerialized]
		public float sinCityGenericLerpDir;

		[NonSerialized]
		public bool sinCityGenericIsActive;

		[NonSerialized]
		public bool animateSinCityGenericFx;

		[NonSerialized]
		public float sinCityPassiveLerpDir;

		[NonSerialized]
		public bool sinCityPassiveIsActive;

		[NonSerialized]
		public bool animateSinCityPassiveFx;

		[NonSerialized]
		public float speedTime;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void ApplyBlindEffect(bool isActive)
		{
		}

		public void ApplySkinnyInvisEffect(bool isActive)
		{
		}

		public void ApplyDownedEffect(bool isDowned)
		{
		}

		public void ApplyRemoteControlEffect(bool isEnabled)
		{
		}

		public void SetZoneOverlayEffect(bool isActive)
		{
		}

		public void SetDimensionOverlayEffect(bool isActive, Dimension.DimensionType dimensionType = Dimension.DimensionType.None)
		{
		}

		public void SetSinCityPassiveOverlayEffect(bool isActive)
		{
		}

		public void SetTelescopeOverlayEffect(bool isActive, bool doTransition = true)
		{
		}

		public void SetTeleportOverlayEffect(bool isActive, bool doTransition = true)
		{
		}

		public void ApplyKilledEffect(bool isActive)
		{
		}

		public void ApplyDamageEffect(float duration = 0.25f)
		{
		}

		public void ApplyKillEffect(float duration = 0.3f)
		{
		}

		public void ApplyBloodDiveEffect(bool isActive)
		{
		}

		public void ApplySpeedEffect(float duration)
		{
		}

		[IteratorStateMachine(typeof(_003CApplySpeedEffectCoroutine_003Ed__54))]
		public IEnumerator ApplySpeedEffectCoroutine()
		{
			return null;
		}

		public void ApplyLowHpEffect(bool isActive)
		{
		}

		public void ApplyCanvasEffect(CanvasGroup canvasGroup, bool isActive, float duration = 0.25f)
		{
		}

		public void RevealCanvas(CanvasGroup canvasGroup, Canvas canvas, float duration = 0.5f)
		{
		}

		[IteratorStateMachine(typeof(_003CRevealCanvasCoroutine_003Ed__58))]
		public IEnumerator RevealCanvasCoroutine(CanvasGroup canvasGroup, Canvas canvas, float duration)
		{
			return null;
		}
	}
}
