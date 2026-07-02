using System;
using System.Collections.Generic;
using Mirror;

namespace BAPBAP.Network
{
	public class ServerDeltaCompressor
	{
		[NonSerialized]
		public int svUpdateNum;

		[NonSerialized]
		public int currIndex;

		[NonSerialized]
		public int prevIndex;

		[NonSerialized]
		public NetworkWriter[] svBaselineStateWriters;

		[NonSerialized]
		public NetworkWriter svDeltaStateWriter;

		[NonSerialized]
		public HashSet<NetworkConnection>[] svAlreadyBaselinedPlayersSets;

		public void Rotate()
		{
		}

		public NetworkWriter GetCurrBaselineWriter()
		{
			return null;
		}

		public NetworkWriter GetPrevBaselineWriter()
		{
			return null;
		}

		public HashSet<NetworkConnection> GetCurrBaselinedPlayers()
		{
			return null;
		}

		public HashSet<NetworkConnection> GetPrevBaselinedPlayers()
		{
			return null;
		}

		public NetworkWriter RotateAndClear()
		{
			return null;
		}

		public NetworkWriter CalculateDelta()
		{
			return null;
		}

		public bool IsAlreadyBaselined(NetworkConnection conn)
		{
			return false;
		}

		public void AddBaselinedPlayer(NetworkConnection conn)
		{
		}
	}
}
