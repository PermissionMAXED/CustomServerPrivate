using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Maps;
using Mirror;
using TMPro;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class TerritoryZone : NetworkBehaviour
	{
		[SerializeField]
		public SpriteRenderer ringRenderer;

		[SerializeField]
		public SpriteRenderer zoneRenderer;

		[SerializeField]
		public int goldReward;

		[SerializeField]
		public float captureTime;

		[SerializeField]
		public float endFadeTime;

		[SerializeField]
		public float decayPercentage;

		[SerializeField]
		public Color allyColor;

		[SerializeField]
		public Color enemyColor;

		[SerializeField]
		public TMP_Text timerText;

		[SyncVar(hook = "OnCaptureTimerChanged")]
		[NonSerialized]
		public float captureTimer;

		[SyncVar(hook = "OnOwnerTeamIdChanged")]
		[NonSerialized]
		public int ownerTeamId;

		[SyncVar(hook = "OnOwnerCaptureTeamIdChanged")]
		[NonSerialized]
		public int captureTeamId;

		[SyncVar(hook = "OnTimeRemainingChanged")]
		[NonSerialized]
		public int timeRemaining;

		[SyncVar(hook = "OnActiveChanged")]
		[NonSerialized]
		public bool active;

		[SyncVar(hook = "OnContestedChanged")]
		[NonSerialized]
		public bool contested;

		[SyncVar]
		[NonSerialized]
		public bool ended;

		[NonSerialized]
		public float waitTime;

		[NonSerialized]
		public float waitTimeElapsed;

		[NonSerialized]
		public float endTime;

		[NonSerialized]
		public float endTimeElapsed;

		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[NonSerialized]
		public SphereCollider sphereCollider;

		[NonSerialized]
		public PrefabConfig prefabConfig;

		[NonSerialized]
		public List<EntityManager> currentEntities;

		[NonSerialized]
		public bool capturing;

		[NonSerialized]
		public float fadeTimer;

		public Action<float, float> _Mirror_SyncVarHookDelegate_captureTimer;

		public Action<int, int> _Mirror_SyncVarHookDelegate_ownerTeamId;

		public Action<int, int> _Mirror_SyncVarHookDelegate_captureTeamId;

		public Action<int, int> _Mirror_SyncVarHookDelegate_timeRemaining;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_active;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_contested;

		public float NetworkcaptureTimer
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkownerTeamId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkcaptureTeamId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworktimeRemaining
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public bool Networkactive
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool Networkcontested
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool Networkended
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void InitializeTimes(float waitTime, float endTime)
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public int EndObjective()
		{
			return 0;
		}

		public void Update()
		{
		}

		public void CheckEntities()
		{
		}

		public void Decay(float fixedDt, float percentage)
		{
		}

		public void Capture(int teamId, float fixedDt, bool ping = true)
		{
		}

		public void OnEnter(EntityManager e)
		{
		}

		public void SetZoneColor(Color color)
		{
		}

		public void SetRingColor(Color color)
		{
		}

		public void SetProgressRing(float percentage)
		{
		}

		public void OnCaptureTimerChanged(float oldValue, float newValue)
		{
		}

		public void OnOwnerTeamIdChanged(int oldValue, int newValue)
		{
		}

		public void OnOwnerCaptureTeamIdChanged(int oldValue, int newValue)
		{
		}

		public void OnTimeRemainingChanged(int oldValue, int newValue)
		{
		}

		public void OnContestedChanged(bool oldValue, bool newValue)
		{
		}

		public void OnActiveChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
