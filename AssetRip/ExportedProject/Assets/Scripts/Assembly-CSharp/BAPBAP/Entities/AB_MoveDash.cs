using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_MoveDash : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float castingTime;

			public float dashTime;

			public float baseCooldown;

			public float dashSpeed;

			public float dashDecel;

			[Header("VFX/SFX")]
			public GameObject vfxCastPrefab;

			public AudioClipData sfxCast;
		}

		public class CustomDashSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_MoveDash behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float dashTime;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(AB_MoveDash behaviour, byte trigger, float dashTime)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
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

		[NonSerialized]
		public Config config;

		public AB_MoveDash(Config config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}
	}
}
