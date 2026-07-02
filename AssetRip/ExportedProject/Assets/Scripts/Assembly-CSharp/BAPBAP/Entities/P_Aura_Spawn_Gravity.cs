using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Aura_Spawn_Gravity : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float force;

			public float hitboxRadius;

			public float radiusPerHealth;

			public float forcePerHealth;

			public float vfxStartScale;

			public GameObject spellPrefab;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Aura_Spawn_Gravity passive;

			public CustomPassiveSubroutine(P_Aura_Spawn_Gravity _ability)
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public HitboxContinuousMove hBox;

		[NonSerialized]
		public int vfxReadyId;

		[NonSerialized]
		public GameObject vfxObj;

		[NonSerialized]
		public int prevHealth;

		[NonSerialized]
		public GameObject hBoxObj;

		[NonSerialized]
		public float radius;

		[NonSerialized]
		public float force;

		public override PassiveConfiguration passiveConfig => null;

		public P_Aura_Spawn_Gravity(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void SpawnDpsObject(int predTickNum)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}

		public void OnRadiusChanged()
		{
		}

		public void OnForceChanged()
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
}
