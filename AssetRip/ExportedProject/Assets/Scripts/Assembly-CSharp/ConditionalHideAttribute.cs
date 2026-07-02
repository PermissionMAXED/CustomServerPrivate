using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
	public string ConditionalSourceField;

	public bool HideInInspector;

	public ConditionalHideAttribute(string conditionalSourceField)
	{
	}

	public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector)
	{
	}
}
