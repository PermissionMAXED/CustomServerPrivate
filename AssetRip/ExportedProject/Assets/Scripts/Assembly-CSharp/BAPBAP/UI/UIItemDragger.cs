using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI
{
	public class UIItemDragger : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		[CompilerGenerated]
		public sealed class _003CWaitToReEnable_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIItemDragger _003C_003E4__this;

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
			public _003CWaitToReEnable_003Ed__29(int _003C_003E1__state)
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
		public UIItems uiItems;

		[SerializeField]
		public int slotIndex;

		[SerializeField]
		public float beginDragDistThreshold;

		[SerializeField]
		public float maxDistance;

		[SerializeField]
		public float dragHoldStartTime;

		[SerializeField]
		public SFXData dragBeginSfxData;

		[NonSerialized]
		public bool pointerDown;

		[NonSerialized]
		public bool isDragging;

		[NonSerialized]
		public float dragStartTime;

		[NonSerialized]
		public float beginDragDistThresholdSqr;

		[NonSerialized]
		public float maxDistanceSqr;

		[NonSerialized]
		public OnPointerListener onPointerListener;

		[NonSerialized]
		public Vector2 originalPosition;

		[NonSerialized]
		public Vector2 offset;

		[NonSerialized]
		public RectTransform dragTr;

		[NonSerialized]
		public Vector2 startPos;

		[NonSerialized]
		public int currentDragIndex;

		[NonSerialized]
		public UIItemSlotElement[] itemSlots;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDisable()
		{
		}

		public void Update()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void BeginDrag()
		{
		}

		public void StopDrag()
		{
		}

		public void CompleteDrag(Vector2 position)
		{
		}

		public int GetClosestSlotIndex(Vector2 pointerPosition)
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CWaitToReEnable_003Ed__29))]
		public IEnumerator WaitToReEnable()
		{
			return null;
		}
	}
}
