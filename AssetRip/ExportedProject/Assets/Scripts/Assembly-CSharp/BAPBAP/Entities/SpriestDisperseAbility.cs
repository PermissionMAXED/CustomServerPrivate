using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpriestDisperseAbility : Ability
	{
		public class CustomParryStartSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SpriestDisperseAbility ability;

			public CustomParryStartSubroutine(SpriestDisperseAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomParrySubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public SpriestDisperseAbility ability;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte triggerSilenced;

			[NonSerialized]
			public CastFlags interruptCastFlags;

			public CustomParrySubroutine(SpriestDisperseAbility _ability, byte _trigger, byte _triggerSilenced)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnNetDeserialize(NetworkReader netReader)
			{
			}

			public override void OnNetSerialize(NetworkWriter netWriter)
			{
			}

			public override bool OnNetDebugCompare(NetworkReader netReader)
			{
				return false;
			}

			public override void OnNetDebugLog(StringBuilder sb)
			{
			}
		}

		public class CustomEndParrySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SpriestDisperseAbility ability;

			public CustomEndParrySubroutine(SpriestDisperseAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDestroyLoopVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SpriestDisperseAbility ability;

			[NonSerialized]
			public LoopVfxSubroutine loopVfx;

			public CustomDestroyLoopVfxSubroutine(SpriestDisperseAbility _ability, LoopVfxSubroutine _loopVfx)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Hitbox")]
		[SerializeField]
		public GameObject spellReflectHitbox;

		[SerializeField]
		public float cdReductionAmount;

		[SerializeField]
		public float percentHealDamageTaken;

		[SerializeField]
		public float healMaxAmountPercent;

		[SerializeField]
		public PassiveSO passiveToActivate;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float parryTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxParryLoopPrefab;

		[SerializeField]
		public GameObject vfxParrySuccessPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxStart;

		[Header("Materials")]
		[SerializeField]
		public Material defaultMaterial;

		[SerializeField]
		public Material counterMaterial;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public LoopVfxSubroutine loopVfxSubroutine;

		[NonSerialized]
		public Hitbox currentParryHitbox;

		[NonSerialized]
		public SpriestSnareAbility snareAbility;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot()
		{
		}

		public void StartParry()
		{
		}

		public void EndParry()
		{
		}

		[ClientRpc]
		public void RpcCounterMaterialEnable()
		{
		}

		[ClientRpc]
		public void RpcCounterMaterialDisable()
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcCounterMaterialEnable()
		{
		}

		public static void InvokeUserCode_RpcCounterMaterialEnable(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcCounterMaterialDisable()
		{
		}

		public static void InvokeUserCode_RpcCounterMaterialDisable(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SpriestDisperseAbility()
		{
		}
	}
}
