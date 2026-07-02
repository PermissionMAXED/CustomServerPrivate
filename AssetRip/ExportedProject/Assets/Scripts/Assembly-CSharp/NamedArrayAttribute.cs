using System;
using UnityEngine;

public class NamedArrayAttribute : PropertyAttribute
{
	public string[] names;

	public NamedArrayAttribute(Type TargetEnum, int startOffset = 0)
	{
	}
}
