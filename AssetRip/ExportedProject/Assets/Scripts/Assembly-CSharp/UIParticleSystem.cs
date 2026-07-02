using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(CanvasRenderer))]
[ExecuteInEditMode]
public class UIParticleSystem : MaskableGraphic
{
	public Texture particleTexture;

	public Sprite particleSprite;

	[NonSerialized]
	public Transform _transform;

	[NonSerialized]
	public ParticleSystem _particleSystem;

	[NonSerialized]
	public ParticleSystem.Particle[] _particles;

	[NonSerialized]
	public UIVertex[] _quad;

	[NonSerialized]
	public Vector4 _uv;

	[NonSerialized]
	public ParticleSystem.TextureSheetAnimationModule _textureSheetAnimation;

	[NonSerialized]
	public int _textureSheetAnimationFrames;

	[NonSerialized]
	public Vector2 _textureSheedAnimationFrameSize;

	public override Texture mainTexture => null;

	public bool Initialize()
	{
		return false;
	}

	public override void Awake()
	{
	}

	public override void OnPopulateMesh(VertexHelper vh)
	{
	}

	public void Update()
	{
	}
}
