using System;

public class NonAllocCooldownsString
{
	[NonSerialized]
	public readonly char[] _buffer1;

	[NonSerialized]
	public readonly char[] _buffer2;

	[NonSerialized]
	public bool _isBuffer1Active;

	public bool IsDirty { get; set; }

	public void Update(float timeInSeconds)
	{
	}

	public void UpdateMilliseconds(float milliseconds)
	{
	}

	public char[] GetCharArray()
	{
		return null;
	}

	public static void UpdateBuffer(float timeInSeconds, char[] array)
	{
	}

	public static bool BuffersEqual(char[] bufferA, char[] bufferB)
	{
		return false;
	}
}
