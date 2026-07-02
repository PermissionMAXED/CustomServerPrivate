using System;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local;

public class InputManager : MonoBehaviour
{
	[NonSerialized]
	public UIManager uiManager;

	[NonSerialized]
	public UIItems uiItems;

	[NonSerialized]
	public Camera mainCamera;

	[NonSerialized]
	public InputSystem inputSystem;

	[NonSerialized]
	public int groundMask;

	[NonSerialized]
	public RaycastHit mouseHit;

	[NonSerialized]
	public Ray mouseRay;

	[Header("Configs")]
	[SerializeField]
	[Tooltip("Server FPS, keeping it too low will add delay and sporadicalness between ticks")]
	public int serverFps;

	[Tooltip("If set, the editor will disable VSync and run at an uncapped FPS")]
	[SerializeField]
	public bool editorUncapFps;

	[Tooltip("Simulation tick rate for both client and server")]
	[SerializeField]
	public float simHz;

	[Tooltip("Global update rate for state. How frequent should server updates be?")]
	[SerializeField]
	public float serverUpdateHz;

	[SerializeField]
	[Tooltip("Global lerp for remote entities. How many ticks behind should remote entities be lerping at?")]
	public float entityLerpMultiplier;

	[SerializeField]
	[Tooltip("Max ping to reconciliate predicted entities (in s)")]
	public float maxPingPredRecon;

	[SerializeField]
	[Tooltip("Should there be random desyncs on the server? For testing reconciliation/rollback only")]
	public bool doServerSimDesync;

	[HideInInspector]
	public float simFixedDt;

	[HideInInspector]
	public double simFixedDtAsDouble;

	[HideInInspector]
	public float serverUpdateRate;

	[HideInInspector]
	public float entityLerpTime;

	[HideInInspector]
	public int maxTicksPredRecon;

	[NonSerialized]
	public bool bufferInputsForTick;

	[NonSerialized]
	public bool[] bufferedKeyDowns;

	[NonSerialized]
	public bool[] bufferedKeyUps;

	[NonSerialized]
	public bool keysDisabled;

	[NonSerialized]
	public bool aimDisabled;

	[NonSerialized]
	public int cmdLength;

	[NonSerialized]
	public InputBinding[] cmdInputBindings;

	[NonSerialized]
	public int cachedCmdLmbId;

	[HideInInspector]
	public int clTickNum;

	[HideInInspector]
	public double clTickStartTime;

	[HideInInspector]
	public bool quickCastAbilities;

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void SendCmdUpgradeGear(byte slotId)
	{
	}

	public void PopulateCommand(CommandId cmdId)
	{
	}

	public void FixedUpdate()
	{
	}

	public void Update()
	{
	}

	public double GetFixedTimeElapsed()
	{
		return 0.0;
	}

	public void ToggleEnabled(bool enabled)
	{
	}

	public Command ConsumeCommand(Command pooledCmd, int tickNum, float smoothedPing, bool doRandom)
	{
		return null;
	}

	public void ConsumeButtons(Command cmd)
	{
	}

	public void ConsumeCursor(Command cmd)
	{
	}

	public static InputTarget GetInputTargetByAbilityCmd(CommandId cmdId)
	{
		return default(InputTarget);
	}

	public InputBinding AnyCmdDown()
	{
		return null;
	}
}
