using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIPropertyController : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, IMoveHandler, ISubmitHandler
	{
		[SerializeField]
		[Header("References")]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public Button propertySelectable;

		[SerializeField]
		public Image selectedImage;

		[SerializeField]
		public TMP_Text propertyText;

		[SerializeField]
		public TMP_Text descriptionText;

		[SerializeField]
		[Header("Settings")]
		public float nonInteractableAlpha;

		[NonSerialized]
		public Action<UIPropertyController> _onSelectedAction;

		[NonSerialized]
		public string _propertyTrKey;

		[NonSerialized]
		public string _descTrKey;

		[NonSerialized]
		public bool _isSelected;

		public Selectable PropertySelectable => null;

		public void InitializeProp(string propertyTrKey, string descriptionTrKey = null, Action<UIPropertyController> onSelectedAction = null)
		{
		}

		public virtual void Localise(Translator translator)
		{
		}

		public virtual void OnInputModeChanged(InputMode inputMode)
		{
		}

		public void SetInteractable(bool isInteractable)
		{
		}

		public void SetDescription(string descriptionTranslationKey = null)
		{
		}

		public void ToggleDescription(bool isEnabled)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnSubmit(BaseEventData eventData)
		{
		}

		public void OnMove(AxisEventData eventData)
		{
		}

		public virtual void OnSelect()
		{
		}

		public virtual void OnDeselect()
		{
		}

		public virtual void OnSubmit()
		{
		}

		public virtual void OnMove(Vector2 moveDir)
		{
		}

		public void SetSelected(bool isSelected)
		{
		}
	}
}
