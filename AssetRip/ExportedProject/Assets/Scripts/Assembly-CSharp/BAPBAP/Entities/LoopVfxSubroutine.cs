using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class LoopVfxSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public VFXStopParticles vfxStopParticles;

		[NonSerialized]
		public GameObject loopVfxInstance;

		[NonSerialized]
		public bool isActive;

		public LoopVfxSubroutine(Ability ability, GameObject loopVfxPrefab, Transform attachTransform)
		{
		}

		public LoopVfxSubroutine(EntityManager entityManager, GameObject loopVfxPrefab, Transform attachTransform)
		{
		}

		public override void DeBuild()
		{
		}

		public virtual void SpawnVfx(GameObject vfxPrefab, Transform parent)
		{
		}

		public virtual void DestroyVfx()
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void Stop()
		{
		}

		public void SetIsActive(bool _isActive)
		{
		}

		public virtual void OnActiveChanged()
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
