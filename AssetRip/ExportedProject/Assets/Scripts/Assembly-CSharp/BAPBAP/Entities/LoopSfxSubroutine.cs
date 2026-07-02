using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class LoopSfxSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public AudioSource audioSource;

		[NonSerialized]
		public GameObject loopSfxObj;

		[NonSerialized]
		public bool isActive;

		public LoopSfxSubroutine(Ability ability, AudioClip clip, float volume, Transform attachTransform)
		{
		}

		public LoopSfxSubroutine(EntityManager entityManager, AudioClip clip, float volume, Transform attachTransform)
		{
		}

		public override void DeBuild()
		{
		}

		public void SpawnLoopSfx(AudioClip clip, float volume, Transform attachTransform)
		{
		}

		public void DestroyLoopSfx()
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

		public void OnActiveChanged()
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
