using System;
using Mirror;

namespace BAPBAP.Utilities
{
	public static class BinaryUtility
	{
		public static string ByteArrayToString(byte[] ba, int maxBytes = -1)
		{
			return null;
		}

		public static string ByteArraySegmentToString(ArraySegment<byte> ba)
		{
			return null;
		}

		public static void XOR(NetworkWriter previous, NetworkWriter current, NetworkWriter delta)
		{
		}

		public static void ZRLE(NetworkWriter uncompressedInput, NetworkWriter compressedResult)
		{
		}

		public static void UnZRLE(ArraySegment<byte> compressedInput, NetworkWriter uncompressedResult)
		{
		}

		public static bool IsEmpty(NetworkWriter writer, int byteOffset = 0)
		{
			return false;
		}

		public static bool UnsafeCompare(byte[] a1, byte[] a2)
		{
			return false;
		}
	}
}
