using UnityEngine;

public class NamedArrayParseAttribute : PropertyAttribute
{
	public string enumField;

	public NamedArrayParseAttribute(string enumField, int startOffset = 0)
	{
	}
}
