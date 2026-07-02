using System;
using System.Collections.Generic;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network.EventData;
using Mirror;

namespace BAPBAP.Entities
{
	public class CharEvents : NetworkBehaviour
	{
		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public VfxManager vfxManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharInterpolator charInterpolator;

		[NonSerialized]
		public List<VfxEventData> clVfxEventHistory;

		[NonSerialized]
		public List<SfxEventData> clSfxEventHistory;

		[NonSerialized]
		public List<AnimEventData> clAnimEventHistory;

		[NonSerialized]
		public List<WarpEventData> clWarpEventHistory;

		[NonSerialized]
		public int clLastRecvPredTickNum;

		[NonSerialized]
		public List<VfxEventData> vfxEventsBuffer;

		[NonSerialized]
		public List<SfxEventData> sfxEventsBuffer;

		[NonSerialized]
		public List<AnimEventData> animEventsBuffer;

		[NonSerialized]
		public List<WarpEventData> warpEventsBuffer;

		[NonSerialized]
		public int noneStateHash;

		public void PreAwake(EntityManager e)
		{
		}

		public void AddPredictedVfxEvent(VfxEventData eventData, bool isResim)
		{
		}

		public void AddPredictedSfxEvent(SfxEventData eventData, bool isResim)
		{
		}

		public void AddPredictedAnimEvent(AnimEventData eventData, bool isResim)
		{
		}

		public void AddPredictedWarpEvent(WarpEventData eventData, bool isResim)
		{
		}

		public override void OnStartClient()
		{
		}

		public void ReconciliatePredicted(int svPredTickNum, int clPredTickNum)
		{
		}

		public void Reconciliate()
		{
		}

		public void DiffWithVfxHistory(List<VfxEventData> newVfxEvents, int forcedPredTickNumHistory = -1)
		{
		}

		public void DiffWithSfxHistory(List<SfxEventData> newSfxEvents, int svPredTickNum)
		{
		}

		public void DiffWithAnimHistory(List<AnimEventData> newAnimEvents, int forcedPredTickNumHistory = -1)
		{
		}

		public void DiffWithWarpHistory(List<WarpEventData> newWarpEvents, int svPredTickNum)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void ClearBuffers()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
