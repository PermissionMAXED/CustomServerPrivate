using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class UIFlexibleGridLayout : MonoBehaviour
{
	[CompilerGenerated]
	public sealed class _003CUpdateGridElements_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public UIFlexibleGridLayout _003C_003E4__this;

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
		public _003CUpdateGridElements_003Ed__9(int _003C_003E1__state)
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

	[Header("Options")]
	[SerializeField]
	public float _maxFlexWidth;

	[SerializeField]
	public float _maxFlexHeight;

	[SerializeField]
	[Header("References")]
	public GridLayoutGroup _gridLayoutGroup;

	[SerializeField]
	public RectTransform _rectTransform;

	[NonSerialized]
	public Vector2 _cachedCellStartingSize;

	[NonSerialized]
	public Vector2 _cachedResolution;

	public void Start()
	{
	}

	public void OnEnable()
	{
	}

	public void LateUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateGridElements_003Ed__9))]
	public IEnumerator UpdateGridElements()
	{
		return null;
	}

	public static Vector2Int Size(GridLayoutGroup grid)
	{
		return default(Vector2Int);
	}

	public static Vector2Int FlexibleSize(GridLayoutGroup grid)
	{
		return default(Vector2Int);
	}

	public static int GetAnotherAxisCount(int totalCount, int axisCount)
	{
		return 0;
	}
}
