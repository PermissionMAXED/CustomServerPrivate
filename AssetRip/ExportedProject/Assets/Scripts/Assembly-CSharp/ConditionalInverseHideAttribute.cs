using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
public class ConditionalInverseHideAttribute : PropertyAttribute
{
	public string ConditionalSourceField;

	public bool HideInInspector;

	public ConditionalInverseHideAttribute(string conditionalSourceField)
	{
	}

	public ConditionalInverseHideAttribute(string conditionalSourceField, bool hideInInspector)
	{
	}
}
