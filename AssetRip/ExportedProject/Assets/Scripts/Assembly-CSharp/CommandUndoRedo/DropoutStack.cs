using System;
using System.Collections.Generic;

namespace CommandUndoRedo
{
	public class DropoutStack<T> : LinkedList<T>
	{
		[NonSerialized]
		public int _maxLength;

		public int maxLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public DropoutStack()
		{
		}

		public DropoutStack(int maxLength)
		{
		}

		public void Push(T item)
		{
		}

		public T Pop()
		{
			return default(T);
		}

		public void SetMaxLength(int max)
		{
		}
	}
}
