using System;
using System.Runtime.InteropServices;
using BAPBAP.Entities.TargetDetection;
using BAPBAP.Entities.View;
using BAPBAP.Maps;
using BAPBAP.Player;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class EntityManager : NetworkBehaviour
	{
		public enum EntityType
		{
			Char = 0,
			Npc = 1,
			Loot = 2,
			Interactable = 3
		}

		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public CharNetwork charNetwork;

		[NonSerialized]
		public CharEvents charEvents;

		[NonSerialized]
		public CharSimulation charSim;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharAim charAim;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharItems charItems;

		[NonSerialized]
		public CharPassives charPassives;

		[NonSerialized]
		public CharStatusEffects charStatusEffects;

		[NonSerialized]
		public CharHpRegen charHpRegen;

		[NonSerialized]
		public CharDestroyTimer charDestroyTimer;

		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public BAPBAP.Entities.TargetDetection.TargetDetection targetDetection;

		[NonSerialized]
		public CharEmotes charEmotes;

		[NonSerialized]
		public CharInteract charInteract;

		[NonSerialized]
		public CharLabelNear charLabelNear;

		[NonSerialized]
		public CharDowned charDowned;

		[NonSerialized]
		public CharHpBar charHpBar;

		[NonSerialized]
		public CharModelSwap charModelSwap;

		[NonSerialized]
		public CharAnimator charAnim;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public CharFX charFx;

		[NonSerialized]
		public CharHidden charHidden;

		[NonSerialized]
		public CharHideArea charHideArea;

		[NonSerialized]
		public CharWorldPosition charWorldPosition;

		[NonSerialized]
		public CharBushInteract charBushInteract;

		[NonSerialized]
		public CharMinimap charMinimap;

		[NonSerialized]
		public CharMoveAudio charMoveAudio;

		[NonSerialized]
		public CharFogOfWar charFogOfWar;

		[NonSerialized]
		public CharFootsteps charFootsteps;

		[NonSerialized]
		public CharInterpolator charInterpolator;

		[NonSerialized]
		public CharVoicelines CharVoicelines;

		[NonSerialized]
		public EntityEventAnimator entityEventAnim;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public CapsuleCollider capsuleCollider;

		[NonSerialized]
		public PrefabConfig prefabConfig;

		[NonSerialized]
		public EntityAnimComponents entityAnimComponents;

		[NonSerialized]
		public EntityBehaviour entityBehaviour;

		[NonSerialized]
		public EntityTriggerAreaBehaviour entityTriggerAreaBehaviour;

		[Header("Entity Config")]
		[SerializeField]
		public bool isAirbornAble;

		[SerializeField]
		public bool isFreezable;

		[SerializeField]
		public bool isRootAble;

		[SerializeField]
		public bool isMoveAble;

		[SerializeField]
		public bool isPullAble;

		[SerializeField]
		public bool isTeleportable;

		[Header("Entity Type Configs")]
		[SerializeField]
		public EntityType entityType;

		[SerializeField]
		public bool isNpc;

		[SerializeField]
		public bool isBot;

		[SerializeField]
		public bool isLootbox;

		[SerializeField]
		public bool isInteractable;

		[SerializeField]
		public bool isItem;

		[Header("Name")]
		[SerializeField]
		[SyncVar(hook = "OnRandomGuestNameChanged")]
		public bool randomGuestName;

		[NonSerialized]
		[SyncVar]
		public string customEntityName;

		[NonSerialized]
		[SyncVar]
		public bool isPrimary;

		[NonSerialized]
		[SyncVar(hook = "OnPlayerObjChanged")]
		public GameObject playerObj;

		[NonSerialized]
		[SyncVar]
		public int charId;

		[NonSerialized]
		[SyncVar]
		public int charInstanceId;

		[NonSerialized]
		public int ownerPlayerId;

		[NonSerialized]
		public bool dieWithPrimary;

		[SyncVar(hook = "OnEntityTeamIdChanged")]
		[SerializeField]
		public int entityTeamId;

		[NonSerialized]
		[SyncVar]
		public int botPlayerId;

		[NonSerialized]
		[SyncVar(hook = "OnBotSpectatorCountChanged")]
		public int botSpectatorCount;

		[NonSerialized]
		public bool isBotDead;

		[SyncVar(hook = "OnLockedChanged")]
		[NonSerialized]
		public byte locked;

		[NonSerialized]
		public byte inPortalLocks;

		[NonSerialized]
		public bool isDestroyed;

		[NonSerialized]
		public bool _isClient;

		public Action svOnLockedChanged;

		public Action clOnLockedChanged;

		public Action onDestroyEvent;

		[NonSerialized]
		public uint ___playerObjNetId;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_randomGuestName;

		public Action<GameObject, GameObject> _Mirror_SyncVarHookDelegate_playerObj;

		public Action<int, int> _Mirror_SyncVarHookDelegate_entityTeamId;

		public Action<int, int> _Mirror_SyncVarHookDelegate_botSpectatorCount;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_locked;

		public bool IsPlayer => false;

		public bool IsLocked => false;

		public bool NetworkrandomGuestName
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

		public string NetworkcustomEntityName
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkisPrimary
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

		public GameObject NetworkplayerObj
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkcharId
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

		public int NetworkcharInstanceId
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

		public int NetworkentityTeamId
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

		public int NetworkbotPlayerId
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

		public int NetworkbotSpectatorCount
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

		public byte Networklocked
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

		public void Awake()
		{
		}

		public override void OnStartClient()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void SvOnLockedChanged()
		{
		}

		public int GetTeamId()
		{
			return 0;
		}

		public int GetPlayerId()
		{
			return 0;
		}

		public string GetPlayerName()
		{
			return null;
		}

		public void UpdateTeam()
		{
		}

		public void AddLock()
		{
		}

		public void RemoveLock()
		{
		}

		public void ClStartAuth()
		{
		}

		public void ClStopAuth()
		{
		}

		public void OnPlayerObjChanged(GameObject oldPlayer, GameObject newPlayer)
		{
		}

		public void OnEntityTeamIdChanged(int oldValue, int newValue)
		{
		}

		public void OnRandomGuestNameChanged(bool oldValue, bool newValue)
		{
		}

		public void OnBotSpectatorCountChanged(int oldValue, int newValue)
		{
		}

		public void OnLockedChanged(byte oldValue, byte newValue)
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
