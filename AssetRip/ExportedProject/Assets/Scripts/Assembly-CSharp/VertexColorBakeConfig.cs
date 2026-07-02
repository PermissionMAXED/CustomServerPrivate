using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VertexColorBakeConfig", menuName = "Rendering/Vertex Color Bake Config", order = 1)]
public class VertexColorBakeConfig : ScriptableObject
{
	[Serializable]
	public enum OutputType
	{
		Keep = 0,
		Curvature = 1,
		Occlusion = 2,
		Thickness = 3,
		Gradient = 4,
		Texture = 5,
		Slope = 6,
		Fresnel = 7,
		EmissiveMap = 8,
		MeshIslands = 9
	}

	public enum BlendModes
	{
		Add = 0,
		Subtract = 1,
		Multiply = 2,
		Divide = 3,
		Min = 4,
		Max = 5,
		Overlay = 6,
		Set = 7
	}

	[Range(16f, 512f)]
	public int sampleCount;

	[Min(0f)]
	public float surfaceBias;

	public bool skipBackfaces;

	[Header("Channel Output")]
	public OutputType redChannel;

	public OutputType greenChannel;

	public OutputType blueChannel;

	public OutputType alphaChannel;

	[Min(0f)]
	[Header("Curvature Parameters")]
	public float curvatureMaxDist;

	public Vector2 curvatureRange;

	[Min(0f)]
	[Header("Occlusion Parameters")]
	public float occlusionMaxDist;

	[Range(0f, 1f)]
	public float occlusionRayBias;

	[Range(0f, 10f)]
	public float occlusionExponent;

	public bool bakeWithVirtualGround;

	[Header("Thickness Parameters")]
	[Min(0f)]
	public float thicknessMaxDist;

	[Header("Gradient Parameters")]
	[Min(0f)]
	public float gradientMaxDist;

	public Vector3 gradientDirection;

	public Vector3 gradientOrigin;

	[Header("Texture Parameters")]
	public Texture2D sampleTexture;

	[Header("Fresnel Parameters")]
	public float fresnelExponent;

	public Vector3 viewDirection;

	[Header("Emissive Parameters")]
	public Texture2D emissiveTexture;

	public float emissiveOffsetDistance;

	public float emissiveMaxDistance;

	public float emissiveAttenuation;

	[Header("Blend Parameters")]
	public BlendModes blendMode;

	public Vector4 curvatureChannels => default(Vector4);

	public Vector4 occlusionChannels => default(Vector4);

	public Vector4 thicknessChannels => default(Vector4);

	public Vector4 gradientChannels => default(Vector4);

	public Vector4 textureChannels => default(Vector4);

	public Vector4 slopechannels => default(Vector4);

	public Vector4 fresnelChannels => default(Vector4);

	public Vector4 emissiveChannels => default(Vector4);

	public Vector4 meshIslandsChannels => default(Vector4);

	public void OnValidate()
	{
	}
}
