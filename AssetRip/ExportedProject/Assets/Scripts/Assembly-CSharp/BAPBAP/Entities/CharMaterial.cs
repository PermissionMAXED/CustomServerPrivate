using System;
using System.Collections.Generic;
using BAPBAP.Systems;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharMaterial : MonoBehaviour
	{
		public class MaterialWrapper
		{
			public Material matInstance;

			public Material originalMat;

			public int overrideTransparentQueue;

			public int overrideOpaqueQueue;

			public float maxAlpha;

			public bool tintable;
		}

		public static Bounds defaultCharBounds;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SystemManager systemManager;

		[Header("Char References")]
		[Tooltip("The character visuals root object holder")]
		[SerializeField]
		public GameObject charRootHolder;

		[Tooltip("The character rig object")]
		[SerializeField]
		public GameObject charRigObj;

		[SerializeField]
		[Tooltip("The animated character rig root bone object")]
		public Transform charAnimatedRoot;

		[SerializeField]
		[Tooltip("The animated character rig chest bone object")]
		public Transform charAnimatedChest;

		[SerializeField]
		[Tooltip("The character rig main renderer component")]
		public Renderer charRenderer;

		[SerializeField]
		[Tooltip("Any character extra renderer components")]
		public Renderer[] extraRenderers;

		[SerializeField]
		[Tooltip("Any extra object to set hidden visibility")]
		public GameObject hiddenObj;

		[SerializeField]
		[Tooltip("Any character extra object components to set hidden visibility")]
		public List<GameObject> extraObjs;

		[SerializeField]
		[Tooltip("Any attached ui objects for this character, like an hp bar")]
		public List<CanvasGroup> attachedUIElements;

		[Tooltip("Any particle system objects that need to be detached when destroying the character")]
		[SerializeField]
		public ParticleSystem[] detachableParticleSystems;

		[Header("Settings")]
		[SerializeField]
		public float baseIndicatorRadius;

		[SerializeField]
		public GameObject baseIndicatorPrefab;

		[SerializeField]
		public GameObject baseIndicatorChild;

		[SerializeField]
		public IndicatorBaseMaterial indicatorMaterial;

		[SerializeField]
		public float gigantifyFadeDuration;

		[Header("Settings")]
		[Tooltip("Custom renderer bounds for visibility checks, used for cases where renderer bounds are not available")]
		[SerializeField]
		public bool customVisRendererBounds;

		[SerializeField]
		[ConditionalHide("customVisRendererBounds", true)]
		public Bounds customVisBounds;

		[SerializeField]
		public bool forceNoOutline;

		[SerializeField]
		[Header("References")]
		public Shader overrideCharOpaqueShader;

		[SerializeField]
		public Shader overrideCharTransparentShader;

		[NonSerialized]
		public GameObject indicatorObject;

		[NonSerialized]
		public float partialHiddenAlpha;

		[NonSerialized]
		public float hitAmount;

		[NonSerialized]
		public float hitDamp;

		[NonSerialized]
		public float baseColorResetTime;

		[NonSerialized]
		public float lerpColorTimer;

		[NonSerialized]
		public float lerpColorDuration;

		[NonSerialized]
		public Color targetLerpColor;

		[NonSerialized]
		public bool targetLerpColorResetBase;

		[NonSerialized]
		public bool rendererIsActive;

		[NonSerialized]
		public float alpha;

		[NonSerialized]
		public bool isOpaque;

		[NonSerialized]
		public float alphaFadeTimer;

		[NonSerialized]
		public float alphaFadeDuration;

		[NonSerialized]
		public bool fadeGigantify;

		[NonSerialized]
		public float gigantifyTimer;

		[NonSerialized]
		public float gigantifyTargetScale;

		[NonSerialized]
		public bool isPartialHidden;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public Dictionary<int, MaterialWrapper[]> materialWrappersByRendererInstId;

		[NonSerialized]
		public MaterialWrapper[] materialWrappers;

		public Bounds VisRendererBounds => default(Bounds);

		public GameObject BaseIndicator => null;

		public Transform CharAnimatedChest => null;

		public Transform CharAnimatedRoot => null;

		public void OnValidate()
		{
		}

		public void Validate()
		{
		}

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void ClInitialize()
		{
		}

		public void EnsureInitialized()
		{
		}

		public void InitializeMaterialWrappers()
		{
		}

		public void ReInitializeMaterialWrappers()
		{
		}

		public void SetupMaterialWrappers(Renderer renderer, List<MaterialWrapper> allMatWrappers, out MaterialWrapper[] newRendererWrappers)
		{
			newRendererWrappers = null;
		}

		public void InitializeOverlayRendererLayers()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void IterateHitBlinkFunc(MaterialWrapper wrapper)
		{
		}

		public void IterateColorLerpFunc(MaterialWrapper wrapper)
		{
		}

		public void AnimateAlphaLerp()
		{
		}

		public void StartGigantify(float additiveScale)
		{
		}

		public void EndGigantify(float substractScale)
		{
		}

		public void TriggerHit(Color color, float dampRatio = -1f)
		{
		}

		public void SetTeam(bool isLocalPlayer, bool isAlly, bool isPlayer)
		{
		}

		public void SetBaseColorTimed(Color color, float duration)
		{
		}

		public void SetBaseColor(Color color)
		{
		}

		public void SetBaseColorLerp(Color color)
		{
		}

		public void ResetBaseColor()
		{
		}

		public void ResetBaseColorTimedImmediate()
		{
		}

		public void SetupBaseIndicator(bool isLocalPlayer)
		{
		}

		public void UpdateBaseIndicator(bool isLocalPlayer, bool isAlly, bool isPlayer)
		{
		}

		public void SetIndicatorDowned(bool isDowned)
		{
		}

		public void ToggleBaseIndicator(bool isEnabled)
		{
		}

		public void SetBaseIndicatorVisibility(bool isVisible)
		{
		}

		public void SetBaseIndicatorAlpha(float alphaNorm)
		{
		}

		public void UpdateCurrentRendererMaterialAlpha()
		{
		}

		public void SetRendererMaterialAlpha(float alpha)
		{
		}

		public void SetMaterialAlpha(MaterialWrapper wrapper)
		{
		}

		public void SetAttachedUIAlpha(float alpha)
		{
		}

		public void SetRendererEnabled(bool isEnabled)
		{
		}

		public void ResetMaterials()
		{
		}

		public void ResetRendererMaterials(Renderer renderer)
		{
		}

		public void ResetRendererMaterials(Renderer renderer, MaterialWrapper[] rendererWrappers)
		{
		}

		public void SetCharRendererPartialHidden(bool isHidden)
		{
		}

		public void SetCharRendererEnabled(bool isEnabled)
		{
		}

		public void SetCharRendererEnabledLerp(bool isEnabled, float lerpDuration = 0.15f)
		{
		}

		public void RevealHiddenCharacter()
		{
		}

		public void ForceAlphaLerpFinish()
		{
		}

		public void SetCharacterVisible(bool isEnabled)
		{
		}

		public void DetachAllRunningParticleSystems()
		{
		}

		public void AddHideExtraGameObject(GameObject obj)
		{
		}

		public void RemoveHideExtraGameObject(GameObject obj)
		{
		}

		public void AddAttachedUIElement(CanvasGroup canvasGroup)
		{
		}

		public void RemoveAttachedUIElement(GameObject obj)
		{
		}

		public void IterateThroughAllRenderers(Action<Renderer> rendererAction)
		{
		}

		public void IterateThroughRenderers(Action<Renderer> rendererAction)
		{
		}

		public void IterateThroughMaterialWrappers(Action<MaterialWrapper> wrapperAction)
		{
		}
	}
}
