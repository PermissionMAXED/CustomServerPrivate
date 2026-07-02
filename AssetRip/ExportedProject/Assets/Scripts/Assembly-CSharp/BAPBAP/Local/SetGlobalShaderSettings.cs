using System;
using UnityEngine;

namespace BAPBAP.Local
{
	[ExecuteInEditMode]
	public class SetGlobalShaderSettings : MonoBehaviour
	{
		[Header("Battle Royale Zone Parameters")]
		public Color zoneColor;

		public Color zoneEdgeColor;

		public Color zoneGlowColor;

		public Color zonePreviewRingColor;

		public float zonePreviewRingWidth;

		public float zoneGlowSize;

		public float zoneEdgeWidth;

		public float zoneSharpness;

		[Header("Fog of War Parameters")]
		public Color fowShadowColor;

		[Header("Light Settings")]
		public Light worldLight;

		[Header("Night Lighting Settings")]
		public float nightWorldLightIntensity;

		public float nightShadowStrength;

		public Color nightLightColor;

		public Color nightFowShadowColor;

		[NonSerialized]
		public float dayWorldLightIntensity;

		[NonSerialized]
		public float dayShadowStrength;

		[NonSerialized]
		public Color dayLightColor;

		[NonSerialized]
		public Color curentFowShadowColor;

		[NonSerialized]
		public float currentWorldLightIntensity;

		[NonSerialized]
		public float currentShadowStrength;

		public static Light WorldLight { get; set; }

		public void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void SetNightTimeEnabled()
		{
		}

		public void SetNightTimeDisabled()
		{
		}

		public void SetShaderSettings()
		{
		}

		public void SetFoWShaderSettings()
		{
		}

		public static void SetLightShaderSettings()
		{
		}
	}
}
