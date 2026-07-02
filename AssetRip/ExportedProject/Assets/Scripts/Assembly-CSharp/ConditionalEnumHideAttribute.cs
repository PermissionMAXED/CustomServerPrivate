using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
public class ConditionalEnumHideAttribute : PropertyAttribute
{
	public string ConditionalSourceField;

	public int EnumValue1;

	public int EnumValue2;

	public bool HideInInspector;

	public bool Inverse;

	public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1)
	{
	}

	public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1, bool hideInInspector)
	{
	}

	public ConditionalEnumHideAttribute(string conditionalSourceField, int enumValue1, int enumValue2, bool hideInInspector)
	{
	}
}
