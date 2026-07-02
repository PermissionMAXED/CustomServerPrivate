using System;
using UnityEngine;

[Serializable]
public class ShaderGlobalConfig
{
	public enum ValueType
	{
		Float = 0,
		Vector2 = 1,
		Vector3 = 2,
		Vector4 = 3,
		Color = 4,
		Int = 5,
		Texture = 6
	}

	public ValueType valueType;

	public string shaderParamName;

	public Vector2 range;

	public bool hasRange;

	public Vector4 shaderValue;

	[NonSerialized]
	public Texture2D textureValue;

	public string textureAssetPath;

	public string group;
}
