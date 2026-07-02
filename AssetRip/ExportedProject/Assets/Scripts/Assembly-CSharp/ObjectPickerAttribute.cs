using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class ObjectPickerAttribute : PropertyAttribute
{
	public Type FieldType { get; set; }

	public ObjectPickerAttribute(Type fieldType)
	{
	}
}
