using System;
using UnityEngine;

namespace Highlighters
{
	[Serializable]
	public class HighlighterSettings
	{
		[Serializable]
		public class OverlaySettings
		{
			[NonSerialized]
			[NonSerialized]
			public HighlighterSettings highlighterSettings;

			[Tooltip("Color of the overlay.")]
			[SerializeField]
			public Color color;

			[SerializeField]
			[Tooltip("Whether to use texture for overlay patterns.")]
			public bool useTexture;

			[SerializeField]
			[Tooltip("Overlay pattern texture.")]
			public Texture2D texture;

			[SerializeField]
			[Tooltip("Overlay background opacity.")]
			[Range(0f, 1f)]
			public float background;

			[Tooltip("Tilling of the overlay pattern.")]
			[SerializeField]
			public float tilling;

			[Tooltip("Rotation of the overlay pattern.")]
			[Range(0f, 180f)]
			[SerializeField]
			public float rotation;

			public Color Color
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public bool UseTexture
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Texture2D Texture
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public float Background
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float Tilling
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float Rotation
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public OverlaySettings(HighlighterSettings highlighterSettings)
			{
			}

			public void SetMaterialProperties(string type)
			{
			}
		}

		[SerializeField]
		[Tooltip("A type of masking for highlighter.")]
		public DepthMask depthMask;

		[SerializeField]
		public float infoRenderScale;

		[SerializeField]
		public bool useOverlay;

		[SerializeField]
		public bool useSingleOverlay;

		[SerializeField]
		public OverlaySettings overlayFront;

		[SerializeField]
		public OverlaySettings overlayBack;

		[NonSerialized]
		public Vector4 renderingBounds;

		[NonSerialized]
		public Material overlayMaterial;

		public DepthMask DepthMask
		{
			get
			{
				return default(DepthMask);
			}
			set
			{
			}
		}

		public float InfoRenderScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool UseOverlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseSingleOverlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public OverlaySettings OverlayFront
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OverlaySettings OverlayBack
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector4 RenderingBounds => default(Vector4);

		public bool IsAnyOverlayUsed()
		{
			return false;
		}

		public void SetRenderBoundsValues(Vector4 renderingBounds)
		{
		}

		public void SetOverlayMaterialProperties(Material material = null)
		{
		}
	}
}
