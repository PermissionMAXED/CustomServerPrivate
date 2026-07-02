using System;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.Local
{
	public class SelectableBehaviour : MonoBehaviour, ISelectable
	{
		public float selectionTime;

		public UnityEvent OnSelectEvent;

		public UnityEvent OnDeselectEvent;

		public UnityEvent OnHoverEnterEvent;

		public UnityEvent OnHoverExitEvent;

		public SelectableResponse[] selectableResponses;

		public bool SelectOnStart;

		public bool DeselectOnStart;

		public bool selected;

		public bool hovered;

		[NonSerialized]
		public Action onSelected;

		public bool disableColliderOnSelect;

		public bool allowSelection;

		public Action OnSelected
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual void Awake()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void Select()
		{
		}

		public virtual void Deselect()
		{
		}

		public virtual void HoverEnter()
		{
		}

		public virtual void HoverExit()
		{
		}

		public virtual bool CanSelect()
		{
			return false;
		}

		public virtual GameObject GetGameObject()
		{
			return null;
		}

		public virtual float GetSelectionTime()
		{
			return 0f;
		}

		public virtual void OnSelectUpdate(float deltaTime)
		{
		}

		public virtual void OnHoverUpdate(float deltaTime)
		{
		}
	}
}
