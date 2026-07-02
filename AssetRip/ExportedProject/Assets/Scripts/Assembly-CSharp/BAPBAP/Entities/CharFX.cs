using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharFX : MonoBehaviour
	{
		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UICanvasEffect uiCanvasEffect;

		[FormerlySerializedAs("killedVFXPrefab")]
		[Tooltip("Custom vfx reference. If null, will use the default vfx reference in vfx manager")]
		[Header("Char VFX")]
		[SerializeField]
		public GameObject killedVFXPrefabOverride;

		[Tooltip("Custom material reference. If null, will use the default material reference in vfx manager")]
		[SerializeField]
		[Header("Custom Mat References")]
		public Material frozenMaterialOverride;

		[SerializeField]
		[Tooltip("Custom material reference. If null, will use the default material reference in vfx manager")]
		public Material petrifyMaterialOverride;

		[Tooltip("Custom material reference. If null, will use the default material reference in vfx manager")]
		[SerializeField]
		public Material metalMaterialOverride;

		[Tooltip("Custom material reference. If null, will use the default material reference in vfx manager")]
		[SerializeField]
		public Material untargetableMaterialOverride;

		[Header("On Hit FX")]
		[SerializeField]
		public bool doOnHitSfx;

		[ConditionalHide("doOnHitSfx", true)]
		[SerializeField]
		public AudioClipData onHitSfxData;

		[SerializeField]
		public bool doOnHitVfx;

		[ConditionalHide("doOnHitVfx", true)]
		[SerializeField]
		public GameObject onHitVfxPrefab;

		[NonSerialized]
		public Dictionary<int, GameObject> vfxInstanceByStatusEffectId;

		[NonSerialized]
		public GameObject dzAtlantisBubbleInstance;

		[NonSerialized]
		public List<Material> materialFxQueue;

		public void PreAwake(EntityManager e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void ClInitializeMaterialInstances()
		{
		}

		public void EnableMetalicFx()
		{
		}

		public void DisableMetalicFx()
		{
		}

		public void EnableFrozenFx()
		{
		}

		public void DisableFrozenFx()
		{
		}

		public void EnableUntargetableFx()
		{
		}

		public void DisableUntargetableFx()
		{
		}

		public void EnablePetrifyFx()
		{
		}

		public void DisablePetrifyFx()
		{
		}

		public void EnableOverlayFx(Material overlayMat)
		{
		}

		public void DisableOverlayFx(Material overlayMat)
		{
		}

		public void UpdateMaterialOverlayQueue()
		{
		}

		public void EnableMaterialOverlayFx(Material overlayMat)
		{
		}

		public void EnableMaterialOverlayFxOnRenderer(Renderer renderer, Material overlayMat)
		{
		}

		public void DisableMaterialOverlayFx()
		{
		}

		public void EnableStatusEffectFx(int statusEffectId, float duration = 0f)
		{
		}

		public void TryDisableStatusEffectFx(int statusEffectId, bool immediate = false)
		{
		}

		public GameObject SpawnVFX(GameObject vfxPrefab, float destroyTimer = 1f, bool parentedToChar = true)
		{
			return null;
		}

		public void OnHitFx()
		{
		}

		public void SpawnAirborneLandingVfx()
		{
		}

		public void SpawnDestroyVFXLastPlayer()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnCharDestroy()
		{
		}

		public void DoDestroy()
		{
		}
	}
}
