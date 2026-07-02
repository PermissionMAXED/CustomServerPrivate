using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UISelectionWheel : MonoBehaviour
	{
		public class OptionData
		{
			public string title;

			public Sprite icon;

			public Color iconColor;

			public Material iconMaterial;

			public OptionData()
			{
			}

			public OptionData(string title, Sprite icon, Color iconColor, Material iconMaterial)
			{
			}
		}

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[Header("References")]
		[SerializeField]
		public Canvas selectWheelCanvas;

		[SerializeField]
		public CanvasGroup selectWheelCanvasGroup;

		[SerializeField]
		public MonoBehaviour startAnimation;

		[SerializeField]
		public CanvasGroup wheelDisabledGroup;

		[SerializeField]
		public GameObject wheelOptionElementPrefab;

		[SerializeField]
		public Material wheelOptionMat;

		[SerializeField]
		[Header("Element References")]
		public RectTransform wheelPivot;

		[SerializeField]
		public UISelectionWheelOptionElement centerOption;

		[SerializeField]
		public UISelectableLerpElement cancelDeadzone;

		[SerializeField]
		public Transform wheelOptionsParent;

		[Tooltip("How much to hold the input in order to show the wheel")]
		[Header("Input Settings")]
		[SerializeField]
		public float inputHoldTimerToOpen;

		[Tooltip("Select and perform a wheel option if clicked and dragged more than this distance, in pixels. Scales with ui resolution")]
		[SerializeField]
		public float wheelQuickOpenDist;

		[Header("Settings")]
		[Tooltip("When opening the wheel, place it centered on the mouse position on screen")]
		[SerializeField]
		public bool placeAtMousePos;

		[Tooltip("Is the center option of the selection wheel enabled to be used?")]
		[SerializeField]
		public bool centerOptionEnabled;

		[Tooltip("Is the center option of the selection wheel interactable, if enabled?")]
		[ConditionalHide("centerOptionEnabled", true)]
		[SerializeField]
		public bool centerOptionInteractable;

		[Tooltip("Should the cancel deadzone show when the mouse exits the center option? This will hide the center option swap it for the cancel deadzone.")]
		[ConditionalHide("centerOptionEnabled", true)]
		[SerializeField]
		public bool enableCancelDeadzoneOnCenterExit;

		[SerializeField]
		[Tooltip("How much distance to move until the wheel options start to get selected. Also the center zone option radius")]
		public float selectMoveThreshold;

		[SerializeField]
		[Tooltip("Unselect any current wheel option if the mouse surpassed this distance. If set to 0, we dont check for this")]
		public float wheelDistLimit;

		[Header("Sfx")]
		[SerializeField]
		public AudioManager.SFX openAudioClip;

		[SerializeField]
		public float openSfxVolume;

		[SerializeField]
		public AudioManager.SFX hoverAudioClip;

		[SerializeField]
		public float hoverSfxVolume;

		[SerializeField]
		public AudioManager.SFX selectAudioClip;

		[SerializeField]
		public float selectSfxVolume;

		[SerializeField]
		public AudioManager.SFX removeAudioClip;

		[SerializeField]
		public float removeSfxVolume;

		[NonSerialized]
		public int wheelOptionCount;

		[NonSerialized]
		public UISelectionWheelOptionElement[] wheelElement;

		[NonSerialized]
		public Material wheelOptionMatInstance;

		[NonSerialized]
		public float wheelElementRadius;

		[NonSerialized]
		public bool centerDeadzoneEnabled;

		[NonSerialized]
		public float selectMoveThresholdSqr;

		[NonSerialized]
		public float wheelQuickOpenDistSqr;

		[NonSerialized]
		public float wheelDistLimitSqr;

		[NonSerialized]
		public float holdTimer;

		[NonSerialized]
		public bool wheelIsActive;

		[NonSerialized]
		public int selectedElementId;

		[NonSerialized]
		public Vector2 wheelMoveDir;

		[NonSerialized]
		public Vector2 startMousePos;

		[NonSerialized]
		public InputBinding input;

		[NonSerialized]
		public bool inputDisabled;

		public Action<int> selectAction;

		public Action<int> hoverOptionAction;

		public Action unhoverOptionAction;

		public bool WheelIsActive => false;

		public bool InputDisabled => false;

		public virtual void Awake()
		{
		}

		public void InitializeWheel(int optionCount, InputBinding input)
		{
		}

		public void LoadOptions(OptionData[] options)
		{
		}

		public void LoadOption(int optionId, OptionData option)
		{
		}

		public virtual void GetInputDisabled()
		{
		}

		public void OnUpdate()
		{
		}

		public void ExternalOpenWheel()
		{
		}

		public void StartWheelSelect()
		{
		}

		public void OnBeginHold()
		{
		}

		public void HoldUpdateTryStart(bool hold)
		{
		}

		public void Update()
		{
		}

		public void CalculateMoveWheelDist()
		{
		}

		public void UpdateWheelHover()
		{
		}

		public void EndWheelSelect(bool invokeSelection = true)
		{
		}

		public virtual void EndPingSelect()
		{
		}

		public bool TryInvokeCurrentSelection()
		{
			return false;
		}

		public void InvokeSelection(int optionId)
		{
		}

		public int GetClosestWheelElementAngle(Vector2 direction)
		{
			return 0;
		}

		public void SetWheelOnCooldown(bool isInCooldown)
		{
		}

		public void ShowWheel()
		{
		}

		public void HoverOptionElement(int id)
		{
		}

		public void UnHoverOptionElement(int id)
		{
		}

		public void HoverSelectableElement(UISelectableLerpElement element)
		{
		}

		public void PlayOptionSelectAnim(int optionId)
		{
		}

		public void PlayOptionSelectAnim(UISelectionWheelOptionElement optionElement)
		{
		}

		public void PlayOptionRemoveAnim(int optionId)
		{
		}

		public void PlayOptionRemoveAnim(UISelectionWheelOptionElement optionElement)
		{
		}
	}
}
