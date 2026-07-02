using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	public static float kDefaultButtonWidth;

	public readonly string MethodName;

	[NonSerialized]
	public float _buttonWidth;

	public float ButtonWidth
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public InspectorButtonAttribute(string MethodName)
	{
	}
}
