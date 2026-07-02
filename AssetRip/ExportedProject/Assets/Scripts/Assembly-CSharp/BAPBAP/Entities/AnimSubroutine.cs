using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AnimSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public int stateHash;

		[NonSerialized]
		public float time;

		public AnimSubroutine(Ability ability, AnimAction action, string animState, AnimLayerIndices animLayer, float time = 0f)
		{
		}

		public AnimSubroutine(EntityManager entityManager, AnimAction action, string animState, AnimLayerIndices animLayer, float time = 0f)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
