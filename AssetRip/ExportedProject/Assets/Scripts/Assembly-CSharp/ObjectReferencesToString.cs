using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class ObjectReferencesToString : PropertyAttribute
{
	public string referenceProperty;

	public bool showArraySize;

	public bool hideInInspector;

	public ObjectReferencesToString(string referenceProperty, bool showArraySize = true, bool hideInInspector = true)
	{
	}
}
