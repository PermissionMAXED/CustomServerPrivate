using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class Blend2DAttribute : PropertyAttribute
{
	public readonly string XLabel;

	public readonly string YLabel;

	public readonly Vector2 Min;

	public readonly Vector2 Max;

	public readonly string BgGuid;

	public Blend2DAttribute(string xLabel, string yLabel)
	{
	}

	public Blend2DAttribute(string xLabel, string yLabel, float minX, float minY, float maxX, float maxY)
	{
	}

	public Blend2DAttribute(string xLabel, string yLabel, float minX, float minY, float maxX, float maxY, string bgGuid)
	{
	}
}
