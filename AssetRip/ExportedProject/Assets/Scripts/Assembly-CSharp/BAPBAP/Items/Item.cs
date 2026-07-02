using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Items
{
	public class Item : ScriptableObject
	{
		[Min(0f)]
		[Tooltip("The overall scale of the item renderer")]
		[Header("Rendering")]
		public float scale;

		[Tooltip("The overall height of the item renderer")]
		public float height;

		[Space(5f)]
		[Tooltip("The mesh to use for this item")]
		public Mesh mesh;

		public float meshHeight;

		[Min(0f)]
		public float meshScale;

		[Tooltip("Custom item material. If null, will use the default item material")]
		public Material[] materials;

		[Space(5f)]
		public Mesh secondaryMesh;

		public float secondaryMeshHeight;

		[Min(0f)]
		public float secondaryMeshScale;

		public Material[] secondaryMaterials;

		[Space(5f)]
		public GameObject meshVfxPrefab;

		[Tooltip("Custom item theme configuration. If false, will default to the current tier theme for this item")]
		[Header("Theme")]
		public bool customItemTheme;

		[ConditionalHide("customItemTheme", true)]
		public ItemTheme itemTheme;

		[Header("FXs")]
		public bool useCustomPickupSfx;

		[ConditionalHide("useCustomPickupSfx", true)]
		public AudioClipData customPickupSfx;

		public bool useCustomDropSfx;

		[ConditionalHide("useCustomDropSfx", true)]
		public AudioClipData customDropSfx;

		[SpriteVisualizer(76)]
		[Header("UI")]
		public Sprite icon;

		public string titleTranslationKey;

		public string descriptionTranslationKey;

		[Header("General Settings")]
		public ItemTiers tier;

		[Tooltip("Is this item selectable to characters? If false, this item wont be selected/highlighted for chars, but it will still be hovered/tracked by them")]
		public bool isSelectable;

		[Min(0f)]
		[Tooltip("Set a custom item pickup collider radius. If set to 0, no custom radius will be set")]
		public float customPickupRadius;

		[Tooltip("Price for this item in the shop, if unique")]
		[Min(0f)]
		public int price;

		[Tooltip("Enable an auto destroy timer for this item that starts every time it gets spawned")]
		public bool doAutoDestroy;

		[Min(0f)]
		[ConditionalHide("doAutoDestroy", true)]
		public float autoDestroyDuration;

		public virtual Mesh GetMesh(int amount)
		{
			return null;
		}
	}
}
