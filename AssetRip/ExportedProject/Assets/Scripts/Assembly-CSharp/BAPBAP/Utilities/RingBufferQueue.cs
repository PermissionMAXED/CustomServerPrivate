using System;

namespace BAPBAP.Utilities
{
	public class RingBufferQueue<T>
	{
		[NonSerialized]
		public int head;

		[NonSerialized]
		public int tail;

		[NonSerialized]
		public int size;

		[NonSerialized]
		public bool allowOverflow;

		[NonSerialized]
		public T[] buffer;

		public int Capacity => 0;

		public int Size => 0;

		public RingBufferQueue(int capacity, bool overflow)
		{
		}

		public void Enqueue(T element)
		{
		}

		public T Dequeue()
		{
			return default(T);
		}

		public bool TryDequeue(out T element)
		{
			element = default(T);
			return false;
		}

		public void DequeueNoAccess()
		{
		}

		public T Peek(int offset)
		{
			return default(T);
		}

		public void Modify(T element, int offset)
		{
		}

		public int ConvertToBufferIndex(int index, bool allowNegative)
		{
			return 0;
		}

		public int ConvertOffsetToBufferIndex(int offset)
		{
			return 0;
		}
	}
}
