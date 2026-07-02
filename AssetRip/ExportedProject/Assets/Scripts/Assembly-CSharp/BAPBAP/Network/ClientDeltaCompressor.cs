using System;
using Mirror;

namespace BAPBAP.Network
{
	public class ClientDeltaCompressor
	{
		[NonSerialized]
		public int rotateId;

		[NonSerialized]
		public int currIndex;

		[NonSerialized]
		public int prevIndex;

		[NonSerialized]
		public NetworkWriter[] baselineStateWriters;

		[NonSerialized]
		public NetworkWriter deltaStateWriter;

		public void StoreBaseline(ArraySegment<byte> svBaselineState)
		{
		}

		public ArraySegment<byte> ReconstructAndStoreBaseline(ArraySegment<byte> svDeltaState)
		{
			return default(ArraySegment<byte>);
		}

		public void RotateWriters()
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
	}
}
