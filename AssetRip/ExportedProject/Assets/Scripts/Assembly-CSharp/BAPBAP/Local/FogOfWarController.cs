using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FogOfWarController : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public RenderTexture fowRenderTexture;

		[SerializeField]
		public FogOfWarPixelPosition fowPixelPos;

		[SerializeField]
		public Transform rendererScale;

		[SerializeField]
		public EntityVisibility entityVisibility;

		[SerializeField]
		[Tooltip("The scale of the fog of war, radius in world units. This will set the scale of the fow renderer automatically")]
		[Header("Settings")]
		public float currentRadius;

		[SerializeField]
		public float fowSmoothTime;

		[SerializeField]
		public float fadeFowAlphaDuration;

		[SerializeField]
		[Tooltip("Min radius for the FoW edge. Sets the radius edge of the fow from this min to max values")]
		public RangeFloat radiusEdgeShadowRange;

		[SerializeField]
		[Tooltip("Min-max difference from the current fow radius. Will fade form min to max by this amount")]
		public RangeFloat foWFadeRadiusRange;

		[NonSerialized]
		public float defaultRadiusSize;

		[NonSerialized]
		public float currentTargetRadius;

		[NonSerialized]
		public float targetRadius;

		[NonSerialized]
		public float fowDampVelocity;

		[NonSerialized]
		public float radiusSizeMultiplier;

		[NonSerialized]
		public bool doFadeFowAlpha;

		[NonSerialized]
		public float fadeFowAlphaTime;

		[NonSerialized]
		public float targetFoWAlpha;

		[NonSerialized]
		public bool initialized;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void ModifyRadiusSizeMultiplier(float addMultiplier, bool doLerp = true)
		{
		}

		public void LateUpdate()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void SetDefaultVisibilityRadius()
		{
		}

		public void SetVisibilityRadius(float radius)
		{
		}

		public void EnableFoWController()
		{
		}

		public void DisableFoWController()
		{
		}

		public void FadeAlphaOut()
		{
		}

		public void FadeAlphaIn()
		{
		}

		public void UpdateRadius()
		{
		}

		public void SetShaderParameters()
		{
		}

		public void ResetShaderParameters()
		{
		}
	}
}
