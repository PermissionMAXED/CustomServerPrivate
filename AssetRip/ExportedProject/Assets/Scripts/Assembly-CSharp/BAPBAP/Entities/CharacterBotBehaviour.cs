using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class CharacterBotBehaviour : NpcBehaviour
	{
		[Serializable]
		public class TransitionState
		{
			public float score;

			public BotStates state;

			public TransitionState(BotStates _state)
			{
			}
		}

		public enum BotStates
		{
			Idle = 0,
			Wandering = 1,
			MoveZoneCenter = 2,
			CombatEnemy = 3,
			SearchEnemy = 4,
			Looting = 5,
			Heal = 6
		}

		public class BotEvaluateTransitionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public bool firstFrame;

			[NonSerialized]
			public byte triggerTransition;

			public BotEvaluateTransitionSubroutine(CharacterBotBehaviour _behaviour, byte _triggerTransition)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class SetCurrentStateSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public BotStates botState;

			public SetCurrentStateSubroutine(CharacterBotBehaviour _behaviour, BotStates _botState)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class BotTransitionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public bool firstFrame;

			public BotTransitionSubroutine(CharacterBotBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class NpcInterruptAbilityTargetDistSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public CastFlags castFlag;

			[NonSerialized]
			public bool triggered;

			[NonSerialized]
			public float distSqr;

			[NonSerialized]
			public int slot;

			public NpcInterruptAbilityTargetDistSubroutine(CharacterBotBehaviour _behaviour, float distance)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class BotPickUpItemSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public byte triggerInvalidItem;

			public BotPickUpItemSubroutine(CharacterBotBehaviour _behaviour, byte _triggerInvalidItem)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomNpcFollowItemTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour npcBehaviour;

			[NonSerialized]
			public byte triggerTargetLost;

			[NonSerialized]
			public NavMeshAgent agent;

			[NonSerialized]
			public float maxDistFromSelfSqr;

			[NonSerialized]
			public float followDist;

			[NonSerialized]
			public float followDistSqr;

			[NonSerialized]
			public float followDistMarginSqr;

			[NonSerialized]
			public bool doPivotAroundTarget;

			[NonSerialized]
			public int pivotAxisDir;

			public CustomNpcFollowItemTargetSubroutine(CharacterBotBehaviour _npcBehaviour, byte _triggerTargetLost, float _maxDistFromSelf, float _followDist = 0f, float followDistMargin = 2f, bool _doPivotAroundTarget = false)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class BotWanderingPosSubroutine : NpcWanderingPosSubroutine
		{
			[NonSerialized]
			public new NpcBehaviour behaviour;

			[NonSerialized]
			public byte trigger;

			public BotWanderingPosSubroutine(NpcBehaviour _behaviour, byte _trigger)
				: base(null)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomNpcDefensiveCombatSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public byte triggerCombat;

			[NonSerialized]
			public bool firstFrame;

			[NonSerialized]
			public float timer;

			[NonSerialized]
			public float currentCombatChance;

			[NonSerialized]
			public float minDistanceToCombatSqr;

			public CustomNpcDefensiveCombatSubroutine(CharacterBotBehaviour _behaviour, byte _triggerCombat, float _minDistanceToCombat)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomNpcOffensiveCombatSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CharacterBotBehaviour behaviour;

			[NonSerialized]
			public byte triggerDefense;

			[NonSerialized]
			public bool firstFrame;

			[NonSerialized]
			public float timer;

			[NonSerialized]
			public float minDistanceToDefenseSqr;

			public CustomNpcOffensiveCombatSubroutine(CharacterBotBehaviour _behaviour, byte _triggerDefense, float _minDistanceToDefense)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[Header("Bot Difficulty Config")]
		[SerializeField]
		public bool applyDifficulty;

		[Min(0f)]
		[Tooltip("Automatically modify config values by this percentage to change general bot difficulty. If 1, no modification will happen")]
		[SerializeField]
		public float difficultyMultiplier;

		[Tooltip("How much to modify this value by the difficulty percentage")]
		[SerializeField]
		public float targetLerpVelocityScaling;

		[Tooltip("How much to modify this value by the difficulty percentage")]
		[SerializeField]
		public float damageToPlayersScaling;

		[SerializeField]
		[Tooltip("How much to modify this value by the difficulty percentage")]
		public float aggresivenessScaling;

		[Tooltip("How much to modify this value by the difficulty percentage")]
		[SerializeField]
		public float abilityReactionScaling;

		[Tooltip("How much to modify this value by the difficulty percentage")]
		[SerializeField]
		public float futurePredictUnaccuracyScaling;

		[Tooltip("How much to modify all ability update rate by the difficulty percentage")]
		[SerializeField]
		public float updateRateScaling;

		[Tooltip("How much to modify all ability random spread by the difficulty percentage")]
		[SerializeField]
		public float randomSpreadScaling;

		[SerializeField]
		[Tooltip("How much to modify all ability extra cooldown by the difficulty percentage")]
		public float extraCdScaling;

		[Min(0f)]
		[SerializeField]
		[Header("Tick Rates Settings")]
		public int zoneMoveCenterTickRate;

		[SerializeField]
		[Min(0f)]
		public int enemySpottedTickRate;

		[Min(0f)]
		[SerializeField]
		public int searchForLootTickRate;

		[SerializeField]
		[Min(0f)]
		public int pickUpItemTickRate;

		[SerializeField]
		[Min(0f)]
		public int tryHealTickRate;

		[SerializeField]
		[Min(0f)]
		public int wanderingTickRate;

		[Header("Healing State Settings")]
		[Tooltip("How much distance to keep from the target when healing")]
		[SerializeField]
		[Min(0f)]
		public float keepDistToEnemyHealing;

		[SerializeField]
		[Tooltip("Start healing when hp falls under this percentage")]
		public AnimationCurve chanceOfHealingByNormHp;

		[Min(0f)]
		[SerializeField]
		public float minDistToStartHeal;

		[SerializeField]
		[Min(0f)]
		public float minDistToStopHeal;

		[Min(0f)]
		[SerializeField]
		[Tooltip("The distance that this character will try to be from its current enemy. Melee characters will need to be close to their enemies, while ranged characters will prefer to be far away from them")]
		[Header("Character Playstyle Settings")]
		public float keepDistToEnemy;

		[Range(0f, 1f)]
		[Tooltip("Value controlling how offensive or deffensive the bot is. 0 = always defensive, 1 = always offensive")]
		[SerializeField]
		public float aggresiveness;

		[SerializeField]
		[Min(1f)]
		[Tooltip("The added distance to KeepDistToEnemy value that this character will try to be from its current enemy when on defensive state")]
		public float defenseDistAdded;

		[SerializeField]
		public float defensiveUpdateRate;

		[SerializeField]
		public float offensiveUpdateRate;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How slow to react/perform abilities the bot will be. Incrementing this will make the bot slower to react and perform abilities (this will increase the base ability update rate)")]
		public float abilityReactionFactor;

		[Min(0f)]
		[Tooltip("How much distance to track a target for. If surpassed this distance, lose the target")]
		[SerializeField]
		public float maxDistanceToTarget;

		[SerializeField]
		[Tooltip("Engage in combat with a found target if its under this minimum distance")]
		[Min(0f)]
		public float engageInCombatMinDist;

		[SerializeField]
		[Tooltip("The chance to fight based on current normalized hp")]
		public AnimationCurve chanceOfFightingByNormHp;

		[SerializeField]
		[Tooltip("The chance to search for npc targets to fight with, based on current item power level")]
		public AnimationCurve fighNpcChancePowerLevel;

		[Tooltip("Multiplier for the power level chance. Lower values will decrease the overall chance to fight npcs")]
		[SerializeField]
		public float fightNpcChanceMult;

		[Header("Future Predict Settings")]
		[Tooltip("How much future predictions will overshoot/stay short. 0 = no prediction, 1 = perfect prediction, 2 = overshooted prediction")]
		[SerializeField]
		public float futurePredictMultiplier;

		[Tooltip("How accurate future predictions will be. 0 = perfect future prediction, 1 = future prediction will be randomized, meaning the prediction will be offseted by the random given amount (will fall short or overshoot the prediction)")]
		[SerializeField]
		[Range(0f, 1f)]
		public float futurePredictUnaccuracy;

		[Header("Abilities")]
		[SerializeField]
		public AbilityTriggerData abilityLMB;

		[SerializeField]
		public AbilityTriggerData abilityQ;

		[SerializeField]
		public AbilityTriggerData abilitySpace;

		[SerializeField]
		public AbilityTriggerData abilityUlt;

		[SerializeField]
		public AbilityTriggerData consumable1;

		[NonSerialized]
		public TransitionState score_idle;

		[NonSerialized]
		public byte EXT_TRIGGER_IDLE;

		[NonSerialized]
		public TransitionState score_wandering;

		[NonSerialized]
		public byte EXT_TRIGGER_WANDERING;

		[NonSerialized]
		public TransitionState score_move_zone_center;

		[NonSerialized]
		public byte EXT_TRIGGER_MOVE_ZONE_CENTER;

		[NonSerialized]
		public TransitionState score_enemy_spotted;

		[NonSerialized]
		public byte EXT_TRIGGER_COMBAT_ENEMY;

		[NonSerialized]
		public TransitionState score_enemy_search;

		[NonSerialized]
		public TransitionState score_search_for_loot;

		[NonSerialized]
		public byte EXT_TRIGGER_SEARCH_LOOT;

		[NonSerialized]
		public TransitionState score_heal;

		[NonSerialized]
		public byte EXT_TRIGGER_HEAL;

		[NonSerialized]
		public BotStates currentState;

		[NonSerialized]
		public BotStates nextDesiredState;

		[NonSerialized]
		public byte stateTrigger;

		[NonSerialized]
		public bool isAbleToTransition;

		[NonSerialized]
		public ItemObject currentItemTarget;

		[NonSerialized]
		public float minDistToStartHealSqr;

		[NonSerialized]
		public float defenseKeepDistToEnemy;

		[NonSerialized]
		public float engageInCombatMinDistSqr;

		public override void PreAwake(EntityManager e)
		{
		}

		public override void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void TrySetAggro(Transform target)
		{
		}

		public void CalculateScores()
		{
		}

		public void EvaluateScoresAndSetNextState()
		{
		}

		public void EvaluateScore(TransitionState stateToEvaluate, ref TransitionState bestTransition, ref float bestScore)
		{
		}

		public float CalculateScore_Wandering()
		{
			return 0f;
		}

		public float CalculateScore_MoveZoneCenter()
		{
			return 0f;
		}

		public float CalculateScore_EnemySearch()
		{
			return 0f;
		}

		public float CalculateScore_EnemySpotted()
		{
			return 0f;
		}

		public float CalculateScore_SearchForLoot()
		{
			return 0f;
		}

		public float CalculateScore_Heal()
		{
			return 0f;
		}

		public void TrySetFoundChar(EntityManager foundChar)
		{
		}

		public void SetNewState(BotStates newState)
		{
		}

		public void SetState(BotStates newState)
		{
		}

		public byte GetTransitionTriggerState(BotStates state)
		{
			return 0;
		}

		public bool IsPositionOutOfBRRing(Vector3 pos)
		{
			return false;
		}

		public bool BotCanPickupItem(Item item)
		{
			return false;
		}

		public void InitializeDifficulty(float multiplier)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
