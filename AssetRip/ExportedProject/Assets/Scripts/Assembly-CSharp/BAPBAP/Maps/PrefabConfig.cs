using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.Rendering;

namespace BAPBAP.Maps
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class PrefabConfig : MonoBehaviour
	{
		[Serializable]
		public class SurfaceConfig
		{
			public SurfaceId surfaceId;

			[Tooltip("If enabled, sample the ground material instead with biome and ground splat paint colors.")]
			public bool useGroundPaintSurface;

			[Tooltip("Does this object have a surface area? if disabled, defaults to a 1x1 surface area (1 tile).")]
			public bool surfaceArea;

			[ConditionalHide("surfaceArea", true)]
			[Tooltip("The center of the area bounds")]
			public Vector2Int surfaceAreaCenter;

			[ConditionalHide("surfaceArea", true)]
			[Tooltip("The size of the area bounds")]
			public Vector2Int surfaceAreaSize;

			[Tooltip("Order to draw this surface into the surface map. Higher order surfaces will override lower ones.")]
			public float orderInLayer;
		}

		public const int DefaultRenderMask = 2;

		[SerializeField]
		[ReadOnly]
		public bool _isStatic;

		[ReadOnly]
		[SerializeField]
		public int _prefabId;

		[SerializeField]
		public MapLayer mapLayer;

		[Space(5f)]
		[ConditionalEnumHide("mapLayer", 4, true)]
		[SerializeField]
		public EntityAssetsManager.EntityAsset entityConfig;

		[Header("Surface")]
		[SerializeField]
		public SurfaceConfig surfaceConfig;

		[Tooltip("Default ambience id for this object as a fallback for no ambient map")]
		[SerializeField]
		public AmbienceId defaultAmbienceId;

		[Header("Settings")]
		[Tooltip("Used to know if the object shouldnt rotate, so it will be always facing front")]
		[SerializeField]
		public bool isNoRotation;

		[SerializeField]
		[Header("Rendering")]
		[Tooltip("Define custom shadow casting behaviour for ceiling tiles")]
		[ConditionalEnumHide("mapLayer", 5, true)]
		public ShadowCastingMode shadowCastingMode;

		[RenderingLayersMaskProperty]
		[SerializeField]
		public int renderingLayerMask;

		[SerializeField]
		public bool bakeIntoMinimap;

		[SerializeField]
		[Tooltip("Used to know if this objct is a tile collider and can be tiled together and simplified")]
		[Header("Tile Settings")]
		public bool isTiledCollider;

		[Tooltip("(For Level Editor) Is this object supposed to be walkable? Intended for water obstacle assets that can shouldnt have collision.")]
		[SerializeField]
		public bool isWalkable;

		[Tooltip("Is this asset considered as a water tile? Used for minimap and procgen purposes.")]
		[SerializeField]
		public bool isWaterTile;

		public bool IsStatic => false;

		public int PrefabId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Validate(bool fullValidate = true)
		{
		}

		public void OnDrawGizmosSelected()
		{
		}
	}
}
